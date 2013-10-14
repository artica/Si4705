/*
void initRadio()
{
  Serial.println("started");
  
  //RADIO.RDSConfig();
  //char rds[16];
  //RADIO.readRDS(rds, 10000);
  delay(50);
  
  Serial.println("set volume");
  RADIO.setVolume(0x3Fa);

  Serial.println("get vol");
  Serial.println(RADIO.getVolume());
  delay(10);
  RADIO.getRev();
  // SOFT MUTE
  
  
 
  
  delay(1000);
}
*/
/*
void getRDS(){   
  Serial.println("getRDS:");
   parameters[0]=0x24;
   parameters[1]=0x01;
   //parameters[2]=0x01;
   RADIO.bytesCommand(2,(unsigned char*) parameters);
   //delay(1000);
   
   //parameters[0]=0x22;
   //RADIO.bytesCommand(1,parameters);
   //delay(10);
   RADIO.readCommand(13,&temp[0]);
   Radio.PrintBuffer(13, &temp[0]);
   PrintRDS((char*)&temp[0],4,11);
  //delay(1000);

}*/
/*
void setFreq(int freq){   
   if(RADIO.setChannel(freq))
     Serial.println("setFreq Error");
   Serial.print("get tune status:");
   delay(100);
   TuneStatus tStat;
   RADIO.getChannel(&tStat);
   Serial.println(tStat.tuneFrequency);
}

void goSeek(){
  Serial.println("go seek");
  parameters[0]=0x21;
  parameters[1]=0x0C;
  RADIO.bytesCommand(2,(unsigned char*)parameters);
  delay(1000);
  Serial.println("get seek status:");
  parameters[0]=0x22;
  RADIO.bytesCommand(1,(unsigned char*)parameters);
    delay(10);
   Serial.println();
   
   RADIO.readCommand(8,&temp[0]);
   RADIO.printBuffer(8, &temp[0]);
   delay(1000);
  
}

void PrintRDS(char*buffer, int initial,int ending)
{
  for (int i=0; i < ending-initial; i++)
    Serial.print((char)buffer[i+initial]);
  Serial.println();
}
*/
/*
void PrintBuffer(int howmany, unsigned char* buffer){
  for(int i=0; i<howmany; i++){
    Serial.print("Regis[");
    Serial.print(i);
    Serial.print("] = ");
    Serial.print(buffer[i],DEC);
    Serial.print(":");
    Serial.println(buffer[i],BIN);
  }
}

void getSoftMute(){
   Serial.println("get softMute");    
   parameters[0]=0x13;
   parameters[1]=0x00;
   parameters[2]=0x13;
   parameters[3]=0x02;
   RADIO.bytesCommand(4,(unsigned char*)parameters);
   delay(10);
   Serial.println("print:");
   RADIO.readCommand(1,&temp[0]);
   RADIO.printBuffer(1, &temp[0]);
  delay(1000);
}*/