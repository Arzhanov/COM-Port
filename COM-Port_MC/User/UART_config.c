#include "UART_config.h" 

void UART_ini(void)
{
	/* Структура для инициализации портов */
	PORT_InitTypeDef PORT_InitStructure;
	
	/* Структура для инициализации UART */
	UART_InitTypeDef UART_InitStructure;
	
	/* Тактирование UART0 */
	CLKCTRL_PER1_CLKcmd(CLKCTRL_PER1_CLK_MDR_UART0_EN, ENABLE);
	
	/* Конфигурация пинов 23(TX), 24(RX) PORTB (Выводы МК UART)*/
	PORT_InitStructure.PORT_Pin   = (PORT_Pin_23 | PORT_Pin_24);
	PORT_InitStructure.PORT_SFUNC  = PORT_SFUNC_5;
  PORT_InitStructure.PORT_SANALOG  = PORT_SANALOG_DIGITAL;
	PORT_InitStructure.PORT_SPWR = PORT_SPWR_10;
	
	/*Применяем структуру*/
  PORT_Init(PORTB, &PORT_InitStructure);
	
	UART_CLK_en(MDR_UART0, UART_CLKSRC_HSE0, UART_CLKdiv1);
	
	UART_DeInit(MDR_UART0);
	
		/* Конфигурация UART */	
  UART_InitStructure.UART_BaudRate                = 9600;
	//UART_InitStructure.UART_BaudRate                = 2400;
  UART_InitStructure.UART_WordLength              = UART_WordLength8b;
  UART_InitStructure.UART_StopBits                = UART_StopBits2;
  UART_InitStructure.UART_Parity                  = UART_Parity_Odd;
	//UART_InitStructure.UART_FIFOMode                = UART_FIFO_OFF;
	UART_InitStructure.UART_FIFOMode                = UART_FIFO_ON;
  UART_InitStructure.UART_HardwareFlowControl     = UART_HardwareFlowControl_RXE | UART_HardwareFlowControl_TXE;
	
	/* Применить структуру */
	UART_Init(MDR_UART0, &UART_InitStructure, 8000000);
	
	/* Включить UART0 */
	UART_Cmd(MDR_UART0,ENABLE);
	
	/* Разрешить прерывания по UART0 */
	NVIC_EnableIRQ(UART0_IRQn);
	
	/* Разрешить прерывание по приёму через UART0 */
	UART_ITConfig (MDR_UART0, UART_IT_RX, ENABLE);
	
//	/* Разрешить прерывание по передаче через UART0 */
//	UART_ITConfig (MDR_UART0, UART_IT_TX, ENABLE);
}
