using SkillboxHomework10_1.BankWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework10_1
{
    public class Bank<T> : IIncreaseMoney<T>, IDecreaseMoney<T> where T : BankAccount
    {
        public void DecreaseMoney(T account, int amount)
        {
            account.DecreaseAccount(amount);
        }

        public T IncreaseMoney(int amount, BankAccount account)
        {
            account.IncreaseAccount(amount);
            return account as T;
        }
    }
}
