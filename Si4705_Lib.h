/* 

*/

#ifndef Si4705_Lib_h
#define Si4705_Lib_h

#include "Arduino.h"

typedef struct 
{
	bool valid;
	int tuneFrequency;
	char rssi;
	char snr;
	char antenaCap;
} TuneStatus;

class Si4705_Lib
{
  
  public:
	
    Si4705_Lib(int resetPin, int sdioPin, int sclkPin);
    int powerOn();					// call in setup
	int bytesCommand(int howmany, unsigned char* parameters);
	int readCommand(int howmany, unsigned char* result);
	int setVolume(char value); 
	byte getVolume();
	int setChannel(unsigned int channel);
	int getChannel(TuneStatus* status);
	int readRDS(unsigned char* message, long rdsTimeout);	
	int RDSConfig();
    int seek(byte seekDirection);
	void printBuffer(int howmany, unsigned char* buffer);
	void printTuneStatus(TuneStatus status);
	int getRev();
	int timeout;
    
  private:
    int  _resetPin;
	int  _sdioPin;
	int  _sclkPin;
	static const int  SI4705 = 0x63;
	char rds[100];
};

#endif