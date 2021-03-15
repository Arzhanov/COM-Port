#include "ReceiveData.h"

uint8_t ReciveByte[16];
uint16_t RecieveValue = 0;


void INT_UART0_Handler(void)
{	
	while (UART_GetFlagStatus(MDR_UART0, UART_FLAG_RXFF ) != SET);
	UART_ClearITPendingBit(MDR_UART0, UART_FLAG_RXFF);
	/* Recive data */
	for (uint8_t i = 0; i < 16; i++) {																	
		ReciveByte[i] = UART_ReceiveData(MDR_UART0);											
	}
	CheckAddress();
	
//	ApplyReferenceVoltageAGCorFGC(); 
}

void CheckAddress()
{
	switch (ReciveByte[0])
	{
		case 0x01:
			SelectAGCorFGC();
			break;
		case 0x02:
			ApplyReferenceVoltageAGCorFGC();
			break;
	}
}

void SelectAGCorFGC()
{
	if (ReciveByte[2] == 0x00)
		PORT_ResetBits(PORTB, PORT_Pin_0);		//Enable mode FGC
	if (ReciveByte[2] == 0x01)
		PORT_SetBits(PORTB, PORT_Pin_0);			//Enable mode AGC
}

void ApplyReferenceVoltageAGCorFGC()
{
	ConvertReceiveByteToUint16();
	DAC0->DATA = RecieveValue;
}

void ConvertReceiveByteToUint16()
{
	RecieveValue = ((ReciveByte[1] & 0x0F) << 8);
	RecieveValue |= (ReciveByte[2] & 0xFF);
}

//void PIN_OFF()
//{
//	PORT_ResetBits(PORTB, PORT_Pin_10);
//	PORT_ResetBits(PORTB, PORT_Pin_11);
//	PORT_ResetBits(PORTB, PORT_Pin_12);
//	PORT_ResetBits(PORTB, PORT_Pin_13);
//	PORT_ResetBits(PORTB, PORT_Pin_14);
//	PORT_ResetBits(PORTB, PORT_Pin_15);
//	PORT_ResetBits(PORTB, PORT_Pin_16);
//	PORT_ResetBits(PORTB, PORT_Pin_17);
//	
//	PORT_ResetBits(PORTB, PORT_Pin_1);
//}


//void PIN_ON()
//{
//	fromDECtoBIN();														
//	if (bitVector[0] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_10);
//	if (bitVector[1] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_11);
//	if (bitVector[2] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_12);
//	if (bitVector[3] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_13);
//	if (bitVector[4] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_14);
//	if (bitVector[5] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_15);
//	if (bitVector[6] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_16);
//	if (bitVector[7] == 1)
//		PORT_SetBits(PORTB, PORT_Pin_17);
//	
//		PORT_SetBits(PORTB, PORT_Pin_1);
//}


//void fromDECtoBIN()
//{ 
//		uint8_t data = ReciveByte[2];
//		uint8_t i;
//		for (i = 0; i < 8; i++)
//		{
//			bitVector[i] = 0;
//		}
//		i = 0;
//		while (data != 0)
//		{
//			if (data % 2 == 0)
//			{
//				bitVector[i] = 0;
//				data = data / 2;
//			}
//			else
//			{
//				bitVector[i] = 1;
//				data = data / 2;
//			}
//			i++;
//		}
//}

//void ApplyReferenceVoltageAGCorFGC()
//{
//	PIN_OFF();																							
//	PIN_ON();																								
//}

