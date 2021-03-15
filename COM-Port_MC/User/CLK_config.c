#include "CLK_config.h" 

#define _KEY_ 0x8555AAA1

void CLK_ini(void)
{
	// !!!!!! Запись в регистр ключа блока тактовых частот !!!!!!	
	CLK_CNTR->KEY = _KEY_;
	
	/* Функция установки CLKCTRL по умолчанию */
	CLKCTRL_DeInit();
	
	/* Функция конфигурирования HSE0 clock */
	CLKCTRL_HSEconfig(CLKCTRL_HSE0_CLK_ON);
   while(CLKCTRL_HSEstatus(CLKCTRL_HSEn_STAT_HSE0_RDY) != SUCCESS){}
	
//	/* Конфигурирование блока умножения тактовой частоты */
//	CLKCTRL_CPU_PLLconfig(PLL0, CLKCTRL_PLLn_CLK_SELECT_HSE0div1, 0, 6);//PLLn, SRC, Q, N
//   while(CLKCTRL_CPU_PLLstatus(0) != SUCCESS){}
//	CLKCTRL_MAX_CLKSelection(CLKCTRL_MAX_CLK_PLL0);
	CLKCTRL_MAX_CLKSelection(CLKCTRL_MAX_CLK_HSE0div1);	
}
