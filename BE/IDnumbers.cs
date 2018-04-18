using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class IDnumbers
    {
        public int specializationID { get; set; }
        public int EmployerID { get; set; }
        public int ContractID { get; set; }

        public IDnumbers()
        {
            specializationID = 100000000;
            EmployerID = 1000;
            ContractID = 100000000;
        }
    }
}
