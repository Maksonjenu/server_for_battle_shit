using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pojiloy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string jjjj = "";
       static public int cletka = 0 ;
        const int port = 25565;
        static TcpListener listener;
        bool isWorking = true;
        Thread myThread1;


        public void Btn_Click(object sender, RoutedEventArgs e)
        {

            int n = (int)((Button)sender).Tag;
            //получение значения лежащего в Tag
            // int n = (int)((Button)sender).Tag;

            //установка фона нажатой кнопки, цвета и размера шрифта
            ((Button)sender).Background = Brushes.Red;
            ((Button)sender).Foreground = Brushes.Black;
            ((Button)sender).FontSize = 8;
            //запись в нажатую кнопку её номера
            ((Button)sender).Content = n.ToString();
            
        }


        public MainWindow()
        {
            InitializeComponent();
            ugr.Rows = 10;
            ugr.Columns = 10;


            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            // ugr.Width = 10 * (40 + 4);
            // ugr.Height = 10 * (40 + 4);
            //толщина границ сетки
            // ugr.Margin = new Thickness(-456, 10, 458, -2);
            for (int i = 0; i < 100; i++)
            {
                //создание кнопки
                Button btn = new Button();
                //запись номера кнопки
                btn.Tag = i;
                //установка размеров кнопки
                btn.Width = 40;
                btn.Height = 40;
                //текст на кнопке
                btn.Content = i;
                //толщина границ кнопки
                btn.Margin = new Thickness(1);
                //при нажатии кнопки, будет вызываться метод Btn_Click
                btn.Click += Btn_Click;
                //добавление кнопки в сетку
                ugr.Children.Add(btn);

            }
            ugr1.Rows = 10;
            ugr1.Columns = 10;
            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            // ugr1.Width = 10 * (40 + 4);
            // ugr1.Height = 10 * (40 + 4);
            //толщина границ сетки
            //  ugr1.Margin = new Thickness(2, 2, 2, 2);
            for (int i = 0; i < 100; i++)
            {
                //создание кнопки
                Button btn1 = new Button();
                //запись номера кнопки
                btn1.Tag = i + 1;
                //установка размеров кнопки
                btn1.Width = 40;
                btn1.Height = 40;
                //текст на кнопке
                btn1.Content = i;
                //толщина границ кнопки
                btn1.Margin = new Thickness(1);
                //при нажатии кнопки, будет вызываться метод Btn_Click
                btn1.Click += Btn_Click;
                //добавление кнопки в сетку
                ugr1.Children.Add(btn1);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          //  player1 ww1 = new player1();
          //  ww1.Owner = this;
          //  ww1.Show();


            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            listener.Start();
            myThread1 = new Thread(new ThreadStart(Count1));
            myThread1.Start();
        }
        public void Count1()
        {
            try
            {
                while (isWorking)
                {
                    Dispatcher.BeginInvoke(new Action(() => status.Foreground = Brushes.Green));
                    Dispatcher.BeginInvoke(new Action(() => status.Content = ("server started")));

                    TcpClient client = listener.AcceptTcpClient();

                    Thread clientThread = new Thread(() => Process(client));
                    clientThread.Start();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("vse ochen ploho");
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
        public void Process(TcpClient tcpClient)
        {
            TcpClient client = tcpClient;
            NetworkStream stream = null;

            try
            {
              
                stream = client.GetStream();
               


                //цикл обработки сообщений
                while (isWorking)
                {
                    byte[] data = new byte[64];

                    //объект, для формирования строк
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    //до тех пор, пока в потоке есть данные
                    do
                    {
                        //из потока считываются 64 байта и записываются в data
                        bytes = stream.Read(data, 0, data.Length);
                        //из считанных данных формируется строка
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);


                     jora.Text = builder.ToString();

                    Dispatcher.BeginInvoke(new Action(() => tags.Content = jjjj));
                    

                    //преобразование сообщения в набор байт
                    // data = Encoding.Unicode.GetBytes(message);
                    //отправка сообщения обратно клиенту
                    //stream.Write(data, 0, data.Length);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
            finally
            {
                //освобождение ресурсов при завершении сеанса
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            listener.Stop();
        }

        private void Cifora_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listener.Stop();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //    int i = int.Parse(y_cord.Text);
            //    int j = int.Parse(x_cord.Text);
            if (jora.Text != "")
            {
                var o = ugr.Children[(int.Parse)(jora.Text)];
                Btn_Click((Button)o, e);
            }
        }

        private void Jora_TextChanged(object sender, TextChangedEventArgs e)
        {
            typeof(System.Windows.Controls.Primitives.ButtonBase).GetMethod("OnClick", BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(hwhw, new object[0]);
        }
    }
}
