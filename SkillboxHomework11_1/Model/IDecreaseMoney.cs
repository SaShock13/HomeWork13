using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework10_1.BankWorkers
{
    internal interface IDecreaseMoney<in T> 
    {
        void DecreaseMoney(T account,int amount);
    }
}
