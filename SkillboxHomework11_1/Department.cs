using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework10_1
{
    internal class Department
    {
        public int DepId { get; set; }
        public string DepName { get; set; }

        public Department(int id,string name)
        {
           DepId = id;
            DepName = name;
        }

        public override string ToString()
        {
            return DepName;
        }
    }

}
