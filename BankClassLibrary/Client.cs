using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankClassLibrary
{
    public class Client:INotifyPropertyChanged ,IAddAccount<BankAccount>

    {

        #region ПОЛЯ

        public static event Action<string> ClientEvent;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }

        /// <summary>
        /// Имя
        /// </summary>
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        private string surName;

        public string SurName
        {
            get { return surName; }
            set { surName = value; OnPropertyChanged("SurName"); }
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        private long phoneNumber;

        public long PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }

        /// <summary>
        /// Серия и номер паспорта
        /// </summary>
        private string passport;

        public string Passport
        {
            get 
            { return passport;
            }
            set { passport = value; OnPropertyChanged("Passport"); }
        }

        /// <summary>
        /// Идентификатор департамента клиента
        /// </summary>
        private int depId;

        public int DepId
        {
            get { return depId; }
            set { depId = value; OnPropertyChanged("DepId"); }
        }


        ///Список счетов клиента
        private ObservableCollection<BankAccount> accList;

        public ObservableCollection<BankAccount> AccList
        {
            get { return accList; }
            set { accList = value;  }
        }



        /// <summary>
        /// Дата последнего изменения данных клиента
        /// </summary>
        private DateTime changeDate;

        public DateTime ChangeDate
        {
            get { return changeDate; }
            set { changeDate = value; OnPropertyChanged("ChangeDate"); }
        }

        /// <summary>
        /// Что измененили в данных клиента
        /// </summary>
        private string whatChanged;

        public string WhatChanged
        {
            get { return whatChanged; }
            set { whatChanged = value; OnPropertyChanged("WhatChanged"); }
        }

        /// <summary>
        /// Какие данные изменили
        /// </summary>
        private string pastValue;

        public string PastValue
        {
            get { return pastValue; }
            set { pastValue = value; OnPropertyChanged("PastValue"); }
        }

        /// <summary>
        /// На что изменили данные
        /// </summary>
        private string currentValue;

        public string CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; OnPropertyChanged("CurrentValue"); }
        }

        /// <summary>
        /// Кто изменил данные клиента
        /// </summary>
        private string whoChanged;

        public string WhoChanged
        {
            get { return whoChanged; }
            set { whoChanged = value; OnPropertyChanged("WhoChanged"); }
        }
        #endregion




        public Client():this("Иванов", "Иван", "Иванович", 777777,"3605-487856",1)
        {
            //LastName = "Иванов";
            //Name = "Иван";
            //SurName = "Иванович";
            //PhoneNumber = 777777;
            //Passport = "3605-487856";
            //changeInfoData = new ChangeInfoData();
            
        }
        public Client(string lastName, string name, string surName, long phoneNumber, string passport,int depId)
        {
            LastName = lastName;
            Name = name;
            SurName = surName;
            PhoneNumber = phoneNumber;
            Passport = passport;
            DepId = depId;
            accList = new ObservableCollection<BankAccount>();

        }


        public override string ToString()
        {
            return $"{LastName} {Name} {SurName} , телефон: {PhoneNumber}, паспотные данные: {Passport}";
        }

        public void AddAccount(BankAccount account,BankWorker bankWorker)
        {
            accList.Add(account);
            ClientEvent($"{bankWorker.accessType} Добавил новый счет для клиента {this.LastName} {this.Name}, {DateTime.Now}");

        }

        public void DeleteAccount(BankAccount acc, BankWorker bankWorker)
        {
            AccList.Remove(acc);
            ClientEvent($"{bankWorker.accessType} Удалил счет клиента {this.LastName} {this.Name}, {DateTime.Now}");
        }

        //public BankAccount IncreaseAccount(BankAccount account, int amount)
        //{
        //    account.IncreaseAccount(amount);
        //    return account;
        //}


        private string changeInfo;
        public string ChangeInfo
        {
            get
            {
                if (ChangeDate == new DateTime())
                {
                    return changeInfo = "Не было изменено";
                }
                else
                { 
                    return changeInfo = $"{ChangeDate.ToString()} , {WhoChanged} изменил {WhatChanged} клиента ";
                   
                }
            }
            set 
            {
                changeInfo = value;
                OnPropertyChanged("ChangeInfo");
            }
            
            
        }
       
    }
}