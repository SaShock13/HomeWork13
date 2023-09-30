using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public interface IDecreaseMoney<in T> 
    {
        void DecreaseMoney(T account,int amount);
    }
}
