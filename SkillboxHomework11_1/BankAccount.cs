using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkillboxHomework10_1
{
    public class BankAccount:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string accType;
        static Random random = new Random();

        public string AccType
		{
			get { return accType; }
			set { accType = value; }
		}

		private int moneyAmount;

        

        public int MoneyAmount
		{
			get { return moneyAmount; }
			set { moneyAmount = value; OnPropertyChanged("MoneyAmount"); }
		}
        public BankAccount()
        {
			accType = "Депозитный";
			moneyAmount = random.Next(1,13001);
        }
        public BankAccount(string type,int amount)
        {
				accType = type;
			moneyAmount = amount;
        }

        public override string ToString()
        {
            return $"Тип счета: {accType} \nДенег на счёте: {moneyAmount} баксов";
        }

        public void IncreaseAccount(int amount)
        {
           this.MoneyAmount += amount;
            //MessageBox.Show("Увеличено");
        }
        public void DecreaseAccount(int amount)
        {
            this.MoneyAmount -= amount;
           //MessageBox.Show("Уменьшено");
        }
    }

    class DepositeAccount:BankAccount
    {
        public DepositeAccount(int amount):base("Депозитный",amount)
        {
            
        }
    }
    class NonDepositeAccount : BankAccount
    {
        public NonDepositeAccount(int amount) : base("Недепозитный", amount)
        {
                
        }
    }




}
