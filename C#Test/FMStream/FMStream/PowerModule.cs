using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Analog 0 - DC in 
Analog 1 - DC Out
Analog 2  - Bat In
Pin 3 pwm - buzzer
Pin 5 - Bat ok
pin 6 Bat low 
pin 7 Bat Very Low 
pin 8 No Acid Power
pin 9 Acid Power
Analog 3 - Enable 5 volts
Analog 4 - Enable 12 & 9 Volts

 */ 
namespace FMStream
{
    public class PowerModule
    {
        //private TcpServer server;
        public FmStreamPowerMessageHandler PowerComProvider { get; private set;}
        public FmPowerServer server;
        //public event FMStream.FmStreamPowerMessageHandler.DataReceivedEventHandler DataReceived;
       // public delegate void DataReceivedEventHandler(FmStreamPower.Message data);
       // public event FmStreamPower.DataReceivedEventHandler DataReceived;

        public PowerModule()
        {
            PowerComProvider = new FmStreamPowerMessageHandler();
            server = new FmPowerServer(PowerComProvider);
            var t = Task.Factory.StartNew(() => server.StartListening()); 
       
            //server = new TcpServer(PowerComProvider, 4242);
            //server.Start();
        }
    }
}
