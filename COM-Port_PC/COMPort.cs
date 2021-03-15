using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace COM_порт
{
    class COMPort
    {
        public static SerialPort port;

        /*  Метод находит все доступные порты.
         *  Имена всех доступных портов записываются в переменную portNames переданную по ссылке
         *  Если порты не найдены, то метод возвращает значение "false"
         *  Если порты найдены, то метод возвращает значение "true"
         */
        public bool SearchPort(out string[] portNames)
        {
            portNames = SerialPort.GetPortNames();      //Возвращает список всех доступных последовательных портов
            if (portNames.Length == 0)                  //Доступных портов нет
                return false;
            else
                return true;
        }

        /*  Инициализация последовательного порта.
        */
        public bool InitializePort(string portName)
        {
            try
            {
                if (port != null)                   //Если порт уже был инициализирован
                    port.Close();                   //Закрыть порт
                else
                    port = new SerialPort();        //  Первая инициализация
                port.PortName = portName;           //  Имя последовательного порта
                port.BaudRate = 9600;               //  Скорость передачи данных 9600 бод/с
                port.DataBits = 8;                  //  Количество бит - 8
                port.Parity = Parity.Odd;           //  Бит чётности - нечётный бит
                port.StopBits = StopBits.Two;       //  Стоп-бит - 2
                port.ReadTimeout = 500;             //  Срок ожидания для завершения операции чтения - 500 мс
                port.WriteTimeout = 500;            //  Срок ожидания для завершения операции записи - 500 мс
                port.WriteBufferSize = 16;           //  Массив операционной системы
                port.ReadBufferSize = 16;            //  Массив операционной системы
                port.ReceivedBytesThreshold = 3;    //  Массив входных данных в приложении
                port.Open();                        //  Открыть порт
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*  Метод для передачи данных в COM-порт.
         *  Переменная типа "int" конвертируется в массив байт
         *  Если порт открыт, то передаётся 4 байта и метод возвращает true
         *  Если порт закрыт, то метод возвращает false
         *  Если порт не инициализирован (Scroll используется до того, как был выбран порт),
         *  то возникает исключение и метод передаёт false
         */
        public bool SendValueToSerialPort(byte[] valueForSend)
        {
            try
            {
                if (port.IsOpen)                        //  Если порт открыт
                {
                    port.Write(valueForSend, 0, 16);     //  Записать данные в последовательный порт
                    return true;
                }
                else
                {                                       //  Если порт закрыт
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }
}
