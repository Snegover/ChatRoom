using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLogin
{
    public partial class Employee
    {
        public string interval = "";
        public string hour = "";
        DateTime time = new DateTime();
        public string Hello
        {
            get
            {
                hour = time.Hour.ToString();
                string name = $"Добрый день {FullName}!";
                return name;
            }

            
            
        }
    }
}
