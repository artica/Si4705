/*
  AnalogReadSerial
  Reads an analog input on pin 0, prints the result to the serial monitor.
  Attach the center pin of a potentiometer to pin A0, and the outside pins to +5V and ground.
 
 This example code is in the public domain.
*/
#include <Metro.h>
#include <aJSON.h>
#include <SPI.h>
#include <Ethernet.h>
EthernetClient client;
aJsonStream stream(&client);

double sensorValue[3];
const char* keys[] = {"Analog 0 - DC in:", "Analog 1 - DC Out:", "Analog 2  - Bat In:"};
//A0
//x1 = 528
//y1 = 12v
//x2 = 659
//y2 = 15v
//A1
//x1 = 401
//y1 = 9v
//x2 = 667
//y2 = 15v
//A2
//x1 = 399
//y1 = 9v
//x2 = 600
//y2 = 13.5v
float scale[][2]={{0.023,-0.157},{0.0225,-0.0225},{0.0224,0.0624}};

Metro buzzerMetro   = Metro(700, true);
Metro netMetro      = Metro(500, true);
Metro resetNetMetro = Metro(5000, true);
Metro resetPiMetro  = Metro(5000, true);
Metro pinTestMetro  = Metro(5000, true);
int buzzerPin =3;
//Analog 3 - Enable 5 volts(0 enable 1 disable)
//Analog 4 - Enable 12 & 9 Volts (1 enable 0 disable)
//Analog5 - Terminal que diz se vamos desligar a alimentação de todo o sistema

//pin 7 Bat Very Low 
//pin 8 No Acid Power
//pin 9 Acid Power
/*
Pin 3 pwm - buzzer
Pin 5 - Battery BIcolor Led green pin 
Pin 7 - Battery BIcolor Led red pin
Pin 8 - Charge Bicolor Led red pin
Pin 9 - Charge BIcolor Led green pin
*/
#define ACIDPOWERINDEX 2
#define BATPOWERINDEX 0
//#define NOACIDPOWERINDEX 3
int outPins[] = {5,7,9,8,17,18,19};
int ouPinsOn[] = {0,0,0,0,0,1,1};
 
int currentTestPin =0;

bool resetStations = false;
 
void PowerUp()
{
 for(int count =0; count <7; count++)
   digitalWrite(outPins[count], !ouPinsOn[count]);
}
// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
  pinMode(buzzerPin, OUTPUT);
  for(int count =0; count <8; count++)
  {
    pinMode(outPins[count], OUTPUT);
    //digitalWrite(outPins[count], HIGH);
  }
  //digitalWrite(outPins[currentTestPin], LOW);
  PowerUp();
  digitalWrite(outPins[5], ouPinsOn[5]);
  digitalWrite(outPins[4], ouPinsOn[4]);
  delay(1000);
  Serial.println("Started");
  startNet();
  delay(1000);
  reConnectNet();
}
//
// the loop routine runs over and over again forever:

void loop() 
{
  
  // read the input on analog pin 0:
  for(int count =0; count <3; count++)
  {
    sensorValue[count] = (sensorValue[count]* 0.90) + (0.1*analogRead(count)*scale[count][0]+scale[count][1]);
    /*Serial.print("  ");
    Serial.print(keys[count]);
    Serial.print("  ");
    Serial.print(sensorValue[count]);*/
  }
  if (netMetro.check())
  {
    if (resetNetMetro.check())
    {
      reConnectNet(); 
    }
    aJsonObject* msg = createMessage(sensorValue, keys, 3);
    aJson.print(msg, &stream);
    client.print('\0');
    aJson.deleteItem(msg);
    
  }
  if (buzzerMetro.check())
  {  
    
     NoAc(sensorValue[0]<10);
     LowBat(sensorValue[1]<11.4); 
  }
  delay(10);        // delay in between reads for stability
  telnet();
  
}
boolean NoAc(boolean state)
{
  if(state)
  {
    tone(buzzerPin, 1000, 500);
    digitalWrite(outPins[ACIDPOWERINDEX+1], ouPinsOn[ACIDPOWERINDEX+1]);
    digitalWrite(outPins[ACIDPOWERINDEX], !ouPinsOn[ACIDPOWERINDEX]);
  }
  else
  {
     digitalWrite(outPins[ACIDPOWERINDEX+1], !ouPinsOn[ACIDPOWERINDEX+1]);
     digitalWrite(outPins[ACIDPOWERINDEX], ouPinsOn[ACIDPOWERINDEX]);
   }
   return state;
}

boolean LowBat(boolean state)
{
  if(state)
  {
   tone(buzzerPin, 4000, 500);
   // shutdown warning 
   if(!resetStations)
   {
     resetStations =! resetStations;
     digitalWrite(outPins[8], ouPinsOn[8]);
     resetPiMetro.reset();
   }
   if(resetPiMetro.check() && resetStations)
   {
     //resetStations != resetStations;
     digitalWrite(outPins[7], !ouPinsOn[7]);
     digitalWrite(outPins[6], !ouPinsOn[6]);
     resetPiMetro.reset();
   }
   digitalWrite(outPins[BATPOWERINDEX+1], ouPinsOn[BATPOWERINDEX+1]);
   digitalWrite(outPins[BATPOWERINDEX], !ouPinsOn[BATPOWERINDEX]);
  }
  else
  {
    resetStations =! false;
    digitalWrite(outPins[BATPOWERINDEX+1], !ouPinsOn[BATPOWERINDEX+1]);
    digitalWrite(outPins[BATPOWERINDEX], ouPinsOn[BATPOWERINDEX]);
  }
  return state;
}
 /* if (pinTestMetro.check())
  {
     
     digitalWrite(outPins[currentTestPin], HIGH);  
     currentTestPin++;
     currentTestPin = currentTestPin%8;
     digitalWrite(outPins[currentTestPin], LOW);
     Serial.println(currentTestPin);
  }
  delay(10000);
  */
  
  // print out the value you read:
  //Serial.println("******************************");