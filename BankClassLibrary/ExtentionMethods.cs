using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public static class ExtentionMethods
    {
        public static string ShowInfoAboutClient(this Client client)
        {
            return $"{client.LastName} {client.Name} {client.SurName}, департамент {client.DepId} , количество счетов: {client.AccList.Count}";
        }
    }
}
