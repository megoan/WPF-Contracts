using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface IDAL
    {
        /// <summary>
        ///  the fuction adds specialization
        /// </summary>
        /// <param name="specialization"></param>
        void addSpecialization(Specialization specialization);
        /// <summary>
        /// the fuction removs specialization
        /// </summary>
        /// <param name="IDSpecialization"></param>
        /// <returns></returns>
        bool removeSpecialization(int IDSpecialization);
        /// <summary>
        /// the fuction updates specialization
        /// </summary>
        /// <param name="specialization"></param>
        void updateSpecialization(Specialization specialization);
        /// <summary>
        /// the fuction returns specialization according to her num
        /// </summary>
        /// <param name="IDSpecialization"></param>
        /// <returns></returns>
        Specialization getSpecialization(int IDSpecialization);
        /// <summary>
        /// the fuction adds employee
        /// </summary>
        /// <param name="employee"></param>
        void addEmployee(Employee employee);
        /// <summary>
        /// the fuction removes employee
        /// </summary>
        /// <param name="IDEmployee"></param>
        /// <returns></returns>
        bool removeEmployee(int IDEmployee);
        /// <summary>
        /// the fuction updates employee
        /// </summary>
        /// <param name="employee"></param>
        void updateEmployee(Employee employee);
        /// <summary>
        /// the fuction returns employee according to ID-employee
        /// </summary>
        /// <param name="IDEmployee"></param>
        /// <returns></returns>
        Employee getEmployee(int IDEmployee);
        /// <summary>
        /// the fuction adds employer
        /// </summary>
        /// <param name="employer"></param>
        void addEmployer(Employer employer);
        /// <summary>
        /// the fuction removes employer
        /// </summary>
        /// <param name="IDEmployer"></param>
        /// <returns></returns>
        bool removeEmployer(int IDEmployer);
        /// <summary>
        /// the fuction updates employer
        /// </summary>
        /// <param name="employer"></param>
        void updateEmployer(Employer employer);
        /// <summary>
        /// the fuction returns employer according to ID-employer
        /// </summary>
        /// <param name="IDEmployer"></param>
        /// <returns></returns>
        Employer getEmployer(int IDEmployer);
        /// <summary>
        /// the fuction adds contract
        /// </summary>
        /// <param name="contract"></param>
        void addContract(Contract contract);
        /// <summary>
        /// the fuction removes contract
        /// </summary>
        /// <param name="IDContract"></param>
        /// <returns></returns>
        bool removeContract(int IDContract);
        /// <summary>
        /// the fuction updates contract
        /// </summary>
        /// <param name="contract"></param>
        void updateContract(Contract contract);
        /// <summary>
        /// the fuction returns contract according to ID-contract
        /// </summary>
        /// <param name="IDContract"></param>
        /// <returns></returns>
        Contract getContract(int IDContract);
        /// <summary>
        /// the program adds user to the program
        /// </summary>
        /// <param name="user"></param>
        void addUser(HTC_User_Account user);
        /// <summary>
        /// the program removes user from the contract
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool removeUser(string userName);
        /// <summary>
        /// the function returns user of the program by the user name
        /// </summary>
        /// <param name="userName">the user name to check</param>
        /// <returns></returns>
        HTC_User_Account getUser(string userName);
       
        /// <summary>
        /// the function returns all specializations, according the predicat. 
        /// </summary>
        /// <param name="predicat">checks which specialization should be returned</param>
        /// <returns></returns>
        IEnumerable<Specialization> GetAllSpecializations(Func<Specialization, bool> predicat = null);
        /// <summary>
        /// the function returns all employees, according the predicat.
        /// </summary>
        /// <param name="predicat">checks which employee should be returned</param>
        /// <returns></returns>
        IEnumerable<Employee> GetAllEmployees(Func<Employee, bool> predicat = null);
        /// <summary>
        /// the function returns all employers, according the predicat.
        /// </summary>
        /// <param name="predicat">checks which employer should be returned</param>
        /// <returns></returns>
        IEnumerable<Employer> GetAllEmployers(Func<Employer, bool> predicat = null);
        /// <summary>
        ///  the function returns all contracts, according the predicat.
        /// </summary>
        /// <param name="predicat">checks which contract should be returned</param>
        /// <returns></returns>
        IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicat = null);
        /// <summary>
        ///  the function returns all bank-accounts, according the predicat.
        /// </summary>
        /// <param name="predicat">checks which bank account should be returned</param>
        /// <returns></returns>
        IEnumerable<BankAcount> GetAllBankAcounts(Func<BankAcount, bool> predicat = null);

        bool banksDownloaded();

        /// <summary>
        /// return list of banks from static list
        /// </summary>
        /// <returns></returns>
        IEnumerable<BankAcount> GetBankAcountsList(Func<BankAcount, bool> predicat = null);
        /// <summary>
        /// return employee list from static list
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployeesList();
        /// <summary>
        /// return all employers from static list
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employer> GetEmployersList();
        /// <summary>
        /// return all specialization from static list
        /// </summary>
        /// <returns></returns>
        IEnumerable<Specialization> GetSpecializationsList();
        /// <summary>
        /// get employees from static list
        /// </summary>
        /// <param name="IDEmployee"></param>
        /// <returns></returns>
        Employee getEmployeeFromList(int IDEmployee);

        /// <summary>
        /// get employers from list
        /// </summary>
        /// <param name="IDEmployer"></param>
        /// <returns></returns>
        Employer getEmployerFromList(int IDEmployer);

        /// <summary>
        /// get specialization from list
        /// </summary>
        /// <param name="IDSpecialization"></param>
        /// <returns></returns>
        Specialization getSpecializationFromList(int IDSpecialization);

        /// <summary>
        /// resets the XML file with all the running codes
        /// </summary>
        void addID();    
    }
}
