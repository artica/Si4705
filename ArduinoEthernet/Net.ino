

 
byte mac[] = {0x90, 0xA2, 0xDA, 0x0D, 0x37, 0xE8};

IPAddress server(192,168,0,102);
int port = 4242; 

void telnet()
{
  // if there are incoming bytes available 
  // from the server, read them and print them:
  if(client.connected())
  {
    while (client.available()) 
    {
      char c = client.read();
      Serial.print(c);
    }
  }
  // as long as there are bytes in the serial queue,
  // read them and send them out the socket if it's open:
  while (Serial.available() > 0) {
    char inChar = Serial.read();
    if (client.connected()) {
      client.print(inChar); 
    }
  }

  // if the server's disconnected, stop the client:
  /* if (!client.connected()) {
    Serial.println();
    Serial.println("disconnecting.");
    client.stop();
    // do nothing:
    while(true);
  }*/
}
void startNet()
{
  if (Ethernet.begin(mac) == 0) 
  {
    Serial.println("Failed to configure Ethernet using DHCP");
  }
  else 
    Serial.println(Ethernet.localIP());
  delay(1000);
}
void reConnectNet()
{
  if(!client)
    startNet();
  client.stop();
  if (client.connect(server, port)) 
  {
    Serial.println("connected");
  }
  else 
  {
    // if you didn't get a connection to the server:
    Serial.println("connection failed");
  }
}