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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public Client client;
        public AddClientWindow()
        {
            InitializeComponent();
            tbLastName.Text = "Иванов";
            tbName.Text = "Иван";
            tbSurName.Text = "Иванович";
            tbPhone.Text = "777777";
            tbPassport.Text = "777-777777";
            cbDepartment.SelectedIndex = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            long phoneNum;
            if (long.TryParse(tbPhone.Text, out phoneNum) & !string.IsNullOrEmpty(tbLastName.Text) & !string.IsNullOrEmpty(tbName.Text) & !string.IsNullOrEmpty(tbPassport.Text) & !string.IsNullOrEmpty(tbSurName.Text))
            {
                client = new Client(tbLastName.Text, tbName.Text, tbSurName.Text, long.Parse(tbPhone.Text), tbPassport.Text, cbDepartment.SelectedIndex+1);
                client.AccList.Add(new BankAccount());
                DialogResult = true;
            }
            else
                MessageBox.Show("Введите корректные данные ");

            
        }
    }
}
