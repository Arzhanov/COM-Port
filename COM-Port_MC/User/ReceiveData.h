#ifndef RECEIVE_DATA_H
#define RECEIVE_DATA_H

#include "MDR1986VE8T.h"
#include "mdr32f8_port.h"
#include "mdr32f8_uart.h"

void CheckAddress(void);
void SelectAGCorFGC(void);
void ApplyReferenceVoltageAGCorFGC(void);
void ConvertReceiveByteToUint16(void);




//void PIN_OFF(void);
//void PIN_ON(void);
//void fromDECtoBIN(void);
//void ApplyReferenceVoltageAGCorFGC(void);

//char bitVector[8];
//uint8_t ReciveByte[16];

#endif 

