﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public interface IIncreaseMoney<out T> 
    {

        T IncreaseMoney(int amount, BankAccount account);
    }
}
