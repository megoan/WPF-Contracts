using System.Collections.Generic;
using BE;
namespace DS
{
    public class DataSource
    {
        public static List<Specialization> SpecializationList;
        public static List<Employee> EmployeeList;
        public static List<Employer> EmployerList;       
        public static List<BankAcount> BankAcountList;        
        public static List<HTC_User_Account> ProgramUsers;
        public static List<Contract> ContractList;

        static DataSource()
        {
            

            ContractList = new List<Contract>();
            ProgramUsers = new List<HTC_User_Account>();            
        }
    }
}
