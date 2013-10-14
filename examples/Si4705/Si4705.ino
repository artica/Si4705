//DAR DE 1 A 20 QUAL ? A POSI??O; TESTAR A FALUTA DE CORRENTE;
//RESET DO ROUTER;

#include <Si4705_Lib.h>
#include <Wire.h>

String ledsMessage[] = {"sw1LedPin:","sw2LedPin","brdLed:"}; 
int ledsPin[] = {6,5,7};
int ipThreshold =15;
int ipRange[]={0,53, 93 ,155 ,208, 239 ,319, 366, 409, 465 ,512, 539, 608, 657, 735, 769, 837, 868};
bool ledsState[3] = {false,false,true};

int counter =0;
int resetPin = 2; 
int ipPin = A0;
int powerPin = A1;
int ip;
int power;
int SDIO = A4; //SDA/A4 on Arduino
int SCLK = A5; //SCL/A5 on Arduino
char printBuffer[50];

Si4705_Lib RADIO(resetPin, SDIO, SCLK);


unsigned char temp[32];
char parameters[32];

void setup(){
  Serial.begin(9600);
  //Serial.println("start setup!");
  if (RADIO.powerOn()<0)
    Serial.println("Power on error");
  //RADIO.readRegisters();
  RADIO.setVolume(0x3Fa);
  delay(100);
  if (RADIO.RDSConfig()<0)
    Serial.println("RDSConfig on error");
  //Serial.println("done setup!");
  //Serial.println();
  
  for(int count =0; count <3; count++)
  {
    pinMode(ledsPin[count], OUTPUT);
    digitalWrite(ledsPin[count], ledsState[count]);
  }
  //ledsState[counter] = !ledsState[counter];
  //digitalWrite(ledsPin[counter], ledsState[counter]);
  if(RADIO.setChannel(9740))
     Serial.println("setFreq Error");
}

//private enum RadioState { None = 'n', GetRDS='r', GetSlot='p', SetFrequency='f', GetTuneStatus='t',Sw='w', ShutDown='s', Error='e'};
TuneStatus tuneStat;
int frequency;
void loop()
{
  //Debug();
  processSerial();
}
void processSerial()
{
   if(Serial.available()>0)
  { 
    // call the returned value from GetFromSerial() function
    switch(GetFromSerial())
    {
      case 'r':  // rds
        Serial.print("r;");
        if(RADIO.readRDS(&temp[0], 2000 ))
          Serial.println("RDS ERROR");
        else
        {
          for(int count =0 ; count<13; count ++)
            Serial.print((char)temp[count]);
            Serial.println();
        }
        break;
      case 'p':  // GetSlot position
        Serial.print("p;");
        Serial.print(getSlotPosition(),DEC);
        Serial.println();
        break;
      case 'y':  // GetSlot position
        RADIO.seek(1);
        delay(2000);
        RADIO.getChannel(&tuneStat);
        Serial.print("y;");
        Serial.print(tuneStat.valid,DEC);
        Serial.print(';');
        Serial.print(tuneStat.tuneFrequency, DEC);
        Serial.print(';');
        Serial.print(tuneStat.tuneFrequency,DEC);
        Serial.print(';');
        Serial.print(tuneStat.rssi, DEC);
        Serial.print(';');
        Serial.print(tuneStat.snr, DEC);
        Serial.print(';');
        Serial.print(tuneStat.antenaCap, DEC);
        Serial.println();
        break;
        break;
      case 'f':  // SetFrequency
        frequency = Serial.parseInt();
        RADIO.setChannel(frequency);
        delay(1000);
        RADIO.getChannel(&tuneStat);
        Serial.print("f;");
        Serial.print(tuneStat.valid,DEC);
        Serial.print(';');
        Serial.print(tuneStat.tuneFrequency, DEC);
        Serial.print(';');
        Serial.print(tuneStat.tuneFrequency,DEC);
        Serial.print(';');
        Serial.print(tuneStat.rssi, DEC);
        Serial.print(';');
        Serial.print(tuneStat.snr, DEC);
        Serial.print(';');
        Serial.print(tuneStat.antenaCap, DEC);
        Serial.println();
        break;
      case 't':   //GetTuneStatus='t'
        RADIO.getChannel(&tuneStat);
        Serial.print("t;");
        Serial.print(tuneStat.valid,DEC);
        Serial.print(';');
        Serial.print(tuneStat.tuneFrequency, DEC);
        Serial.print(';');
        Serial.print(tuneStat.tuneFrequency,DEC);
        Serial.print(';');
        Serial.print(tuneStat.rssi, DEC);
        Serial.print(';');
        Serial.print(tuneStat.snr, DEC);
        Serial.print(';');
        Serial.print(tuneStat.antenaCap, DEC);
        Serial.println();
        break;
      case 'w': //Sw='w'
        int index;  
        if(GetFromSerial() == '1')
          index = 0;
        else 
          index=1;
        if(GetFromSerial() == '1')
          ledsState[index] = true;
        else 
          ledsState[index] = false;
        digitalWrite(ledsPin[index], ledsState[index]);
        Serial.print("w;");
        Serial.print(index+1,DEC);
        Serial.print(';');
        Serial.print(ledsState[index], DEC);
        Serial.println();
        break;
      }
  }
  if(analogRead(powerPin)>10)
  {
    Serial.println('s');
    delay(500);
  }
}

byte GetFromSerial()
{
  while (Serial.available()<=0) {
  }
  return Serial.read();
}
void Debug(){
  //Serial.println("Go Seek!");  
  //goSeek();
  //delay(5000);
  //Serial.println("RDS Status");  
  //getRDS();
  
  
  Serial.println("setFREQ - RENASCEN?A");  
  //setFreq(9940);
  //RADIO.seek(1);
  delay(3000);
  
  Serial.println("#");
  if (!RADIO.getChannel(&tuneStat))
    RADIO.printTuneStatus(tuneStat);
  else 
    Serial.println("get channel ERROR");
  //Serial.print("freq Status:");
  //Serial.println(freq);
  //RADIO.setVolume((int)random(0x3FA));

  Serial.println("get vol");
  Serial.println(RADIO.getVolume());
  Serial.println("RDS Status");
  
  //memset(temp,0,13);
  delay(2000);
  if(RADIO.readRDS(&temp[0], 1000 ))
	Serial.println("RDS ERROR");
  else
	RADIO.printBuffer(13, (unsigned char *)&temp[0]);

  counter++;
  counter= counter%3;
  //ledsState[counter] = !ledsState[counter];
  digitalWrite(ledsPin[counter], ledsState[counter]);
  Serial.print(ledsMessage[counter]);
  Serial.println(ledsState[counter]);
  
  int power = analogRead(powerPin);
  Serial.print("Power:");
  Serial.println(power);
  Serial.print("Ip:");
  Serial.println(getSlotPosition());
  delay(500);
  int ipPin = A0;
  int powerPin = A1;
  
}
int getSlotPosition()
{
  int lenght = sizeof(ipRange)/sizeof(int);
  int count =0;
  int ip = analogRead(ipPin);
  for(count =0; count < lenght; count++)
  { 
    if (abs(ipRange[count]-ip) < ipThreshold)
      break;
  }
  return count+1;
}