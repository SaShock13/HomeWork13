using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class MaxAmountException: Exception
    {
        public MaxAmountException(string message):base(message) 
        { }
        
    }
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string message) : base(message)
        { }

    }
}
