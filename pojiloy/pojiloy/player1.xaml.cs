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
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            //получение значения лежащего в Tag
            int n = (int)((Button)sender).Tag;
            //установка фона нажатой кнопки, цвета и размера шрифта
            ((Button)sender).Background = Brushes.White;
            ((Button)sender).Foreground = Brushes.Red;
            ((Button)sender).FontSize = 9;
            //запись в нажатую кнопку её номера
            ((Button)sender).Content = n.ToString();
        }
        public player1()
        {
            InitializeComponent();
            ugr.Rows = 10;
            ugr.Columns = 10;
            //указываются размеры сетки (число ячеек * (размер кнопки в ячейки + толщина её границ))
            ugr.Width = 10 * (40 + 4);
            ugr.Height = 10 * (40 + 4);
            //толщина границ сетки
            ugr.Margin = new Thickness(2, 2, 2, 2);
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
                btn.Content = " ";
                //толщина границ кнопки
                btn.Margin = new Thickness(1);
                //при нажатии кнопки, будет вызываться метод Btn_Click
                btn.Click += Btn_Click;
                //добавление кнопки в сетку
                ugr.Children.Add(btn);
            }
        }
    }
}
