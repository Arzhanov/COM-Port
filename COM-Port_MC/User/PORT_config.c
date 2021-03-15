#include "PORT_config.h" 

#define _KEY_ 0x8555AAA1	

void PORT_ini(void)
{
	/* Тактирование порта PORTB */
	CLKCTRL_PER0_CLKcmd(CLKCTRL_PER0_CLK_MDR_PORTB_EN, ENABLE);
		 
	// !!!!!! Запись в регистр ключа блока порта B. !!!!!!
	PORTB->KEY = _KEY_;
	
	/* Структура для инициализации портов */
	PORT_InitTypeDef PORT_InitStructure;
	
	/* Конфигурация PORTB пин 1 , 10 - 17 (Выводы МК для выставления напряжения внешнего ЦАП)*/
	PORT_InitStructure.PORT_Pin   = PORT_Pin_0 | PORT_Pin_1 | PORT_Pin_10 | PORT_Pin_11 | PORT_Pin_12 | PORT_Pin_13 | PORT_Pin_14 | PORT_Pin_15 | PORT_Pin_16 | PORT_Pin_17;
	PORT_InitStructure.PORT_SOE    = PORT_SOE_OUT;
	PORT_InitStructure.PORT_SPULLDOWN = PORT_SPULLDOWN_ON;
	PORT_InitStructure.PORT_SANALOG  = PORT_SANALOG_DIGITAL;
	PORT_InitStructure.PORT_SPD = PORT_SPD_OFF;
	PORT_InitStructure.PORT_SPWR = PORT_SPWR_10;
		 
	/*Применяем структуру*/
	PORT_Init(PORTB, &PORT_InitStructure);
}
