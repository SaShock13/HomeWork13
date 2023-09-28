using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework10_1
{
    internal interface IAddAccount<T> where T : BankAccount
    {
        void AddAccount(T account,BankWorker bankWorker);
    }
}
