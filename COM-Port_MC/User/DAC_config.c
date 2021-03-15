#include "DAC_config.h"

#define _KEY_ 0x8555AAA1

void DAC_ini(void)
{
	CLKControl* clk = CLK_CNTR;	
	clk->PER1_CLK |= (1<<25)|(1<<26); //разрешить тактирование DAC0, DAC1
	clk->DAC0_CLK = (7999<<0)|(1<<16);	//FCLKDAC0 = HSI/8000 = 1 √ц
	clk->DAC1_CLK = (7999<<0)|(1<<16);	//FCLKDAC0 = HSI/8000 = 1 √ц
	
	DACxControl * dac0 = DAC0;	
	dac0->KEY = _KEY_;
	dac0->CONFIG0 = (1<<0) | (1<<1);
	dac0->DATA = 0x800;
	
	DACxControl * dac1 = DAC1;	
	dac1->KEY = _KEY_;
	dac1->CONFIG0 = (1<<0) | (1<<1);
	dac1->DATA = 0x800;
}
