using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public interface IAddAccount<T> where T : BankAccount
    {
        void AddAccount(T account,BankWorker bankWorker);
    }
}
