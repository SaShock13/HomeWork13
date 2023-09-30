using BankClassLibrary;
using LogClassesLibrary;
using SkillboxHomework10_1;
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




//ToDo
//Количество денег не обновляется сразу после перевода


//Если применимо, добавьте методы расширения и перегрузку операций.


//СДЕЛАНО:
//Разделите ваш проект на проект с интерфейсом и библиотеку:
//в библиотеке будет храниться основная логика приложения;
//в проекте с интерфейсом будет храниться только логика взаимодействия с интерфейсом и сам интерфейс.
//Создайте одно или несколько исключений и используйте его (их) в своём коде.

namespace SkillboxHomework10_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static event Action<string> TransferEvent;
        BankWorker bankWorker;
        IEditClientData workerEditMode;
        List<Department> departmentList;
        string info = "dsfdsdfsd";
        Logger logger = new Logger();
        public MainWindow()
        {
            AccessWindow accessWindow = new AccessWindow(); //Создание и Запуск окна выбора Прав доступа
            accessWindow.ShowDialog();
            Client.ClientEvent += MessageAboutEvent;
            Client.ClientEvent += logger.LogMessage;
            TransferEvent += MessageTransferEvent;
            TransferEvent += logger.LogMessage;

            departmentList = new List<Department>();
            FillDepartmentList(5);
            InitializeComponent();

            if (accessWindow.DialogResult == true) // Инициализация нужных типов и настройка окна
            {
                if (!accessWindow.isManager)
                {
                    bankWorker = new Consultant();
                    workerEditMode = new Consultant();
                    mainWindow.Title = "Консультант";
                    passportColumn.Visibility = Visibility.Hidden;
                    btnAdd.IsEnabled = false;
                    btnDelete.IsEnabled = false;
                    btnAddAcc.IsEnabled = false;
                }
                else
                { 
                    bankWorker = new Manager();
                    workerEditMode = new Manager();
                    mainWindow.Title = "Менеджер";
                    
                }

            }
            dgClientsList.ItemsSource = bankWorker.Clients;

            cbDeps.ItemsSource = departmentList;
            cbDeps.SelectedIndex = 0;
            
            dgSourceUpdate();
        }

        private void MessageTransferEvent(string message)
        {
            MessageBox.Show(message);
        }

        private void FillDepartmentList(int count)
        {
            departmentList.Add(new Department(0, "Все департаменты"));
            for (int i = 1; i <= count; i++)
            {
                departmentList.Add(new Department(i, $"Департамент {i}"));
            }

        }
        private void SaveBtnClick(object sender, RoutedEventArgs e)
        {
            bankWorker.SaveToFile();
        }

        private void ChangeBtnClick(object sender, RoutedEventArgs e)
        {
            if (dgClientsList.SelectedIndex!=-1)
            {
                workerEditMode.EditClientData(dgClientsList.SelectedItem as Client);

                bankWorker.SaveToFile();
            }
            TransferEvent($"{bankWorker.accessType} изменил данные клиента {(dgClientsList.SelectedItem as Client).LastName} {(dgClientsList.SelectedItem as Client). Name} {DateTime.Now}");
           
        }
        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            
            if (bankWorker is Manager)
            {
                AddClientWindow addClientWindow = new AddClientWindow();
                
                addClientWindow.ShowDialog();

                (bankWorker as Manager).Clients.Add(addClientWindow.client);
                TransferEvent($"{bankWorker.accessType} добавил нового клиента {addClientWindow.client.LastName} {addClientWindow.client.Name}, {DateTime.Now}");

            }
            dgSourceUpdate();
            bankWorker.SaveToFile();
        }
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (bankWorker is Manager)
            {
                Client clientForDelete = dgClientsList.SelectedItem as Client;
                (bankWorker as Manager).DeleteClient(clientForDelete);
                TransferEvent($"{bankWorker.accessType} удалил клиента {clientForDelete.LastName} {clientForDelete.Name}, {DateTime.Now}");
            }
            dgSourceUpdate();
            bankWorker.SaveToFile();
        }

        private void dgClientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClientsList.SelectedIndex!=-1)
            {
                Client client = dgClientsList.SelectedItem as Client;

                tbInfo.Text = client.ChangeInfo;
                lbAccounts.ItemsSource = client.AccList;
                lbAccounts.SelectedIndex = 0;
            }
            

        }

        private void cbDeps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgSourceUpdate();
        }
        private void dgSourceUpdate()
        {
            if (cbDeps.SelectedIndex == 0)
            {
                dgClientsList.ItemsSource = bankWorker.Clients;
            }
            else dgClientsList.ItemsSource = bankWorker.Clients.Where(p => p.DepId == (cbDeps.SelectedItem as Department).DepId);
        }

        private void AddAccClick(object sender, RoutedEventArgs e)
        {
            if (dgClientsList.SelectedIndex!=-1)
            {
                AddAccWindow addAccWindow = new AddAccWindow();

                addAccWindow.ShowDialog();
                if (addAccWindow.DialogResult==true)
                {

                    int amount = addAccWindow.amount;
                    IAddAccount<BankAccount> client = dgClientsList.SelectedItem as Client;
                    if (addAccWindow.cbAccType.SelectedIndex==0)
                    {
                        client.AddAccount(new DepositeAccount(amount), bankWorker);
                    }
                    else
                    {
                        client.AddAccount(new NonDepositeAccount(amount),bankWorker);
                    }

                }
                
            }



            
        }
        

        private void DelAccClick(object sender, RoutedEventArgs e)
        {
            BankAccount acc = lbAccounts.SelectedItem as BankAccount;
            if (acc != null) 
            {
                (dgClientsList.SelectedItem as Client).DeleteAccount(acc,bankWorker);
                
            }
        }

        private void TransferMoneyClick(object sender, RoutedEventArgs e)
        {
            Client source = dgClientsList.SelectedItem as Client;

            if (lbAccounts.SelectedIndex !=-1)
            {
                DepositeAccount sourceDepAcc;
                NonDepositeAccount sourceNonDepAcc;
                
                IDecreaseMoney<BankAccount> moneyDecrease;
                IIncreaseMoney<BankAccount> moneyIncrease;
                TransferMoneyWindow transferMoneyWindow = new TransferMoneyWindow();
                transferMoneyWindow.cbTargetClient.ItemsSource = bankWorker.Clients;
                transferMoneyWindow.ShowDialog();
                if (transferMoneyWindow.DialogResult == true)
                {
                    try
                    {

                        Client target = transferMoneyWindow.cbTargetClient.SelectedItem as Client;
                        int amount = transferMoneyWindow.amount;
                        if (amount > 10000) throw new MaxAmountException("Превышение допустимой суммы для перевода!\n(Максимальная сумма 10000)");

                        moneyDecrease = new Bank<BankAccount>();
                        moneyIncrease = new Bank<DepositeAccount>();
                        moneyDecrease.DecreaseMoney(lbAccounts.SelectedItem as BankAccount, amount);
                        moneyIncrease.IncreaseMoney(amount, transferMoneyWindow.cbTargetAcc.SelectedItem as BankAccount);

                        TransferEvent($"{bankWorker.accessType} осуществил перевод {amount} долларов от " +
                            $"{source.LastName} {source.Name} к {target.LastName} {target.Name}, {DateTime.Now}");
                    }
                    catch (MaxAmountException exception)
                    {

                        MessageBox.Show(exception.Message);
                    }
                    catch (NotEnoughMoneyException exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                } 
            }
        }

        private void IncreaseMoneyClick(object sender, RoutedEventArgs e)
        {

            if (lbAccounts.SelectedIndex!=-1)
            {
                IIncreaseMoney<BankAccount> moneyIncrease;
                moneyIncrease = new Bank<DepositeAccount>();
                moneyIncrease.IncreaseMoney(1000,lbAccounts.SelectedItem as BankAccount);
                TransferEvent($"{bankWorker.accessType} увеличил Счёт клиента " +
                    $"{(dgClientsList.SelectedItem as Client).LastName} {(dgClientsList.SelectedItem as Client).Name} на 1000 долларов {DateTime.Now}");
            }
        }

        public void MessageAboutEvent(string message)
        {
            MessageBox.Show(message);
        }

        protected override void OnClosed(EventArgs e)
        {
            bankWorker.SaveToFile();
            base.OnClosed(e);
        }

        private void ShowClientInfo(object sender, RoutedEventArgs e)
        {
            if (dgClientsList.SelectedIndex!=-1)
            {
                MessageBox.Show((dgClientsList.SelectedItem as Client).ShowInfoAboutClient());
            }
        }
    }
}
