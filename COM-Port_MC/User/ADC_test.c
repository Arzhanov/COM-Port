#include "ADC_test.h"

#define _KEY_ 0x8555AAA1

void ADC_ini(void)
{
	/* Тактирование ADC1 */
	CLKCTRL_PER1_CLKcmd(CLKCTRL_PER1_CLK_MDR_ADC1_EN, ENABLE);
	CLKControl* clk2 = CLK_CNTR;	
	clk2->PER1_CLK |= (1<<23); 
	clk2->ADC1_CLK = (1<<16);
	
	/* Тактирование порта PORTC */
//	CLKCTRL_PER0_CLKcmd(CLKCTRL_PER0_CLK_MDR_PORTC_EN, ENABLE);
	CLKControl* clk1 = CLK_CNTR;	
	clk1->PER0_CLK |= (1<<15);

	ADC1->KEY = _KEY_;
	PORTC->KEY = _KEY_;
	
	PORT_InitTypeDef PORT_InitStructure;
	
	/* Конфигурация PORTC пин 10 (Вывод МК 120)*/
	PORT_InitStructure.PORT_Pin   = PORT_Pin_12;
	PORT_InitStructure.PORT_SOE    = PORT_SOE_IN;
	PORT_InitStructure.PORT_SANALOG  = PORT_SANALOG_ANALOG;
		 
	/*Применяем структуру*/
	PORT_Init(PORTC, &PORT_InitStructure);
	
	ADCx_InitTypeDef ADC_InitStructure;
	
	ADCx_StructInit(&ADC_InitStructure); //Инициализация значениями по умолчанию
	
	ADC_InitStructure.ADC_WORKMODE = 0;
	ADC_InitStructure.ADC_REFMODE = 0; 
	ADC_InitStructure.ADC_RH_MODE = 0;
	ADC_InitStructure.ADC_SELMODE = 0; 	
	ADC_InitStructure.ADC_EXT_GO_INV = 0;
	ADC_InitStructure.ADC_EXT_GO_SEL = 0;
	/* CONFIG1 */
	ADC_InitStructure.ADC_REFTRIM = 0;
	ADC_InitStructure.ADC_SETUP = 200; 
	ADC_InitStructure.ADC_PAUSE = 200;
	ADC_InitStructure.ADC_ADCTRIM = 0;
	/* CONFIG2 */	
	ADC_InitStructure.ADC_IE_NE = ENABLE;
	ADC_InitStructure.ADC_IE_OF = DISABLE; 
	ADC_InitStructure.ADC_IE_NAE = DISABLE;
	ADC_InitStructure.ADC_IE_AF = DISABLE;
	ADC_InitStructure.ADC_IE_ERFIN = DISABLE;
	ADC_InitStructure.ADC_LEVLCNTRL = 0; 
	ADC_InitStructure.ADC_REFSEL = 0;
	ADC_InitStructure.ADC_REF_TRIMR = 0;
	ADC_InitStructure.ADC_DT_MODE = 1;

	ADC_InitStructure.ADC_FIFOEN_0_31 = 0;
	ADC_InitStructure.ADC_FIFOEN_32_63= 0;
	
	ADC_Init(ADC1, &ADC_InitStructure);
	
	ADC1->FIFOEN0 = (1<<6) | (1<<23);
//	ADC1->FIFOEN0 = (1<<6);

	NVIC_EnableIRQ(ADC1_IRQn);

	ADCx_Cmd(ADC1, ENABLE);
}
