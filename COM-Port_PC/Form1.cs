//  AGC - Automatic Gain Control (Режим автоматической регулировки усиления)
//  FGC - Fixed Gain Control (Режим фиксированной регулировки усиления)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace COM_порт
{
    public partial class FormControl : Form
    {
        FormPortSetting formPortSetting;            //  Объект класса FormPortSetting (Для выбора порта)
        COMPort port;                               //  Объект класса COMport (Для передачи/приёма данных)

        byte[] arrayDataForSendPort;                //  Данные для записи в порт
        const int lengthArrayDataForSendPort = 16;   //  Длина массива arrayDataForSendPort (Колличество байт передаваемых по UART)

        const byte addressReferenceVoltageAGCorFGC = 0x02;      //  Адрес для передачи значения опорного напряжения АРУ / ФРУ
        const byte addressSelectAGCorFGC = 0x01;                //  Адрес для передачи значения переключения режима АРУ / ФРУ

        const ushort _enableModeAGC = 0x0001;                       //  Значение для активации режима АРУ
        const ushort _enableModeFGC = 0x0000;                       //  Значение для активации режима ФРУ


        public static string messageFromSerialPort;

        public FormControl()
        {
            InitializeComponent();

            port = new COMPort();                           //  Инициализация объекта класса COMPort
            formPortSetting = new FormPortSetting();        //  Инициализация объекта класса formPortSetting
            panelBoxFGC.Enabled = false;                    //  Закрывается доступ к режиму ФРУ, доступ к режиму АРУ открыт (начальное условие)
        }

        /*  Конвертирование числа типа "ushort" в массив данных типа "byte"
         */
        public byte[] UShortToTwoBytes(ushort value)
        {
            byte[] buffer = new byte[]
            {
                (byte)((value >> 8) & 0xff),
                (byte)(value & 0xff),
            };
            return buffer;
        }

        /*  Подготовка данных для отправки в COM-порт.
         *  Данные для отправки в COM-порт состоят из массива размером 3 байта
         *  1-й байт это "адрес", назначение отправляемых данных
         *  2-й и 3-й байты это отправляемое значение (число)
         *  Все эти байты записываются в массив arrayDataForSendPort.
         */
        public void ToPrepareDataForSendPort(ushort value, byte address)
        {
            arrayDataForSendPort = new byte[lengthArrayDataForSendPort];
            byte[] arrayValue = UShortToTwoBytes(value);

            arrayDataForSendPort[0] = address;
            arrayDataForSendPort[1] = arrayValue[0];
            arrayDataForSendPort[2] = arrayValue[1];
        }

        /*  Обработчик события вызывается при иcпользовании Scroll в режиме АРУ.
         *  trackBarAGC.Value - значение Scroll в режиме АРУ
         */
        private void trackBarAGC_Scroll(object sender, EventArgs e)     
        {
            ushort valueTrackBarAGC = Convert.ToUInt16(trackBarAGC.Value);
            ToPrepareDataForSendPort(valueTrackBarAGC, addressReferenceVoltageAGCorFGC);    //  Подготовить данные для записи в COM-порт (Передачи по UART)
            if (port.SendValueToSerialPort(arrayDataForSendPort))
            {                                                                               //  Если данные успешно записаны в COM-порт
                labelValueAGC.Text = "Введено значение " + String.Format("{0:F2}", (trackBarAGC.Value * scaleVoltage)) + " V";               //  Показать записанные данные
                labelValueAGC.ForeColor = Color.Green;
            }
            else
            {                                                                               //  Если не удалось записать данные в COM-порт
                labelValueAGC.Text = "COM-порт не найден";
                labelValueAGC.ForeColor = Color.Red;
            }
        }


        /*  Обработчик события вызывается при иcпользовании Scroll в режиме ФРУ
         *  trackBarAGC.Value - значение "регулятора" в режиме ФРУ
         */
        private void trackBarFGC_Scroll(object sender, EventArgs e)        
        {
            ushort valueTrackBarFGC = Convert.ToUInt16(trackBarFGC.Value);
            ToPrepareDataForSendPort(valueTrackBarFGC, addressReferenceVoltageAGCorFGC);    //  Подготовить данные для записи в COM-порт (Передачи по UART)
            if (port.SendValueToSerialPort(arrayDataForSendPort))
            {                                                                               //  Если данные успешно записаны в COM-порт
                labelValueFGC.Text = "Введено значение " + string.Format("{0:F2}", (trackBarFGC.Value * scaleVoltage)) + " V";               //  Показать записанные данные
                labelValueFGC.ForeColor = Color.Green;
            }
            else
            {                                                                               //  Если не удалось записать данные в COM-порт
                labelValueFGC.Text = "COM-порт не найден";
                labelValueFGC.ForeColor = Color.Red;
            }
        }


        /*  Данный обработчик события вызывается
         *  при переключении режимов работы АРУ/ФРУ.
         *  При переключении режима необходимо сбросить 
         *  значение Scroll и передать 0 в последовательный 
         *  порт.
         */
        private void buttonSelectAGCorFGC_Click(object sender, EventArgs e)
        {
            if ((panelBoxAGC.Enabled == true) && (panelBoxFGC.Enabled == false))
            {                                               //  Если включен режим АРУ
                EnableModeFGC();                            //  Включить режим ФРУ (Передать данные на МК)
                panelBoxAGC.Enabled = false;                //  Выключение режима АРУ
                panelBoxFGC.Enabled = true;                 //  Включение режима ФРУ
                ResetValue(trackBarFGC, labelValueFGC);     //  Сбросить значения
                labelValueAGC.Text = "";                    //  Убрать значение trackBarAGC
            }
            else
            {                                               //  Если включен режим ФРУ
                EnableModeAGC();                            //  Включить режим АРУ (Передать данные на МК)
                panelBoxAGC.Enabled = true;                 //  Включение режима АРУ
                panelBoxFGC.Enabled = false;                //  Выключение режима ФРУ
                ResetValue(trackBarAGC, labelValueAGC);     //  Сбросить значения
                labelValueFGC.Text = "";                    //  Убрать значение trackBarFGC
            }
        }

        private void EnableModeAGC()
        {
            ToPrepareDataForSendPort(_enableModeAGC, addressSelectAGCorFGC);    //  Подготовить данные для записи в COM-порт (Передачи по UART)
            if (!port.SendValueToSerialPort(arrayDataForSendPort))              //  Если данные успешно записаны в COM-порт 
                MessageBox.Show("Не удалось переключить режим");
        }

        private void EnableModeFGC()
        {
            ToPrepareDataForSendPort(_enableModeFGC, addressSelectAGCorFGC);    //  Подготовить данные для записи в COM-порт (Передачи по UART)
            if (!port.SendValueToSerialPort(arrayDataForSendPort))              //  Если данные успешно записаны в COM-порт 
                MessageBox.Show("Не удалось переключить режим");                
        }

        /*  Метод сбрасывает значения Scroll и передаёт в порт значение 0 
         */
        public void ResetValue(TrackBar trackBar, Label label)
        {
            ushort valueReset = 0;
            ToPrepareDataForSendPort(valueReset, addressReferenceVoltageAGCorFGC);    //  Подготовить данные для записи в COM-порт (Передачи по UART)
            if (port.SendValueToSerialPort(arrayDataForSendPort))
            {                                                               //  Если данные успешно записаны в COM-порт     
                trackBar.Value = 0;                                         //  Выставить значение trackBar в 0
                label.Text = "Введено значение " + trackBar.Value;          //  Показать записанные данные
                label.ForeColor = Color.Green;
            }
            else
            {                                                               //  Если не удалось записать данные в COM-порт
                label.Text = "COM-порт не найден";
                label.ForeColor = Color.Red;
            }
        }


        static int countQuantityData_onChannel_6;       //  Счётчик количества принятых значений напряжения (для усреднения)
        static int countQuantityData_onChannel_23;      //  Счётчик количества принятых значений температуры (для усреднения)
        static uint sumData_onChannel_6;                //  Сумма значений напряжения (для усреднения)
        static uint sumData_onChannel_23;               //  Сумма значений температуры (для усреднения)
        static int orderAverage = 3;                   //  Порядок усреднения результата АЦП (Количество суммируемых значений) 
        static double scaleVoltage = 0.0012207;         //  Коэффициент для преобразования значения АЦП в напряжение (При U = 5 В)
       
        /*  Коэффициенты для калибровки значения АЦП по каналу 23 (Температура) */
        private float CALIBR_CONST_T1 = 25.2F;          //  Температура в первой точке
        private float CALIBR_CONST_T2 = 60.9F;          //  Температура во второй точке
        int CALIBR_CONST_D1 = 1117;                     //  Результат цифро-аналогового преобразования в первой точке
        int CALIBR_CONST_D2 = 1050;                     //  Результат цифро-аналогового преобразования во второй точке

        /// <summary>
        /// Выводит результаты АЦП на форму
        /// </summary>
        /// <param name="channelADC">Канал по которому выполнено АЦП</param>
        /// <param name="resultADC">Результат АЦП</param>
        public void ShowRecieveDataOnUART(byte channelADC, ushort resultADC)
        {
            if (channelADC == 6)
            {                                                                                                           //  Если данные пришли по каналу 6 (Напряжение)
                countQuantityData_onChannel_6++;                                                                        //  Инкрементирование счётчика
                sumData_onChannel_6 += (uint)resultADC;                                                                 //  Суммирование данных (для усреднения)
                if (countQuantityData_onChannel_6 == orderAverage)                                                      //  Если по каналу 6 принято "orderAverage" преобразований АЦП
                {
                    double averageResult_onChannel_6 = Convert.ToDouble((double)sumData_onChannel_6 / orderAverage);    //  Вычислить среднее значение принимаемых данных

                    sumData_onChannel_6 = 0;                                                                            //  Обнулить сумму
                    countQuantityData_onChannel_6 = 0;                                                                  //  Обнулить счётчик
                    double voltage = (averageResult_onChannel_6 * scaleVoltage);                                        //  Вычислить значение напряжения

                    string stringResultADC = String.Format("{0:F2}", voltage) + " V";                                   //  Преобразовать значение напряжения в строку
                    //string stringChannelADC = String.Format("{0:d}", channelADC) + " канал";                          //  Преобразовать номер канала в строку

                    ShowValueOnLabel(stringResultADC, labelVoltage);                                                    //  Вывести строку со значением на элемент формы в потокобезопасном режиме
                    //ShowValueOnLabel(stringChannelADC, labelChannelVoltage);                                          //  Вывести строку с номером канала на элемент формы в потокобезопасном режиме
                }
            }

            if (channelADC == 23)                                                                                       //  Если данные пришли по каналу 23 (Температура)
            {
                countQuantityData_onChannel_23++;                                                                       //  Инкрементирование счётчика
                sumData_onChannel_23 += (uint)resultADC;                                                                //  Суммирование данных (для усреднения)
                if (countQuantityData_onChannel_23 == orderAverage)                                                     //  Если по каналу 23 принято "orderAverage" преобразований АЦП
                {
                    double averageResult_onChannel_23 = Convert.ToDouble((double)sumData_onChannel_23 / orderAverage);  //  Вычислить среднее значение принимаемых данных

                    sumData_onChannel_23 = 0;                                                                           //  Обнулить сумму
                    countQuantityData_onChannel_23 = 0;                                                                 //  Обнулить счётчик
                    double temperature = ((averageResult_onChannel_23 - CALIBR_CONST_D1) * (CALIBR_CONST_T2 - CALIBR_CONST_T1) / (CALIBR_CONST_D2 - CALIBR_CONST_D1) + CALIBR_CONST_T1) + 7;  //  Вычислить значение температуры

                    string stringResultADC = String.Format("{0:F2}", temperature) + " °С";                              //  Преобразовать значение температуры в строку
                    //string stringChannelADC = String.Format("{0:d}", channelADC) + " канал";                          //  Преобразовать номер канала в строку

                    ShowValueOnLabel(stringResultADC, labelTemperature);                                                //  Вывести строку со значением на элемент формы в потокобезопасном режиме
                    //ShowValueOnLabel(stringChannelADC, labelChannelTemperature);                                      //  Вывести строку с номером канала на элемент формы в потокобезопасном режиме
                }
            }

            if (channelADC == 255)
            {
                //panelBoxAGC.Enabled = false;
                if (panelBoxAGC.InvokeRequired)
                    panelBoxAGC.Invoke((MethodInvoker)delegate { panelBoxAGC.Enabled = false; });
                else
                    panelBoxAGC.Enabled = false;

                if (trackBarAGC.InvokeRequired)
                    trackBarAGC.Invoke((MethodInvoker)delegate { trackBarAGC.Value = 0; });
                else
                    trackBarAGC.Value = 0;
                ShowValueOnLabel("0 V", labelValueAGC);

                //if (trackBarAGC.InvokeRequired)
                //    trackBarAGC.Invoke((MethodInvoker)delegate { trackBarAGC.Enabled = true; });
                //else
                //    trackBarAGC.Enabled = true;

                //if (trackBarFGC.InvokeRequired)
                //    trackBarFGC.Invoke((MethodInvoker)delegate { trackBarFGC.Value = 0; });
                //else
                //    trackBarFGC.Value = 0;
                //ShowValueOnLabel("0 V", labelValueFGC);

                
            }
        }

        /// <summary>
        /// Выводит результаты АЦП на форму в потокобезопасном режиме
        /// </summary>
        /// <param name="value">Значение для вывода на форму</param>
        /// <param name="label">Элемент управления на форме, на которую выводится значение</param>
        private void ShowValueOnLabel(string value, Label label)
        {
            if (label.InvokeRequired)
                label.Invoke((MethodInvoker)delegate { label.Text = value; });
            else
                label.Text = value;
        }

        /// <summary>
        /// Обработчик события приёма данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void receivedDataOnUART_Event(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };                    //  Буффер принимаемых данных
            COMPort.port.Read(buffer, 0, 3);                            //  Записать принятые данные в буффер
            byte channelADC = buffer[0];                                //  Номер канала 
            ushort resultADC = BitConverter.ToUInt16(buffer, 1);        //  Результат АЦП
            ShowRecieveDataOnUART(channelADC, resultADC);               //  Передача данных для отображения на форме
            COMPort.port.DiscardInBuffer();                             //  Очистить входной буффер
        }

        static private bool flagButtonStartReceive = false;          //  false - приём данных отключен; true - приём данных включен

        /*  Обработчик события нажатия на кнопку "Начать приём/Завершить прём"  */
        private void buttonStartReceive_Click(object sender, EventArgs e)
        {
            if (flagButtonStartReceive)
            {                                                       //  Если приём данных открыт (Обработчик события приёма данных существует)
                if (StopReceive())                                  //  Если порт открыт
                {
                    flagButtonStartReceive = false;                 //  Флаг - приём данных отключен
                    buttonStartReceive.Text = "Начать приём";       //  Смена надписи на кнопке
                    labelVoltage.Text = "";                         //  Очистить элемент формы
                    labelTemperature.Text = "";                     //  Очистить элемент формы
                }
                else
                    MessageBox.Show("Ошибка: порт закрыт");         //  Если порт закрыт
            }
            else
            {                                                       //  Если приём данных закрыт (Обработчик события приёма данных не существует)
                if (StartReceive())                                 //  Если порт открыт
                {
                    flagButtonStartReceive = true;                  //  Флаг - приём данных включен
                    buttonStartReceive.Text = "Завершить приём";    //  Смена надписи на кнопке
                }
                else
                    MessageBox.Show("Ошибка: порт закрыт");         //  Если порт закрыт
            }
        }

        /// <summary>
        /// Начать приём данных
        /// </summary>
        /// <returns>true - если порт открыт. false - если порт закрыт</returns>
        public bool StartReceive()
        {
            try
            {
                COMPort.port.DataReceived += new SerialDataReceivedEventHandler(receivedDataOnUART_Event);
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Завершить приём данных
        /// </summary>
        /// <returns>true - если порт открыт. false - если порт закрыт</returns>
        public bool StopReceive()
        {
            try
            {
                COMPort.port.DataReceived -= new SerialDataReceivedEventHandler(receivedDataOnUART_Event);
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        /*  Показать форму с выбором порта (Обработчик события)
        */
        private void buttonPortSetting_Click(object sender, EventArgs e)
        {
            formPortSetting.Show();
        }
    }
}
