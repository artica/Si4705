using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FMStream
{
    public class PowerMessage
    {
        public string[] Keys;
        public double[] Values;
    }
	/// <SUMMARY>
	/// EchoServiceProvider. Just replies messages received from the clients.
	/// </SUMMARY>
    /// 
	public class FmStreamPowerMessageHandler
	{
		//private string _receivedStr;
        JsonTextReader jreader;
        public delegate void DataReceivedEventHandler(PowerMessage data);
        public event DataReceivedEventHandler DataReceived;
		public object Clone()
		{
            var res = new FmStreamPowerMessageHandler();
            res.DataReceived = this.DataReceived;
            return res;
		}

		public void OnAcceptConnection()
		{

            //var streamReader = new StreamReader(new NetworkStream(state.Conection));
            //jreader = new JsonTextReader(streamReader);

            //JsonTextReader reader = new JsonTextReader(new StringReader(json));

			//_receivedStr = "";
			//if(!state.Write(Encoding.UTF8.GetBytes("Hello World!\r\n"), 0, 14))
			//	state.EndConnection(); //if write fails... then close connection

		}
        private bool TryParseData(String data, out JObject result)
        {
            bool parseResult = false;
            JObject json = null;

            try
            {
                json = JObject.Parse(data);
                parseResult = true;
            }
            catch (Exception)
            {
                //Log it
            }

            result = json;
            return parseResult;

        }


        public void ReceiveData(string info)
		{

            //count += state.Read(buffer, count, state.Conection.Available);
            //var serializer = new JsonConvert.DeserializeObject<Message>();

            try
            {
                //string str = buffer.ToString();
                JObject o;
                if (TryParseData(info, out o))
                    Console.WriteLine("Parsed: "+ info);
                else
                    Console.WriteLine("Parse error: " + info);

                
                //Console.WriteLine(o.ToString());

                var data = o.ToObject<PowerMessage>();
                if (this.DataReceived != null)
                    DataReceived(data);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //ParseMessage(data);
            //DataReceived
            //serializer.JsonConvert.DeserializeObject<Message>(jreader);

            //JsonTextReader reader = new JsonTextReader(new StringReader(json));

          /*  while (reader.Read())
            {
                if (reader.Value != null)
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                else    Console.WriteLine("Token: {0}", reader.TokenType);
            }


           
			byte[] buffer = new byte[1024];
			while(state.AvailableData > 0)
			{
                
				int readBytes = state.Read(buffer, 0, 1024);
				if(readBytes > 0)
				{
                    state.Write(buffer, 0, readBytes);
					if(_receivedStr.IndexOf("<EOF>") >= 0)
					{
						state.Write(Encoding.UTF8.GetBytes(_receivedStr), 0,
							_receivedStr.Length);
						_receivedStr = "";
					}
				}
				else state.EndConnection(); //If read fails then close connection
			}
           */
		}


		public void OnDropConnection(IAsyncResult state)
		{
			//Nothing to clean here
		}
	}
}
