#include "Arduino.h"
#include "Si4705_Lib.h"
#include "Wire.h"
 
Si4705_Lib::Si4705_Lib(int resetPin, int sdioPin, int sclkPin)
{
  _resetPin = resetPin;
  _sdioPin = sdioPin;
  _sclkPin = sclkPin;
  timeout =1000;
}


int Si4705_Lib::bytesCommand(int howmany, unsigned char* parameters)
{
    Wire.beginTransmission(SI4705);
    for(int i =0; i< howmany; i++)
       Wire.write(parameters[i]);
    byte ack = Wire.endTransmission();
    if(ack != 0) { //We have a problem!
        return(-1);
    }
    return(0);
}
//Read the entire register control set from 0x00 to 0x0F
int Si4705_Lib::readCommand(int howmany, unsigned char* result)
{
	long startTime = millis(); 
	Wire.requestFrom(SI4705, howmany); //We want to read howmany bytes.
    while(Wire.available() < howmany) 
		if (millis()-startTime > timeout)
			return -1; //Wait for 16 wordsto come back from slave I2C device
    for(int x = 0 ; x<howmany; x++) 
	{ //Read in these bytes   
        result[x] = Wire.read();        
    }
	// clean buffer
	while(Wire.available() >0 ) 
		Wire.read();
	return 0;
}
int Si4705_Lib::powerOn()
{
  pinMode(_resetPin, OUTPUT);
  pinMode(_sdioPin, OUTPUT); //SDIO is connected to A4 for I2C
  digitalWrite(_sdioPin, LOW); //A low SDIO indicates a 2-wire interface
  digitalWrite(_resetPin, LOW); //Put Si4705 into reset
  delay(10); //Some delays while we allow pins to settle
  digitalWrite(_resetPin, HIGH); //Bring Si4703 out of reset with SDIO set to low and SEN pulled high with on-board resistor
  delay(50); //Allow Si4703 to come out of reset
  Wire.begin();
  delay(100);
  Serial.println("PowerUp");
  char parameters[10];
  char tempBuffer[10];
  parameters[0]=0x01;
  parameters[1]=0xD0;//0xD0; //0x90 for GPO2 disabled
  parameters[2]=0x05;
  if(bytesCommand(3,(unsigned char *)parameters))
	return -1;
  delay(50);
  Serial.println("POWERED");
/*  parameters[0]=0x10;
  if(bytesCommand(1,(unsigned char *)parameters))
	return -1;
  if(readCommand(9, (unsigned char*)tempBuffer))
	return -2;
  Serial.println("REVISION-->");
  for (int count =0; count<9; count++ )
	Serial.println((unsigned char)tempBuffer[count],HEX);
  //Serial.println((unsigned char)tempBuffer[3],BIN);
  Serial.println("<--");
  
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x00;
  parameters[3]=0x01;
  parameters[4]=0x00;
  parameters[5]=0xC9;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x02;
  parameters[3]=0x01;
  parameters[4]=0x7E;
  parameters[5]=0xF4;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x02;
  parameters[3]=0x02;
  parameters[4]=0x01;
  parameters[5]=0x90;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x40;
  parameters[3]=0x00;
  parameters[4]=0x00;
  parameters[5]=0x3F;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x11;
  parameters[3]=0x00;
  parameters[4]=0x00;
  parameters[5]=0x01;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x40;
  parameters[3]=0x01;
  parameters[4]=0x00;
  parameters[5]=0x00;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x18;
  parameters[3]=0x00;
  parameters[4]=0x0;
  parameters[5]=0x31;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x18;
  parameters[3]=0x01;
  parameters[4]=0x00;
  parameters[5]=0x1E;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x11;
  parameters[3]=0x08;
  parameters[4]=0x00;
  parameters[5]=0x28;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x12;
  parameters[3]=0x00;
  parameters[4]=0x00;
  parameters[5]=0x8F;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x12;
  parameters[3]=0x01;
  parameters[4]=0x00;
  parameters[5]=0x1E;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x12;
  parameters[3]=0x02;
  parameters[4]=0x00;
  parameters[5]=0x06;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x12;
  parameters[3]=0x03;
  parameters[4]=0x00;
  parameters[5]=0x32;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x12;
  parameters[3]=0x04;
  parameters[4]=0x00;
  parameters[5]=0x18;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x12;
  parameters[3]=0x07;
  parameters[4]=0x00;
  parameters[5]=0xB2;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x13;
  parameters[3]=0x02;
  parameters[4]=0x00;
  parameters[5]=0x0A;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x13;
  parameters[3]=0x03;
  parameters[4]=0x00;
  parameters[5]=0x06;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x14;
  parameters[3]=0x00;
  parameters[4]=0x22;
  parameters[5]=0x6A;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x14;
  parameters[3]=0x01;
  parameters[4]=0x2A;
  parameters[5]=0x26;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x14;
  parameters[3]=0x02;
  parameters[4]=0x00;
  parameters[5]=0x14;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x14;
  parameters[3]=0x03;
  parameters[4]=0x00;
  parameters[5]=0x06;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x14;
  parameters[3]=0x04;
  parameters[4]=0x00;
  parameters[5]=0x14;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
 
  
  
  
  
  
  
  
  
  
  
   parameters[0]=0x20;
   parameters[1]=0x00;
   parameters[2]= 0X27;
   parameters[3]= 0XF6;
   parameters[4]= 0x00;
   //printBuffer(4, (unsigned char *)parameters);
   if(bytesCommand(5,(unsigned char *)parameters))
	return -1;
   delay(100);
   
   parameters[0]=0x14;
   //printBuffer(4, (unsigned char *)parameters);
   if(bytesCommand(1,(unsigned char *)parameters))
	return -1;
   delay(100);
   
   parameters[0]=0x22;
   parameters[1]=0x01;
   //printBuffer(4, (unsigned char *)parameters);
   if(bytesCommand(2,(unsigned char *)parameters))
	return -1;
   delay(100);
   if (readCommand(8,(unsigned char*)tempBuffer))
		return -1;
   if (tempBuffer[0] & 0x20)
	return -1;
   TuneStatus status; 
   status.valid = tempBuffer[1]&0x01;
   status.tuneFrequency = (unsigned char)tempBuffer[3];
   status.tuneFrequency += (unsigned char)tempBuffer[2]<<8;
   status.rssi = tempBuffer[4];
   status.snr = tempBuffer[5];
   status.antenaCap = tempBuffer[7];
   printTuneStatus(status);
   Serial.println("====================================");
  
  
  
  
  delay(5000);
  
 */
 // There is a debug feature that remains active in Si4704/05/3x-D60 firmware which can create periodic noise in
//audio. Silicon Labs recommends you disable this feature by sending the following bytes (shown here in
//hexadecimal form):
//0x12 0x00 0xFF 0x00 0x00 0x00 
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0xFF;
  parameters[3]=0x00;
  parameters[4]=0x00;
  parameters[5]=0x00;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -2;
  delay(50);
 //To disable the SNR-based stereo blend, set both the FM_BLEND_SNR_STEREO_THRESHOLD property
//(0x1804) and the FM_BLEND_SNR_MONO_THRESHOLD property (0x1805) to 0.
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x18;
  parameters[3]=0x04;
  parameters[4]=0x00;
  parameters[5]=0x00;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -2;
  delay(50);
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x18;
  parameters[3]=0x05;
  parameters[4]=0x00;
  parameters[5]=0x00;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -2;
  delay(50);
 //To disable the multipath-based stereo blend, set both the FM_BLEND_MULTIPATH_STEREO_THRESHOLD
//property (0x1808) and the FM_BLEND_MULTIPATH_MONO_THRESHOLD property (0x1809) to 100 (0x64)
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x18;
  parameters[3]=0x08;
  parameters[4]=0x00;
  parameters[5]=0x64;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -2;
  delay(50);
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x18;
  parameters[3]=0x09;
  parameters[4]=0x00;
  parameters[5]=0x64;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -2;

  delay(50);
  //Disable soft mute
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x13;
  parameters[3]=0x02;
  parameters[4]=0x00;
  parameters[5]=0x00;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -2;
  delay(50);
  // FM De-Emphasis.
  //01 = 50 µs. Used in Europe, Australia, Japan
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x11;
  parameters[3]=0x00;
  parameters[4]=0x00;
  parameters[5]=0x01;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -3;
  delay(50);
 /* parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x02;
  parameters[3]=0x02;
  parameters[4]=0x00;
  parameters[5]=0x01;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -3;
  delay(50);
  parameters[0]=0x13;
  parameters[1]=0x00;
  parameters[2]= 0x02;
  parameters[3]=0x02;
  if(bytesCommand(4,(unsigned char *)parameters))
	return -1;
	
  delay(10);
  memset(tempBuffer, 4, sizeof(char));
  if(readCommand(2, (unsigned char*)tempBuffer))
	return -2;
  Serial.println("prescale-->");
  int res = tempBuffer[2]<<8;
  res += tempBuffer[1];
  Serial.println(res);
  Serial.println((unsigned char)tempBuffer[2],HEX);
  Serial.println((unsigned char)tempBuffer[1],HEX);
  Serial.println("<--");
  delay(50);
  
  */
  //Antena input
  parameters[0]=0x12;
  parameters[1] =0x00;
  parameters[2]=0x11;
  parameters[3]=0x07;
  parameters[4]=0x00;
  parameters[5]=0x00;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -4;
  delay(50);

  return 0;
}
int Si4705_Lib::RDSConfig()
{
// RDS CONFIG - page 274 & 282
  char parameters[6];
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x15;
  parameters[3]=0x00;
  parameters[4]=0x00;
  parameters[5]=0x01;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -1;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x15;
  parameters[3]=0x01;
  parameters[4]=0x00;
  parameters[5]=0x04;
  if(bytesCommand(6,(unsigned char *)parameters))
	return -2;
  delay(100);
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x15;
  parameters[3]=0x02;
  parameters[4]=0xEF;
  parameters[5]=0x01;
  if (bytesCommand(6,(unsigned char *)parameters))
	return -3;
  delay(100);
  return 0;

}

