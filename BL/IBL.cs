using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// add specialization to data
        /// </summary>
        /// <param name="specialization">specialization to add</param>
        void addSpecialization(Specialization specialization);
        /// <summary>
        /// removes specialization from data
        /// </summary>
        /// <param name="IDSpecialization"></param>
        /// <returns></returns>
        bool removeSpecialization(int IDSpecialization);
        /// <summary>
        /// updates specialization in data
        /// </summary>
        /// <param name="specialization"></param>
        void updateSpecialization(Specialization specialization);
        /// <summary>
        /// gets specialization from data
        /// </summary>
        /// <param name="IDSpecialization"></param>
        /// <returns></returns>
        Specialization getSpecialization(int IDSpecialization);

        /// <summary>
        /// adds employe to data
        /// </summary>
        /// <param name="employee"></param>
        void addEmployee(Employee employee);
        /// <summary>
        /// removes employee from data
        /// </summary>
        /// <param name="IDEmployee"></param>
        /// <returns></returns>
        bool removeEmployee(int IDEmployee);

        /// <summary>
        /// updates employee in data
        /// </summary>
        /// <param name="employee"></param>
        void updateEmployee(Employee employee);
        /// <summary>
        /// gets employee from data
        /// </summary>
        /// <param name="IDEmployee"></param>
        /// <returns></returns>
        Employee getEmployee(int IDEmployee);

        /// <summary>
        /// adds employer to data
        /// </summary>
        /// <param name="employer"></param>
        void addEmployer(Employer employer);
        /// <summary>
        /// removes employer from data
        /// </summary>
        /// <param name="IDEmployer"></param>
        /// <returns></returns>
        bool removeEmployer(int IDEmployer);
        /// <summary>
        /// updats employer in data
        /// </summary>
        /// <param name="employer"></param>
        void updateEmployer(Employer employer);
        /// <summary>
        /// gets employer from data
        /// </summary>
        /// <param name="IDEmployer"></param>
        /// <returns></returns>
        Employer getEmployer(int IDEmployer);

        /// <summary>
        /// adds contract to data
        /// </summary>
        /// <param name="contract"></param>
        void addContract(Contract contract);
        /// <summary>
        /// removes contract to data
        /// </summary>
        /// <param name="IDContract"></param>
        /// <returns></returns>
        bool removeContract(int IDContract);
        /// <summary>
        /// updates contract in data
        /// </summary>
        /// <param name="contract"></param>
        void updateContract(Contract contract);
        /// <summary>
        /// gets contract from data
        /// </summary>
        /// <param name="IDContract"></param>
        /// <returns></returns>
        Contract getContract(int IDContract);
       
        /// <summary>
        /// adds uder to data
        /// </summary>
        /// <param name="user"></param>
        void addUser(HTC_User_Account user);
        /// <summary>
        /// removes user from data
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool removeUser(string userName);
        /// <summary>
        /// gets user from data
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        HTC_User_Account getUser(string userName);
        

        /// <summary>
        /// gets all specialization from data according to predicat
        /// </summary>
        /// <param name="predicat">defines when to return specialization</param>
        /// <returns></returns>
        IEnumerable<Specialization> GetAllSpecializations(Func<Specialization, bool> predicat = null);
        /// <summary>
        /// gets all employees from data according to predicat
        /// </summary>
        /// <param name="predicat">defines when to return employee</param>
        /// <returns></returns>
        IEnumerable<Employee> GetAllEmployees(Func<Employee, bool> predicat = null);
        /// <summary>
        /// gets all employers from data according to predicat
        /// </summary>
        /// <param name="predicat">defines when to return employee</param>
        /// <returns></returns>
        IEnumerable<Employer> GetAllEmployers(Func<Employer, bool> predicat = null);
        /// <summary>
        /// gets all contracts from data according to predicat
        /// </summary>
        /// <param name="predicat">defines when to return employee</param>
        /// <returns></returns>
        IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicat = null);
        /// <summary>
        /// gets all bank accounts from data
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        IEnumerable<BankAcount> GetAllBankAcounts(Func<BankAcount, bool> predicat = null);
        
        /// <summary>
        /// checks how long ago the company was established
        /// </summary>
        /// <param name="employerID"></param>
        /// <returns></returns>                 
        bool checkAgeOfCompany(int employerID);  
        /// <summary>
        /// return number of contracts according to predicat
        /// </summary>
        /// <param name="predicat">defines which contract to count</param>
        /// <returns></returns>         
        int GetNumOfContracts(Func<Contract, bool> predicat = null);
        /// <summary>
        /// groups contracts by specialization
        /// </summary>
        /// <param name="order">if group should be in order</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Contract>> ContractsBySpecialization(bool order);
        /// <summary>
        /// groups contracts by city of employee
        /// </summary>
        /// <param name="order">if group should be in order</param>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Contract>> ContractsByCity(bool order);
        /// <summary>
        /// groups revenue of company by year until this year
        /// </summary>
        /// <param name="order">if group should be in order</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, double>> BenefitsByYearTillNow(bool order);

        //these functions are extra and there more in the ibl_imp
        /// <summary>
        /// groups revenueof HTC company by year for the next ten years
        /// </summary>
        /// <param name="order">if group should be in order</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, double>> BenefitsByYearForNextDecade(bool order);
        /// <summary>
        /// groups revenue of company by month for specific year
        /// </summary>
        /// <param name="order">if group should be in order</param>
        /// <param name="year">which year to calculate</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, double>> BenefitsBymonthForAYear(bool order, int year);
        /// <summary>
        /// groups company revenue between year spam by month
        /// </summary>
        /// <param name="order">if group should be in order</param>
        /// <param name="yearBegin">the beggining year to calculate</param>
        /// <param name="yearEnd">theend year to calculate</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, IEnumerable< IGrouping<int, double>>>> groupOfEarningsDevidedByYearsAndMonth(bool order, int yearBegin, int yearEnd);
        /// <summary>
        /// sends email once a new user finishes creating account
        /// </summary>
        /// <param name="recieverEmailaddress">the recievers email address</param>
        void emailConfirmation(string recieverEmailaddress);
        /// <summary>
        /// sends an email to employee or employer
        /// </summary>
        /// <param name="receiverID">the id of the reciever</param>
        /// <param name="emailSubject">the subject of the email</param>
        /// <param name="emailBody">the body of the email</param>
        void emailSender(int receiverID, string emailSubject, string emailBody);
        /// <summary>
        /// groups employers by area in country
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<Area, Employer>> employersByArea();
        /// <summary>
        /// calculates the entire pension of employee
        /// </summary>
        /// <param name="contract">in given contract</param>
        /// <returns></returns>
        double calculatePension(Contract contract);
        /// <summary>
        /// calculates the net salery of employee in contract
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        double employeesNetoAfterCalculation(Contract contract);
        /// <summary>
        /// checks if employee is already working in a different contract
        /// </summary>
        /// <param name="newContract"></param>
        /// <returns></returns>
        bool checkIfEmployeeIsAlreadyWorking(Contract newContract);

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
