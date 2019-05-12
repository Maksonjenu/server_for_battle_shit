using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pojiloy
{
    /// <summary>
    /// Логика взаимодействия для player1.xaml
    /// </summary>
    public partial class player1 : Window
    {
     
        public void Btn_Click(object sender, RoutedEventArgs e)
        {
          
            int n = MainWindow.cletka;
            //получение значения лежащего в Tag
           // int n = (int)((Button)sender).Tag;
        
            //установка фона нажатой кнопки, цвета и размера шрифта
            ((Button)sender).Background = Brushes.Red;
            ((Button)sender).Foreground = Brushes.Black;
            ((Button)sender).FontSize = 8;
            //запись в нажатую кнопку её номера
            ((Button)sender).Content = n.ToString();
        }
     
        public player1()
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
                btn.Tag = i + 1;
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
  
}
}
