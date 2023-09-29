using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework10_1.BankWorkers
{
    internal interface IIncreaseMoney<out T> 
    {

        T IncreaseMoney(int amount, BankAccount account);
    }
}