int Si4705_Lib::setChannel(unsigned int channel)
{
   char parameters[5];
   parameters[0]=0x20;
   parameters[1]=0x00;
   parameters[2]= channel>>8;
   parameters[3]= channel;
   parameters[4]= 0x00;
   //printBuffer(4, (unsigned char *)parameters);
   if(bytesCommand(5,(unsigned char *)parameters))
	return -1;
   delay(10);
   return 0;
}
//Reads the current channel from READCHAN
//Returns a number like 973 for 97.3MHz
int Si4705_Lib::getChannel(TuneStatus* status) 
{
   char parameters[2];
   parameters[0]=0x22;
   parameters[1]=0x03;
   if(bytesCommand(2,(unsigned char *)parameters))
	return-1;
   delay(10);
   char temp[8];
   if (readCommand(8,(unsigned char*)temp))
		return -2;
   if (temp[0] & 0x20)
	return -1;
   
   status->valid = temp[1]&0x01;
   status->tuneFrequency = (unsigned char)temp[3];
   status->tuneFrequency += (unsigned char)temp[2]<<8;
   status->rssi = temp[4];
   status->snr = temp[5];
   status->antenaCap = temp[7];
   
   return 0;   
}

// 63 maximum
int Si4705_Lib::setVolume(char volume)
{
  char parameters[6];
  parameters[0]=0x12;
  parameters[1]=0x00;
  parameters[2]=0x40;
  parameters[3]=0x00;
  parameters[4]=0x00;
  // parameters[5]=0x3F; // maximum
  parameters[5] = volume;
  if(bytesCommand(6, (unsigned char *)parameters))
	return -1;
  delay(10);
  return 0;
  
}
int Si4705_Lib::getRev()
{
  char parameters[1];
  parameters[0]=0x10;
  if(bytesCommand(1,(unsigned char *)parameters))
	return -1;;
  delay(10);
  char tempBuffer[8];
  if(readCommand(8, (unsigned char*)tempBuffer))
	return -2;
  Serial.println(tempBuffer[2]);
  Serial.println(tempBuffer[3]);
  return (int)tempBuffer[3];
  
}
byte Si4705_Lib::getVolume()
{
  char parameters[4];
  parameters[0]=0x13;
  parameters[1]=0x00;
  parameters[2]=0x40;
  parameters[3]=0x00;
  if(bytesCommand(4,(unsigned char *)parameters))
	return -1;
  delay(10);
  char tempBuffer[4];
  if(readCommand(4, (unsigned char*)tempBuffer))
	return -2;
  return (byte)tempBuffer[3];
  
}
int Si4705_Lib::readRDS(unsigned char* buffer, long rdsTimeout)
{ 	
  char temp[24];  
  char parameters[2];
  parameters[0]=0x14;
  long startTime = millis();
  while(true) 
  {
	//Serial.println("+");
	bytesCommand(1,(unsigned char *)parameters);
	delay(10);
	readCommand(1,(unsigned char *)buffer);
	//Serial.println((unsigned char)buffer[0],HEX);
	if((millis()-startTime> timeout)||(buffer[0]^0x84 ==0))
		break;
  }
  parameters[0] = 0x24;
  parameters[1] = 0x01;
  int count =0;
  while(true)
  {
	//Serial.println("-");
	bytesCommand(2,(unsigned char *)parameters);
	delay(10);
	readCommand(13,(unsigned char *)&temp[0]);
	//PrintBuffer(13, (unsigned char *)&temp[0]);
	if (temp[1]&0x40 )
	{
		return-1;
	}
	if(!(temp[6]&0xF0)&&!(temp[12]))
	{
		//Serial.println("---");
		count+=2;
		//Serial.println((temp[7]&0x03)*2,DEC);
	    buffer[(temp[7]&0x03)*2]=temp[10];
		buffer[((temp[7]&0x03)*2)+1]=temp[11];
	}
	else if (temp[3]==0x00 || (millis()-startTime> timeout))
	{
		if (count==0)
		{
			//Serial.println(count);
			//printBuffer(13, (unsigned char *)&temp[0]);
			return-1;
		}
		break;
	}
	// else 
		// printBuffer(13, (unsigned char *)&temp[0]);
  }
  delay(10);
  return 0;
}


//Seeks out the next available station
//Returns zero if failed
int Si4705_Lib::seek(byte seekDirection)
{ 
  char parameters[2];
 
  parameters[0]=0x21;
  parameters[1]=(seekDirection?0x0C:0x04);
  if(bytesCommand(2,(unsigned char*)parameters))
	return -1;
  return 0;
}

void Si4705_Lib::printBuffer(int howmany, unsigned char* buffer)
{
  for(int i=0; i<howmany; i++){
    Serial.print("Regis[");
    Serial.print(i);
    Serial.print("] = ");
	Serial.print((char)buffer[i]);
	Serial.print(" ");
    Serial.print(buffer[i],HEX);
    Serial.print(":");
    Serial.println(buffer[i],BIN);
  }
}
void Si4705_Lib::printTuneStatus(TuneStatus status)
{
   Serial.print("Get Channel Valid: ");
   Serial.println(status.valid);
   Serial.print("Frequency: ");
   Serial.println(status.tuneFrequency);
   Serial.print("RSSI: ");
   Serial.println(status.rssi,DEC);
   Serial.print("snr: ");
   Serial.println(status.snr,DEC);
   Serial.print("Antena Capacitor: ");
   Serial.println(status.antenaCap,DEC);
}