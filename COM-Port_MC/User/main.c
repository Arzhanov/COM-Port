/*
Пояснение: контроллер принимает по UART число от 0 до 255. В соответствии с принятым числом 
должны быть включены пины (10 - 17) порта B, соединённые с восьмиразрядным ЦАП. Для этого, принятое
число temp конверитируется в массив bitVector двоичных символов ("0" или "1"). Затем происходит проверка каждого символа
массива - если символ равен "1", то включается пин, соответствующий данному разряду.
Пин 1 порта B сбрасывает и включает пин CS на ЦАП (КЛЮЧ) 
*/


#include "UART_config.h"
#include "PORT_config.h"
#include "CLK_config.h" 
#include "ADC_test.h" 
#include "DAC_config.h"
#include "TIMER_config.h"

#include "ReceiveData.h"
#include "SendData.h"

int main(void)
{
	CLK_ini();
	PORT_ini();
	UART_ini();
	ADC_ini();
	DAC_ini();
	TIMER0_ini();
	TIMER1_ini();
	
	while(1)
	{

	}
}
