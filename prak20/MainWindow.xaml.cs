using System;
using System.Windows;

namespace RandomSumApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка ввода числа K
            if (!int.TryParse(KTextBox.Text, out int K) || K < 0 || K > 100)
            {
                MessageBox.Show("Введите число K в диапазоне от 0 до 100.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                KTextBox.Focus();
                KTextBox.SelectAll();
                return;
            }

            // Вычисление суммы случайных чисел
            Random random = new Random();
            int sum = 0;
            int count = 0;

            while (sum <= K)
            {
                int randomNumber = random.Next(2, 11); // случайное число от 2 до 10
                sum += randomNumber;
                count++;

                // Вывод сгенерированного числа
                OutputTextBox.AppendText($"Сгенерированное число: {randomNumber}\n");
            }

            // Вывод суммы и количества сгенерированных чисел
            OutputTextBox.AppendText($"\nОбщая сумма: {sum}\n");
            OutputTextBox.AppendText($"Количество чисел: {count}\n");
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string info = "Разработчик: Тогузов Максим\nВариант 9\nЗадание: Вычислить сумму целых случайных чисел, " +
                          "распределенных в диапазоне от 2 до 10, пока эта сумма не превысит некоторого числа K.";
            MessageBox.Show(info, "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
