using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using BE;
using DS;
namespace DAL
{
    internal class Dal_imp : IDAL
    {
        private static int employerID = 100000;//there were no instructions what is the number
        private static int contractID = 10000000;
        private static int specializaionID = 100000000;

        public void addContract(Contract contract)
        {
            
            Employer employer = getEmployer(contract.employerID);
            if (employer == null) throw new Exception("cannot add contract! employer does not exsist!");
            Employee employee = getEmployee(contract.employeeID);
            if (employee == null) throw new Exception("cannot add contract! employee does not exsist!");
             employee.numOfJobs++;
            updateEmployee(employee);
            employer.NumOfEmployees++;
            employer.NumOfEmployeesNeeded--;
            updateEmployer(employer);                    
            contractID += 1;
            contract.contractNum = contractID;
            DataSource.ContractList.Add(contract);
           
        }
        public void addEmployee(Employee employee)
        {                                  
            Employee emp = getEmployee(employee.ID);
            if (emp != null)
                throw new Exception("Employee with the same id already exists...");
            DataSource.EmployeeList.Add(employee);
        }

        public void addEmployer(Employer employer)
        {
            if (!employer.freelancer && employer.ID == 0) { employerID += 1; employer.ID = employerID; }
            else
            {
                Employer emp = getEmployer(employer.ID);
                if (emp != null)
                    throw new Exception("Employer with the same id already exists...");
            }
                       
            DataSource.EmployerList.Add(employer);
        }

        public void addSpecialization(Specialization specialization)
        {           
            specializaionID += 1;
            specialization.numOfSpecialization = specializaionID;
            Specialization spc = getSpecialization(specialization.numOfSpecialization);
            if (spc != null)
                throw new Exception("Specialization with the same id already exists...");
            

            DataSource.SpecializationList.Add(specialization);
        }

        public IEnumerable<BankAcount> GetAllBankAcounts(Func<BankAcount, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.BankAcountList.AsEnumerable();
            return DataSource.BankAcountList.Where(predicat);
        }

        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.ContractList.AsEnumerable();
            return DataSource.ContractList.Where(predicat);
        }

        public IEnumerable<Employee> GetAllEmployees(Func<Employee, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.EmployeeList.AsEnumerable();
            return DataSource.EmployeeList.Where(predicat);
        }

        public IEnumerable<Employer> GetAllEmployers(Func<Employer, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.EmployerList.AsEnumerable();
            return DataSource.EmployerList.Where(predicat);
        }

        public IEnumerable<Specialization> GetAllSpecializations(Func<Specialization, bool> predicat = null)
        {
            if (predicat == null)
                return DataSource.SpecializationList.AsEnumerable();
            return DataSource.SpecializationList.Where(predicat);
        }

        public Contract getContract(int IDContract)
        {
            return DataSource.ContractList.FirstOrDefault(s => s.contractNum == IDContract);
        }

        public Employee getEmployee(int IDEmployee)
        {
            return DataSource.EmployeeList.FirstOrDefault(s => s.ID == IDEmployee);
        }

        public Employer getEmployer(int IDEmployer)
        {
            return DataSource.EmployerList.FirstOrDefault(s => s.ID == IDEmployer);
        }

        public Specialization getSpecialization(int IDSpecialization)
        {
            return DataSource.SpecializationList.FirstOrDefault(s => s.numOfSpecialization == IDSpecialization);
        }

        public bool removeContract(int id)
        {
            Contract cont = getContract(id);
            if (cont == null)
                throw new Exception("Contract with the same id not found...");
            DataSource.ContractList.RemoveAll(s => s.contractNum == id);
            return DataSource.ContractList.Remove(cont);
        }

        public bool removeEmployee(int id)
        {
            Employee emp = getEmployee(id);
            if (emp == null)
                throw new Exception("Employee with the same id not found...");
            DataSource.EmployeeList.RemoveAll(s => s.ID == id);
            return DataSource.EmployeeList.Remove(emp);
        }

        public bool removeEmployer(int id)
        {
            Employer emp = getEmployer(id);
            if (emp == null)
                throw new Exception("Employer with the same id not found...");
            DataSource.EmployerList.RemoveAll(s => s.ID == id);
            return DataSource.EmployerList.Remove(emp);
        }

        public bool removeSpecialization(int id)
        {
            Specialization spc = getSpecialization(id);
            if (spc == null)
                throw new Exception("Specialization with the same id not found...");
            DataSource.SpecializationList.RemoveAll(s => s.numOfSpecialization == id);
            return DataSource.SpecializationList.Remove(spc);
        }

        public void updateContract(Contract contract)
        {
            int index = DataSource.ContractList.FindIndex(s => s.contractNum == contract.contractNum);
            if (index == -1)
                throw new Exception("Contract with the same id not found...");
            DataSource.ContractList[index] = contract;
        }

        public void updateEmployee(Employee employee)
        {
            int index = DataSource.EmployeeList.FindIndex(s => s.ID == employee.ID);
            if (index == -1)
                throw new Exception("Employee with the same id not found...");
            DataSource.EmployeeList[index] = employee;
        }

        public void updateEmployer(Employer employer)
        {
            int index = DataSource.EmployerList.FindIndex(s => s.ID == employer.ID);
            if (index == -1)
                throw new Exception("Employer with the same id not found...");
            DataSource.EmployerList[index] = employer;
        }

        public void updateSpecialization(Specialization specialization)
        {           
            int index = DataSource.SpecializationList.FindIndex(s => s.numOfSpecialization == specialization.numOfSpecialization);
            if (index == -1)
                throw new Exception("Specialization with the same id not found...");                      
            DataSource.SpecializationList[index] = specialization;
        }
       
        public bool ifContractIsWithinYear(Contract contract, int year)
        {
            if (contract.employementBegin.Year <= year && contract.employementEnd.Year >= year)
                return true;
            return false;
        }

        public void addUser(HTC_User_Account user)
        {
            HTC_User_Account user1 = getUser(user.UserName);
            if (user1!=null) throw new Exception("this user name allready exsists");
            else DataSource.ProgramUsers.Add(user);
        }

        public bool removeUser(string userName)
        {
            HTC_User_Account user = getUser(userName);
            if (user == null)
                throw new Exception("user with the same user name not found...");
            DataSource.ProgramUsers.RemoveAll(s => s.UserName == userName);
            return DataSource.ProgramUsers.Remove(user);
        }

        public HTC_User_Account getUser(string userName)
        {
            return DataSource.ProgramUsers.FirstOrDefault(s => s.UserName == userName);
        }

        public bool banksDownloaded()
        {
            return true;
        }

        public IEnumerable<BankAcount> GetBankAcountsList(Func<BankAcount, bool> predicat = null) { return DataSource.BankAcountList.AsEnumerable(); }
       
        public IEnumerable<Employee> GetEmployeesList() { return DataSource.EmployeeList.AsEnumerable(); }
        
        public IEnumerable<Employer> GetEmployersList() { return DataSource.EmployerList.AsEnumerable(); }
        
        public IEnumerable<Specialization> GetSpecializationsList() { return DataSource.SpecializationList.AsEnumerable(); }

        public Employee getEmployeeFromList(int IDEmployee)
        {
            throw new NotImplementedException();
        }

        public Employer getEmployerFromList(int IDEmployer)
        {
            throw new NotImplementedException();
        }

        public Specialization getSpecializationFromList(int IDSpecialization)
        {
            throw new NotImplementedException();
        }

        public void addID()
        {
            throw new NotImplementedException();
        }
    }
}
