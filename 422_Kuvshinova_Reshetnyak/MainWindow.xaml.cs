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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _422_Kuvshinova_Reshetnyak
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(InputX.Text, out double x))
            {
                MessageBox.Show("Введите корректное значение для X.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(InputY.Text, out double y))
            {
                MessageBox.Show("Введите корректное значение для Y.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Func<double, double> f;
            if (FunctionSinh.IsChecked == true)
                f = Math.Sinh;
            else if (FunctionSquare.IsChecked == true)
                f = val => Math.Pow(val, 2);
            else
                f = Math.Exp;

            double c;
            if (x - y == 0)
            {
                c = Math.Pow(f(x), 2) + Math.Pow(y, 2) + Math.Sin(y);
            }
            else if (x - y > 0)
            {
                c = Math.Pow(f(x) - y, 2) + Math.Cos(y);
            }
            else
            {
                c = Math.Pow(y - f(x), 2) + Math.Tan(y);
            }

            ResultBox.Text = $"Результат: {c:F4}";
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // Отменить закрытие окна
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputX.Clear();
            InputY.Clear();
            ResultBox.Clear();
        }
    }
}