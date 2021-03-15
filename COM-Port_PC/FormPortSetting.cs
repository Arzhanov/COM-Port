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
    public partial class FormPortSetting : Form
    { 
        string[] portNames;     //  Массив для хранения имен последовательных портов
        string portName;        //  Переменная для хранения имени выбранного последовательного порта
        COMPort port;           //  Объект класса COMPort

        public FormPortSetting()
        {
            InitializeComponent();
            port = new COMPort();

            //  При открытии формы "Выбор порта" показывает доступные порты
            if (ShowSerialPorts())                                          //  Показать все доступные порты в ListBoxPorts
            {
                labelSelectedNamePort.Text = "Выберете доступный порт";     //  Вывести сообщение на форму
                labelSelectedNamePort.ForeColor = Color.Black;
            }
            else
            {                                                               //  Если доступных портов не найдено
                MessageBox.Show("Ошибка: Нет доступных COM-портов");        //  Сообщить об ошибке (при первом запуске программы)
                labelSelectedNamePort.Text = "Нет доступных COM-портов";    //  Вывести сообщение об ошибке на форму
                labelSelectedNamePort.ForeColor = Color.Red;
            }
        }

        /*  Данный метод получает информацию о всех 
         *  доступных последовательных портах на ПК.
         *  Имена всех доступных COM-портов добавляются в
         *  список. Если порты найдены, то метод возвращает "true"
         *  Если доступных портов не найдено, то метод возвращает "false"
         */
        public bool ShowSerialPorts()
        {
            listBoxPorts.Items.Clear();                         //    Очистить список портов
            portNames = new string[10];                         //    Инициализировать массив для хранения имён портов (10 - произвольное число)
            if (port.SearchPort(out portNames))                 //    Найти доступные порты и заполнить массив имён
            {                                                   //    Если доступные порты найдены
                for (int i = 0; i < portNames.Length; i++)
                {
                    listBoxPorts.Items.Add(portNames[i]);       //    Добавить имена последовательных портов в listBoxPorts
                }
                return true;
            }
            else
                return false;                                   //    Если доступных портов нет
        }



        /*  Обработчик события вызывается при нажатии на кнопку "Выбрать".
         *  Если пользователь выбрал порт из списка,
         *  то будет инициализирован выбранный порт. Если пользователь
         *  не выбрал порт из списка, то будет выдано сообщение на форме.
         */
        private void buttonSelectPort_Click(object sender, EventArgs e)
        {
            labelSelectedNamePort.Text = "";                                                //  Стереть предыдущую запись на форме
            if (listBoxPorts.SelectedItem != null)
            {                                                                               //  Если в списке выбран порт
                portName = listBoxPorts.SelectedItem.ToString();                            //  Присвоить переменной portName имя выбранного в списке порта
                if (port.InitializePort(portName) == true)
                {                                                                           //  Инициализировать порт
                    labelSelectedNamePort.Text = "Выбран " + portName;                      //  Показать имя открытого порта
                    labelSelectedNamePort.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("ERROR: невозможно открыть порт: " + e.ToString());     //  Ошибка открытия порта
                    labelSelectedNamePort.Text = "Ошибка";                                  //  Вывести сообщение об ошибке на форму
                    labelSelectedNamePort.ForeColor = Color.Red;
                }
            }
            else
            {                                                                               //  Если в списке не выбран порт
                labelSelectedNamePort.Text = "Выберете доступный порт";                     //  Вывести сообщение об ошибке на форму
                labelSelectedNamePort.ForeColor = Color.Red;
            }
        }


        /*  Данный обработчик события вызывается при нажатии на кнопку "Обновить"
         *  Обновляется список доступных портов
         *  Если доступных портов нет, то выводится сообщение об ошибке
         */
        public void buttonRefreshListPorts_Click(object sender, EventArgs e)
        {
            labelSelectedNamePort.Text = "";                                //  Стереть предыдущую запись на форме
            if (ShowSerialPorts())                                          //  Показать все доступные порты в ListBoxPorts
            {
                labelSelectedNamePort.Text = "Выберете доступный порт";     //  Вывести сообщение на форму
                labelSelectedNamePort.ForeColor = Color.Black;
            } 
            else
            {                                                               //  Если доступных портов не найдено
                labelSelectedNamePort.Text = "Нет доступных COM-портов";    //  Вывести сообщение об ошибке на форму
                labelSelectedNamePort.ForeColor = Color.Red;
            }
        }


        /*  Методы ниже для настройки формы */
        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonCloseForm_MouseLeave(object sender, EventArgs e)
        {
            buttonCloseForm.ForeColor = Color.Black;
        }

        private void buttonCloseForm_MouseEnter(object sender, EventArgs e)
        {
            buttonCloseForm.ForeColor = Color.Green;
        }


        Point lastPoint;
        private void FormPortSetting_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void FormPortSetting_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
