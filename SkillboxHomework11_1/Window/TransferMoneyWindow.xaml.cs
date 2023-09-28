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
    /// Логика взаимодействия для TransferMoneyWindow.xaml
    /// </summary>
    public partial class TransferMoneyWindow : Window
    {
        Client targetClient;
        public int amount;
        public TransferMoneyWindow()
        {
            InitializeComponent();
            
        }

        private void cbTargetClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbTargetAcc.ItemsSource = (cbTargetClient.SelectedItem as Client).AccList;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            if (cbTargetAcc.SelectedIndex != -1 & int.TryParse(tbAmount.Text,out amount))
            {
                
                DialogResult = true;
            }
        }
    }
}
