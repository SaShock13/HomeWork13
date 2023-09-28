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

namespace SkillboxHomework10_1
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            long phoneNum;
            if (long.TryParse(tbPhone.Text, out phoneNum)&!string.IsNullOrEmpty(tbLastName.Text) & !string.IsNullOrEmpty(tbName.Text) & !string.IsNullOrEmpty(tbPassport.Text) & !string.IsNullOrEmpty(tbSurName.Text))
            {
                DialogResult = true;
            }
            else 
            MessageBox.Show("Введите корректные данные ");

        }
    }
}
