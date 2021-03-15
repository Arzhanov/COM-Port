#include "SendData.h"

uint16_t const numberChannelADC_voltage 		=	6;
uint16_t const numberChannelADC_temperature = 23;
uint16_t countQuantityADC_onChannel_6 = 0;
uint16_t countQuantityADC_onChannel_23 = 0;
uint16_t const countQuantityADC = 3;
uint32_t countForRepeatADC;

uint32_t ADCdata;
uint16_t channelADC;
uint16_t resultADC_FirstByte;
uint16_t resultADC_SecondByte;

uint16_t const maximumVoltage = 819;
uint16_t counterExceedingMaximumVoltage = 0;
uint16_t counterNotExceedingMaximumVoltage = 0;
uint16_t const orderFor_MaximumVoltage = 3;

void INT_ADC1_Handler(void)
{
	while(!(ADC1->STATUS & (1<<0)));
	ADCdata = (uint32_t)(ADC1->RESULT);																	
	
	resultADC_FirstByte = (uint16_t)(ADCdata & 0xFF);										
	resultADC_SecondByte = (uint16_t)((ADCdata & 0x0F00)>>8);
	channelADC = (uint16_t)((ADCdata & 0xFF0000) >> 16);								
	
	if (channelADC == numberChannelADC_temperature)											
	{
		if (countQuantityADC_onChannel_23 == countQuantityADC)						
		{
			while (UART_GetFlagStatus(MDR_UART0, UART_FLAG_TXFE ) != SET);
			//UART_ClearITPendingBit(MDR_UART0, UART_FLAG_TXFE);
			UART_SendData(MDR_UART0, (channelADC));
			UART_SendData(MDR_UART0, resultADC_FirstByte);
			UART_SendData(MDR_UART0, resultADC_SecondByte);
			
			for (uint8_t i = 0; i < 13; i++)
			{
				UART_SendData(MDR_UART0, (uint8_t)0x00);
			}
			
			countQuantityADC_onChannel_23 = 0;
		}
		else 
		{
			countQuantityADC_onChannel_23++;
		}	
	}
	else if (channelADC == numberChannelADC_voltage)										
	{
		if (countQuantityADC_onChannel_6 == countQuantityADC)							
		{
			ControlVoltage();
			
			while (UART_GetFlagStatus(MDR_UART0, UART_FLAG_TXFE ) != SET);
			//UART_ClearITPendingBit(MDR_UART0, UART_FLAG_TXFE);
			UART_SendData(MDR_UART0, (channelADC));
			UART_SendData(MDR_UART0, resultADC_FirstByte);
			UART_SendData(MDR_UART0, resultADC_SecondByte);
			
			for (uint8_t i = 0; i < 13; i++)
			{
				UART_SendData(MDR_UART0, (uint8_t)0x00);
			}
			
			countQuantityADC_onChannel_6 = 0;
		}
		else 
		{
			countQuantityADC_onChannel_6++;
		}	
	}
}

void INT_TMR0_Handler(void)
{
	if (TIMER_GetITStatus(MDR_TMR0, TIMER_STATUS_CNT_ARR_EVENT) == SET)
	{
		TIMER_ClearITPendingBit(MDR_TMR0, TIMER_STATUS_CNT_ARR_EVENT);
		ADC_Voltage_Start();
	}
}

void INT_TMR1_Handler(void)
{
	if (TIMER_GetITStatus(MDR_TMR1, TIMER_STATUS_CNT_ARR_EVENT) == SET)
	{
		TIMER_ClearITPendingBit(MDR_TMR1, TIMER_STATUS_CNT_ARR_EVENT);
		ADC_Temperature_Start();
	}
}

void ADC_Voltage_Start(void)
{
	for (countForRepeatADC = 0; countForRepeatADC <= countQuantityADC; countForRepeatADC++)
	{
		ADCx_SetChannel(ADC1, numberChannelADC_voltage);
		ADCx_Start(ADC1);
	}
}

void ADC_Temperature_Start(void)
{
	for (countForRepeatADC = 0; countForRepeatADC <= countQuantityADC; countForRepeatADC++)
	{
		ADCx_SetChannel(ADC1, numberChannelADC_temperature);
		ADCx_Start(ADC1);
	}
}

void ControlVoltage()
{
	uint16_t voltageValue = resultADC_FirstByte + (resultADC_SecondByte << 8);
	if (voltageValue > maximumVoltage)
	{
		if (counterExceedingMaximumVoltage == orderFor_MaximumVoltage)
		{
			DAC0->DATA = 0x000;
			
			UART_SendData(MDR_UART0, (uint8_t)0xFF);
			UART_SendData(MDR_UART0, (uint8_t)0xFF);
			UART_SendData(MDR_UART0, (uint8_t)0xFF);
			for (uint8_t i = 0; i < 13; i++)
			{
				UART_SendData(MDR_UART0, (uint8_t)0x00);
			}
			
			counterExceedingMaximumVoltage = 0;
		}
		else
		{
			counterExceedingMaximumVoltage++;
		}
	}
	else
	{
		counterNotExceedingMaximumVoltage++;
		if (counterNotExceedingMaximumVoltage == orderFor_MaximumVoltage)
		{
			counterNotExceedingMaximumVoltage = 0;
			counterExceedingMaximumVoltage = 0;
		}
	}
}
