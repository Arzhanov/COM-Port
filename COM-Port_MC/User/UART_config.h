#ifndef UART_CONFIG_H
#define UART_CONFIG_H

#include "MDR1986VE8T.h"
#include "mdr32f8_port.h"
#include "mdr32f8_clkctrl.h"
#include "mdr32f8_uart.h"
#include "mdr32f8_config.h"

void UART_ini(void);
void UART_DeInit(MDR_UART_TypeDef* UARTx);
	
#endif 
