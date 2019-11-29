using System;
using System.Windows;
using System.Windows.Input;

namespace K_Means
{
    /// <summary>
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        private int num_of_objects, num_of_params;
        public Create()
        {
            InitializeComponent();
        }

        //Геттеры для передаваемых параметров и количества объектов
        public int getObjects()
        {
            return num_of_objects;
        }

        public int getParams()
        {
            return num_of_params;
        }

        //Динамический обработчик входных данных
        private void textNum_Of_Objects_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int inp = Int32.Parse(textNum_Of_Objects.Text);
            } catch
            {
                textNum_Of_Objects.Text = "";
                MessageBox.Show("Попытка ввода не числового значения");
            }
        }

        //Вспомогательные методы очистки полей
        private void textNum_Of_Params_GotFocus(object sender, RoutedEventArgs e)
        {
            textNum_Of_Params.Text = "";
        }

        private void textNum_Of_Objects_GotFocus(object sender, RoutedEventArgs e)
        {
            textNum_Of_Objects.Text = "";
        }

        //Передаем значения на основную форму
        private void button_GotFocus(object sender, RoutedEventArgs e)
        {
            num_of_objects = Int32.Parse(textNum_Of_Objects.Text);
            num_of_params = Int32.Parse(textNum_Of_Params.Text);
            if (num_of_objects > 0 && num_of_params > 0) this.Hide();
            else
            {
                MessageBox.Show("Попытка присвоения несоответствующего значения");
                textNum_Of_Params.Text = "";
                textNum_Of_Objects.Text = "";
                textNum_Of_Objects.Focus();
            }
            this.Close();
        }

        //Динамический обработчик входных данных
        private void textNum_Of_Params_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int inp = Int32.Parse(textNum_Of_Objects.Text);
            }
            catch
            {
                textNum_Of_Objects.Text = "";
                MessageBox.Show("Попытка ввода не числового значения");
            }
        }
    }
}
