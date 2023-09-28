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
    /// Логика взаимодействия для AddAccWindow.xaml
    /// </summary>
    public partial class AddAccWindow : Window
    {
        public int amount;
        public AddAccWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbAccType.SelectedIndex!=-1&int.TryParse(tbMoneyAmount.Text, out amount))
            {

                DialogResult = true;
            }
        }
    }
}
