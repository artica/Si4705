using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace FMStream
{
      
    public partial class Form1 : Form
    {
        RadioNode radio = new RadioNode();
        PowerModule power = new PowerModule();
        
       
        bool [] swState = {false, false};
        
        public Form1()
        {
            InitializeComponent();
            radio.DataReceived += new FMStream.RadioNode.DataReceivedEventHandler(radio_DataReceived);
            radio.RdsEvent += new FMStream.RadioNode.RdsEventHandler(radio_RdsEvent);
            radio.ShutDownEvent += new FMStream.RadioNode.ShutDownEventHandler(radio_ShutDownEvent);
            radio.SlotEvent += new FMStream.RadioNode.SlotEventHandler(radio_SlotEvent);
            radio.SwEvent += new FMStream.RadioNode.SwEventHandler(radio_SwEvent);
            radio.TuneStatusEvent += new FMStream.RadioNode.TuneStatusEventHandler(radio_TuneStatusEvent);
            power.PowerComProvider.DataReceived += new FmStreamPowerMessageHandler.DataReceivedEventHandler(PowerComProvider_DataReceived);
           
        }
        void PowerComProvider_DataReceived(PowerMessage data)
        {
            this.Invoke((Action)(() =>
            {
                key0.Text = data.Keys[0];
                key1.Text = data.Keys[1];
                key2.Text = data.Keys[2];
                value0.Text = data.Values[0].ToString("F");
                value1.Text = data.Values[1].ToString("F");
                value2.Text = data.Values[2].ToString("F");
            }));
        }
        void radio_TuneStatusEvent(RadioNode.TuneStatus tuneStatus)
        {
            this.Invoke((Action)(() =>
            { 
                this.validStatus.Checked = tuneStatus.Valid;
                this.freqStatus.Text = tuneStatus.TuneFrequency.ToString();
                this.rssi.Text = tuneStatus.Rssi.ToString();
                this.snr.Text = tuneStatus.Snr.ToString();
                this.AntenaCap.Text= tuneStatus.AntenaCap.ToString();
            }));
        }

        void radio_SwEvent(int index, bool state)
        {
            swState[index - 1] = state;
            Console.WriteLine("1.index:" + index + " state:" + state);
            this.Invoke((Action)(() =>
            {
                switch (index)
                {
                    case 1:
                        if (state)
                            this.sw1Picture.Image = global::FMStream.Properties.Resources.ButtonRed;
                        else
                            this.sw1Picture.Image = global::FMStream.Properties.Resources.ButtonGreen;
                        Console.WriteLine("2.index:" + index + " state:" + state);
                        sw1Picture.Refresh();
                        break;
                    case 2:
                        if (state)
                            this.sw2Picture.Image = global::FMStream.Properties.Resources.ButtonRed;
                        else
                            this.sw2Picture.Image = global::FMStream.Properties.Resources.ButtonGreen;
                        sw2Picture.Refresh();
                        break;
                }
            }));
        }
        void radio_SlotEvent(int slot)
        {
            this.Invoke((Action)(() =>
            {
                this.slot.Text = slot.ToString();
            }));
           
        }
        
        void radio_ShutDownEvent(bool shutDownState)
        {
            this.Invoke((Action)(() =>
            {
                if (shutDownState)
                {
                    this.shutDownPicture.Image = global::FMStream.Properties.Resources.ButtonRed;
                    
                }
                else
                    this.shutDownPicture.Image = global::FMStream.Properties.Resources.ButtonGreen;
                shutDownPicture.Refresh();
            }));
        }
       
        void radio_RdsEvent(string rds)
        {
            this.Invoke((Action)(() =>
            {
                this.rds.Text = rds.ToString();
            }));
        }
        void radio_DataReceived(string data)
        {
            this.Invoke((Action)(() => { SerialRawText.AppendText(data + '\n'); }));
        }
        private void sendTune_Click(object sender, EventArgs e)
        {
            radio.SetFrequency(int.Parse(Frequency.Text));
        }
        private void seekTune_Click(object sender, EventArgs e)
        {
            radio.Seek();
        }
        private void Sw1_Click(object sender, EventArgs e)
        {
            swState[0] = !swState[0];
            radio.Sw(1, swState[0]);
        }
        private void Sw2_Click(object sender, EventArgs e)
        {
            swState[1] = !swState[1];
            radio.Sw(2, swState[1]);
        }

        private void slotButton_Click(object sender, EventArgs e)
        {
            radio.GetSlot();
        }

        private void rdsButton_Click(object sender, EventArgs e)
        {
            radio.GetRDS();
        }

        private void getTuneStatus_Click(object sender, EventArgs e)
        {
            radio.getTuneStatus();
        }
    }
}