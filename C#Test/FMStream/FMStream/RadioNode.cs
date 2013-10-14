using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace FMStream
{
    public class RadioNode
    {
        public class  TuneStatus 
        {
            public bool Valid { get; set; }
            public int TuneFrequency { get; set; }
            public int Rssi { get; set; }
            public int Snr { get; set; }
            public int AntenaCap { get; set; }
            public static TuneStatus Parse(string[] message)
            {
                TuneStatus result = new TuneStatus();
                result.Valid = int.Parse(message[1])==1;
                result.TuneFrequency = int.Parse(message[2]);
                result.Rssi = int.Parse(message[3]);
                result.Snr = int.Parse(message[4]);
                result.AntenaCap = int.Parse(message[5]);
                return result;
            }
        } 
        private enum RadioState { None = 'n', GetRDS='r', GetSlot='p', SetFrequency='f', GetTuneStatus='t',Sw='w', ShutDown='s', Seek='y', Error='e'};
        RadioState state = RadioState.None;
        private SerialPort serialPort;
        public delegate void DataReceivedEventHandler(string data);
        public event DataReceivedEventHandler DataReceived;
        public delegate void SwEventHandler(int index, bool state);
        public event SwEventHandler SwEvent;
        public delegate void TuneStatusEventHandler(TuneStatus tuneStatus);
        public event TuneStatusEventHandler TuneStatusEvent;
        public delegate void RdsEventHandler(string rds);
        public event RdsEventHandler RdsEvent;
        public delegate void SlotEventHandler(int slot);
        public event SlotEventHandler SlotEvent;
        public delegate void ShutDownEventHandler(bool shutDownState);
        public event ShutDownEventHandler ShutDownEvent;
        System.Timers.Timer shutDownTimer = new System.Timers.Timer(5000);

        public RadioNode()
        {
            serialPort = new SerialPort();   
            try
            {
                shutDownTimer.Elapsed += new System.Timers.ElapsedEventHandler(ShutDownElapsedTimer);
                shutDownTimer.Start();
                foreach (string str in SerialPort.GetPortNames())
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();
                    serialPort.PortName = "COM6";//str;
                    serialPort.Open();
                    serialPort.BaudRate = 9600;
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                }
            }
            catch (TimeoutException)
            {
                serialPort.Close();
            }
        }
        void ShutDownElapsedTimer(object sender, EventArgs e)
        {
            shutDownTimer.Enabled = false;
            ShutDownEvent(false);

        } 
        //private string buffer;
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = serialPort.ReadLine();
            if (this.DataReceived != null)
                DataReceived(data);
            ParseMessage(data);
            /*
            buffer += serialPort.ReadExisting();
            string result="";
            int counter =0;
            for(int count =0; count < buffer.Length; count++)
            {
                if (buffer[count] == '\r')
                {
                    if (count - counter != 0)
                    {
                        if (this.DataRecived != null)
                            DataRecived(result);
                        ParseMessage(result);
                        result = "";
                    }
                    counter = count;

                }
                else if(buffer[count] != '\n')
                    result += buffer[count];
           }
           buffer = buffer.Substring(counter);

            //this.Invoke((Action)(() => { SerialRawText.Text += serialPort.ReadLine() + '\n'; }));
             * */
        }
        // shutDown s 
        private void ParseMessage(string buffer)
        {
            var data = buffer.Split(';');
            if (data.Length > 0)
            {

                if (data[0][0] == (char)RadioState.ShutDown)
                {
                    if (this.ShutDownEvent != null)
                    {
                        ShutDownEvent(true);
                        shutDownTimer.Start();
                        shutDownTimer.Enabled = true;
                    }
                }
                else
                {
                    switch (state)
                    {
                        case RadioState.GetRDS:
                            if (data[0][0] == (char)RadioState.GetRDS)
                            {
                                string rds = data[1];
                                if (RdsEvent != null)
                                    RdsEvent(rds);
                                state = RadioState.None;
                            }
                            else
                                state = RadioState.Error;
                            break;
                        case RadioState.GetSlot:
                            if (data[0][0] == (char)RadioState.GetSlot)
                            {
                                int slot = int.Parse(data[1]);
                                if (SlotEvent != null)
                                    SlotEvent(slot);
                                state = RadioState.None;
                            }
                            else
                                state = RadioState.Error;
                            break;
                        case RadioState.GetTuneStatus:
                            if (data[0][0] == (char)RadioState.GetTuneStatus)
                            {
                                var tuneStatus = TuneStatus.Parse(data);
                                if (TuneStatusEvent != null)
                                    TuneStatusEvent(tuneStatus);
                                state = RadioState.None;
                            }
                            else
                                state = RadioState.Error;
                            break;
                        case RadioState.SetFrequency:
                            if (data[0][0] == (char)RadioState.SetFrequency)
                            {
                                var tuneStatus = TuneStatus.Parse(data);
                                if (TuneStatusEvent != null)
                                    TuneStatusEvent(tuneStatus);
                                state = RadioState.None;
                            }
                            else
                                state = RadioState.Error;
                            break;
                        case RadioState.Seek:
                            if (data[0][0] == (char)RadioState.Seek)
                            {
                                var tuneStatus = TuneStatus.Parse(data);
                                if (TuneStatusEvent != null)
                                    TuneStatusEvent(tuneStatus);
                                state = RadioState.None;
                            }
                            else
                                state = RadioState.Error;
                            break;
                        case RadioState.Sw:
                            if (data[0][0] == (char)RadioState.Sw)
                            {
                                int index = int.Parse(data[1]);
                                bool swState = int.Parse(data[2]) != 0;
                                if (SwEvent != null)
                                    SwEvent(index, swState);
                                state = RadioState.None;
                            }
                            else
                                state = RadioState.Error;
                            break;
                        default:
                            state = RadioState.Error;
                            break;


                    }
                    state = RadioState.None;
                }
            }
        }
        //w
        public void Sw(int index, bool active)
        {
            //Message format s(1|2)(1|0)
            string message = "w"+ index +(active?"1":"0");
            serialPort.Write(message);
            state = RadioState.Sw;
 
        }
        //f
        public void SetFrequency(int frequency)
        {
            string message = "f" + frequency.ToString("0000");
            serialPort.Write(message);
            state = RadioState.SetFrequency;
        }
        //y
        public void Seek()
        {
            string message = "y";
            serialPort.Write(message);
            state = RadioState.Seek;
        }
        //t
        public void getTuneStatus()
        {
            string message = "t";
            serialPort.Write(message);
            state = RadioState.GetTuneStatus;
 
        }
        //r
        public void GetRDS()
        {
            string message = "r";
            serialPort.Write(message);
            state = RadioState.GetRDS;
        }
        //p
        public void GetSlot()
        {
            string message = "p";
            serialPort.Write(message);
            state = RadioState.GetSlot;
        }
    }
}
