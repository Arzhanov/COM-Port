#include "TIMER_config.h"


void TIMER0_ini(void)
{
	CLKCTRL_PER0_CLKcmd(CLKCTRL_PER0_CLK_MDR_TMR0_EN, ENABLE);
	//TIM_CLK_en(TIM0, 0);
	TIMER_BRGInit(MDR_TMR0, TIMER_HCLKdiv1);
	
	
	TIMER_CntInitTypeDef timer_struct;
	
	timer_struct.TIMER_IniCounter = 0;
	timer_struct.TIMER_Prescaler = 0;
	timer_struct.TIMER_Period = 100000;
	timer_struct.TIMER_CounterMode = TIMER_CntMode_ClkFixedDir;
	timer_struct.TIMER_CounterDirection = TIMER_CntDir_Up;
	timer_struct.TIMER_EventSource = TIMER_EvSrc_None;
	timer_struct.TIMER_FilterSampling = TIMER_FDTS_TIMER_CLK_div_1;
	timer_struct.TIMER_ARR_UpdateMode = TIMER_ARR_Update_Immediately;
	timer_struct.TIMER_ETR_FilterConf = TIMER_Filter_1FF_at_TIMER_CLK;
	timer_struct.TIMER_ETR_Prescaler = TIMER_ETR_Prescaler_None;
	timer_struct.TIMER_ETR_Polarity = TIMER_ETRPolarity_NonInverted;
	timer_struct.TIMER_BRK_Polarity = TIMER_BRKPolarity_NonInverted;

	TIMER_CntInit(MDR_TMR0, &timer_struct);
	
	NVIC_EnableIRQ(TMR0_IRQn);
	TIMER_ITConfig(MDR_TMR0, TIMER_STATUS_CNT_ARR, ENABLE);
	
	TIMER_Cmd(MDR_TMR0, ENABLE);
}

void TIMER1_ini(void)
{
	CLKCTRL_PER0_CLKcmd(CLKCTRL_PER0_CLK_MDR_TMR1_EN, ENABLE);
	//TIM_CLK_en(TIM0, 0);
	TIMER_BRGInit(MDR_TMR1, TIMER_HCLKdiv1);
	
	
	TIMER_CntInitTypeDef timer_struct;
	
	timer_struct.TIMER_IniCounter = 99999;
	timer_struct.TIMER_Prescaler = 0;
	timer_struct.TIMER_Period = 100000;
	timer_struct.TIMER_CounterMode = TIMER_CntMode_ClkFixedDir;
	timer_struct.TIMER_CounterDirection = TIMER_CntDir_Up;
	timer_struct.TIMER_EventSource = TIMER_EvSrc_None;
	timer_struct.TIMER_FilterSampling = TIMER_FDTS_TIMER_CLK_div_1;
	timer_struct.TIMER_ARR_UpdateMode = TIMER_ARR_Update_Immediately;
	timer_struct.TIMER_ETR_FilterConf = TIMER_Filter_1FF_at_TIMER_CLK;
	timer_struct.TIMER_ETR_Prescaler = TIMER_ETR_Prescaler_None;
	timer_struct.TIMER_ETR_Polarity = TIMER_ETRPolarity_NonInverted;
	timer_struct.TIMER_BRK_Polarity = TIMER_BRKPolarity_NonInverted;

	TIMER_CntInit(MDR_TMR1, &timer_struct);
	
	NVIC_EnableIRQ(TMR1_IRQn);
	TIMER_ITConfig(MDR_TMR1, TIMER_STATUS_CNT_ARR, ENABLE);
	
	TIMER_Cmd(MDR_TMR1, ENABLE);
}
