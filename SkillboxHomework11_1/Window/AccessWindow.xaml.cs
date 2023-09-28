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
    /// Логика взаимодействия для AccessWindow.xaml
    /// </summary>
    public partial class AccessWindow : Window
    {
        public bool isManager;
        public AccessWindow()
        {
            InitializeComponent();
            cbAccess.SelectedIndex = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                if (cbAccess.SelectedIndex == 0 )
                {
                    DialogResult = true;
                }
                else if (cbAccess.SelectedIndex == 1)
                {
                    isManager = true;
                    DialogResult = true;
                }

           
             
        }
    }
}
