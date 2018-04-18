using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Net.Mail;
using System.Threading;

namespace BL
{
    internal class IBL_imp : IBL
    {
        static Random r = new Random();
        DAL.IDAL dal;
        public IBL_imp()
        {
            dal = DAL.FactoryDal.GetDalInstance();
            //Specialization s1 = new Specialization
            //{
            //    field1 = BE.Field.ANIMATION,
            //    numberOfWorkers = 1,
            //    numOfSpecialization = 11111111,
            //    SpecializationName = "Blender",
            //    wageMax = 50000,
            //    wageMin = 5901
            //};
            //Specialization s2 = new Specialization
            //{
            //    field1 = BE.Field.SYBER,
            //    numberOfWorkers = 1,
            //    numOfSpecialization = 22222222,
            //    SpecializationName = "shut-HaTaSAa'H",
            //    wageMax = 60000,
            //    wageMin = 5501
            //};
            //Specialization s3 = new Specialization
            //{
            //    field1 = BE.Field.DATASTRUCTORS,
            //    numberOfWorkers = 1,
            //    numOfSpecialization = 33333333,
            //    SpecializationName = "Rimon",
            //    wageMax = 40000,
            //    wageMin = 5701
            //};
            //Employer em1 = new Employer
            //{
            //    freelancer = false,
            //    isCompany = true,
            //    address = "horev 14",
            //    birth = Convert.ToDateTime("11/10/2009"),
            //    companyName = "ibm",
            //    EmailAddress = "bngros@gmail.com",
            //    field1 = BE.Field.ANIMATION,
            //    phoneNum = 199646282,
            //    ID = 1001,
            //    stockValue = 50.5,
            //    ImageSource = @"/images/ibm.jpg"
            //};
            //Employer em2 = new Employer
            //{
            //    freelancer = false,
            //    isCompany = true,
            //    address = "sinai 4",
            //    birth = Convert.ToDateTime("11/10/2015"),
            //    companyName = "apple",
            //    EmailAddress = "bngros@gmail.com",
            //    field1 = BE.Field.SYBER,
            //    phoneNum = 999111343,
            //    ID = 1002,
            //    stockValue = 78.9,
            //    ImageSource = @"/images/apple.jpg"


            //};
            //Employer em3 = new Employer
            //{
            //    freelancer = false,
            //    isCompany = true,
            //    address = "kerem 12",
            //    birth = Convert.ToDateTime("11/10/2004"),
            //    companyName = "intel",
            //    EmailAddress = "bngros@gmail.com",
            //    field1 = BE.Field.DATASTRUCTORS,
            //    phoneNum = 999111343,
            //    ID = 1003,
            //    stockValue = 12.6,
            //    ImageSource = @"/images/intel.jpg",
            //};

            //BankAcount b1 = new BankAcount { bankID = 10, bankName = "@ בנק לאומי לישראל בע&quot;מ", branchAddress = "דרך האלוף עוזי נרקיס 1", branchCity = "מעלות-תרשיחא", branchID = 641 };
            //BankAcount b2 = new BankAcount { bankID = 12, bankName = "@בנק הפועלים בע&quot;מ", branchAddress = "העצמאות 40", branchCity = "באר שבע", branchID = 631 };
            //BankAcount b3 = new BankAcount { bankID = 11, bankName = "@בנק דיסקונט לישראל בע&quot;מ", branchAddress = "יפו 97", branchCity = "ירושלים", branchID = 159 };

            //Employee e1 = new Employee
            //{
            //    ID = 111111111,
            //    familyName = "soibelman",
            //    firstName = "shmuel",
            //    birth = Convert.ToDateTime("11/10/1991"),
            //    phoneNum = 029991797,
            //    CellPhoneNum = 0525981797,
            //    address = "hatziporen 11a",
            //    afterArmy = true,
            //    numOfSpecialization = 11111111,
            //    EmailAddress = "bngros@gmail.com",
            //    numOfJobs = 5,
            //    City = "beit-shemesh",
            //    degree = BE.Degree.STUDENT,
            //    status = BE.Status.ISRAEL,
            //    bankAccount = b1,
            //    _AcountNumber = 5894,
            //    imageSource = @"\images\drag&drop.png"

            //};
            //Employee e2 = new Employee
            //{
            //    ID = 222222222,
            //    familyName = "freddy",
            //    firstName = "goola",
            //    birth = Convert.ToDateTime("11/10/1901"),
            //    phoneNum = 029997797,
            //    CellPhoneNum = 0525981777,
            //    address = "yaroon 11b",
            //    afterArmy = true,
            //    numOfSpecialization = 22222222,
            //    EmailAddress = "bngros@gmail.com",
            //    numOfJobs = 3,
            //    City = "haifa",
            //    degree = BE.Degree.PHD,
            //    status = BE.Status.COHEN,
            //    _AcountNumber = 4553,
            //    bankAccount = b2,
            //    imageSource = @"\images\drag&drop.png"
            //};
            //Employee e3 = new Employee
            //{
            //    ID = 333333333,
            //    familyName = "black",
            //    firstName = "smithy",
            //    birth = Convert.ToDateTime("11/10/1905"),
            //    phoneNum = 029991111,
            //    CellPhoneNum = 0525981111,
            //    address = "bloom 12b",
            //    afterArmy = true,
            //    numOfSpecialization = 33333333,
            //    EmailAddress = "bngros@gmail.com",
            //    numOfJobs = 3,
            //    City = "ako",
            //    _AcountNumber = 2457,
            //    degree = BE.Degree.MA,
            //    status = BE.Status.LEVI,
            //    bankAccount = b3,
            //    imageSource = @"\images\drag&drop.png"
            //};
            //Contract c1 = new Contract
            //{
            //    contractNum = 61361361,
            //    contractSignd = true,
            //    employeeID = 111111111,
            //    employerID = 1001,
            //    employementBegin = Convert.ToDateTime("11/03/2017"),
            //    employementEnd = Convert.ToDateTime("12/3/2018"),
            //    gross = 15000,
            //    net = 7000,
            //    interview = true,
            //    monthHours = 183,
            //    TORADayNum = 1,
            //    DaysOffAYear = 14
            //};
            //Contract c2 = new Contract
            //{
            //    contractNum = 62062062,
            //    contractSignd = true,
            //    employeeID = 222222222,
            //    employerID = 1002,
            //    employementBegin = Convert.ToDateTime("12/3/2019"),
            //    employementEnd = Convert.ToDateTime("12/2/2020"),
            //    gross = 12000,
            //    net = 10000,
            //    interview = true,
            //    monthHours = 181,
            //    TORADayNum = 40,
            //    DaysOffAYear = 8
            //};
            //Contract c3 = new Contract
            //{
            //    contractNum = 77777777,
            //    contractSignd = true,
            //    employeeID = 333333333,
            //    employerID = 1003,
            //    employementBegin = Convert.ToDateTime("11/3/2021"),
            //    employementEnd = Convert.ToDateTime("9/2/2022"),
            //    gross = 20000,
            //    net = 10000,
            //    interview = true,
            //    monthHours = 184,
            //    TORADayNum = 400,
            //    DaysOffAYear = 11
            //};

            //addSpecialization(s1);
            //addSpecialization(s2);
            //addSpecialization(s3);
            //addEmployee(e1);
            //addEmployee(e2);
            //addEmployee(e3);
            //addEmployer(em1);
            //addEmployer(em3);
            //addEmployer(em2);
            //addContract(c1);
            //addContract(c2);
            //addContract(c3);
        }

        public void addContract(Contract contract)
        {
            try
            {
                dal.banksDownloaded();
            }
            catch (Exception)
            {

                throw new Exception("cannot check employees details until bank file finished downloading! try again soon!");
            }
            if(checkIfEmployeeIsAlreadyWorking(contract)==true) throw new Exception("the employee has a different contract between these dates!");
            if (contract.monthHours > 184) throw new Exception("too much hours! what about TORA!?!?!?");
            if (contract.DaysOffAYear <  6) throw new Exception("cannot have less then 6 days off a year ");                      
            Employer employer = getEmployer(contract.employerID);
            if (employer == null) throw new Exception("cannot add contract! employer does not exsist!");
            Employee employee = getEmployee(contract.employeeID);
            if (employee == null) throw new Exception("cannot add contract! employee does not exsist!");
            if (employer.field1 != getSpecialization(employee.numOfSpecialization).field1) throw new Exception("employee doesn't work in the employer's field");
            IEnumerable<BankAcount> b = GetAllBankAcounts().Distinct();
            List<BankAcount> a = b.ToList();
            List<BankAcount> accountss = GetAllBankAcounts(s =>
            s.bankName == employee.bankAccount.bankName &&
            s.branchID == employee.bankAccount.branchID &&
            s.branchCity == employee.bankAccount.branchCity).ToList();
            if (contract.employementBegin >= contract.employementEnd) throw new Exception("which dates ,are you NINKAMPUP!?!?!?!?");
            if (contract.monthHours < 100) throw new Exception("work more!!!");
            if (accountss.Count==0) throw new Exception("employee does not have correct bank account information");           
            if (!checkAgeOfCompany(employer.ID)) throw new Exception("the company is too new");
            contract.net = employeesNetoAfterCalculation(contract);
            contract.Pension = calculatePension(contract);
            if (contract.net < ((dal.getSpecialization(employee.numOfSpecialization)).wageMin)) throw new Exception("employees getting paid less then the minimum wage!"); 
            if (contract.net > ((dal.getSpecialization(employee.numOfSpecialization)).wageMax)) throw new Exception("employees getting paid more then the maximum wage!");
           // if (employer.NumOfEmployees >= employer.NumOfEmployeesNeeded) throw new Exception("you cannot have more employees then what you need!");
            dal.addContract(contract);         
         }

        public void addEmployee(Employee employee)
        {
            if (employee.ID < 100000000 || employee.ID > 1000000000) throw new Exception("invalid employee's id");
            if (employee.CellPhoneNum < 10000000) throw new Exception("invalid employee's cell number");
            if (employee.phoneNum < 10000000) throw new Exception("invalid employee's phone number");
            if (employee.firstName == "") throw new Exception("you must enter a name");
            if (employee.familyName == "") throw new Exception("you must enter last name");
            if (employee.phoneNum == 0) throw new Exception("you must enter phone number");
            if (employee.CellPhoneNum == 0) throw new Exception("you must enter cell phone number");
            if (employee.City == "") throw new Exception("you must enter city");
            if (employee.address == "") throw new Exception("you must enter address");
            if (employee.EmailAddress == "") throw new Exception("you must enter email address");
            if (!((employee.EmailAddress.EndsWith(".com") ||
                employee.EmailAddress.EndsWith(".co.il") ||
                employee.EmailAddress.EndsWith(".ac.il") ||
                employee.EmailAddress.EndsWith(".net") ||
                employee.EmailAddress.EndsWith(".org")) && employee.EmailAddress.Contains('@') && employee.EmailAddress.IndexOf('@') < employee.EmailAddress.IndexOf('.')))
                throw new Exception("invalid email address!");

            //there is no reason to check if account number is alraedy used since the bank is full of accounts already...

            if(employee._AcountNumber==0) throw new Exception("invalid account number");                     
            if (employee.numOfJobs < 0) throw new Exception("invalid number of jubs");
            TimeSpan age = DateTime.Now - employee.birth;
            if (age.Days / 365 < 25) throw new Exception("Too young, go to YESHIVA!!!");          
            dal.addEmployee(employee);
        }

        public void addEmployer(Employer employer)
        {
            if (employer.freelancer == true)
            {
                if (employer.firstName == "") throw new Exception("must enter first name!");
                if (employer.familyName == "") throw new Exception("must enter last name!");
                if (employer.ID < 100000000 || employer.ID > 1000000000) throw new Exception("invalid employer's id");
            }
            if (employer.phoneNum < 10000000) throw new Exception("invalid employer's phone number");
            if (employer.companyName == "" && employer.freelancer == false) throw new Exception("must enter company name!");
            if (employer.phoneNum == 0) throw new Exception("must enter phone number!");
            if (employer.EmailAddress == "") throw new Exception("must enter email address!");
            if (!((employer.EmailAddress.EndsWith(".com") ||
                employer.EmailAddress.EndsWith(".co.il") ||
                employer.EmailAddress.EndsWith(".ac.il") ||
                employer.EmailAddress.EndsWith(".net") ||
                employer.EmailAddress.EndsWith(".org")) && employer.EmailAddress.Contains('@') && employer.EmailAddress.IndexOf('@') < employer.EmailAddress.IndexOf('.')))
                throw new Exception("invalid email address!");
            if (employer.address == "") throw new Exception("must enter address!");           
            if (employer.freelancer == true) employer.companyName = employer.firstName + " " + employer.familyName;
            dal.addEmployer(employer);
        }

        public void addSpecialization(Specialization specialization)
        {
            List<Contract> contracts = dal.GetAllContract(s => getEmployee(s.employeeID).numOfSpecialization == specialization.numOfSpecialization).ToList();            
            List<Specialization> special = dal.GetAllSpecializations(s=> (s.SpecializationName== specialization.SpecializationName) &&(s.field1==specialization.field1)).ToList();
            if (special.Count > 0) throw new Exception("this specialization already exits!");
            if (specialization.SpecializationName.Length == 0) throw new Exception("must enter Value for name!");
            if (specialization.wageMin < 5000) throw new Exception("minimum wage cannot be less then 5000");
            if (specialization.wageMin == 0) throw new Exception("must enter value for minimum wage");
            if (specialization.wageMax <= specialization.wageMin) throw new Exception("minimum wage cannot be bigger or equals to maximum wage!");
            if (specialization.wageMax == 0) throw new Exception("must enter value for maximum wage");

            dal.addSpecialization(specialization);
        }

        public Contract getContract(int IDContract)
        {
            return dal.getContract(IDContract);
        }

        public Employee getEmployee(int IDEmployee)
        {
           return dal.getEmployee(IDEmployee);
        }

        public Employer getEmployer(int IDEmployer)
        {
            return dal.getEmployer(IDEmployer);
        }

        public Specialization getSpecialization(int IDSpecialization)
        {
            return dal.getSpecialization(IDSpecialization);
        }
            
        public void updateContract(Contract contract)
        {
            try
            {
                dal.banksDownloaded();
            }
            catch (Exception ex)
            {

                throw new Exception("cannot check employees details until bank file finished downloading! try again soon!");
            }
            if (contract.monthHours < 100) throw new Exception("work more!!!");
            if (contract.employementBegin >= contract.employementEnd) throw new Exception("which dates ,are you NINKAMPUP!?!?!?!?");
            if (checkIfEmployeeIsAlreadyWorking(contract) == true) throw new Exception("the employee has a different contract between these dates!");
            if (contract.DaysOffAYear <  6) throw new Exception("cannot have less then 6 days off a year ");//        
            Employer employer = getEmployer(contract.employerID);
            if (employer == null) throw new Exception("cannot add contract! employee does not exsist!");
            Employee employee = getEmployee(contract.employeeID);
            List<BankAcount> accountss = GetAllBankAcounts(s =>
            s.bankName==employee.bankAccount.bankName &&
            s.branchID==employee.bankAccount.branchID &&
            s.branchCity==employee.bankAccount.branchCity).ToList();
            if (accountss.Count == 0) throw new Exception("employee does not have correct bank account information");
            if (employee == null) throw new Exception("cannot add contract! employee does not exsist!");
            if (!checkAgeOfCompany(employer.ID)) throw new Exception("the company is too new");
            contract.net = employeesNetoAfterCalculation(contract);
            contract.Pension = calculatePension(contract);
            if (contract.net < ((dal.getSpecialization(employee.numOfSpecialization)).wageMin)) throw new Exception("employees getting paid less then the minimum wage!");
            if (contract.net > ((dal.getSpecialization(employee.numOfSpecialization)).wageMax)) throw new Exception("employees getting paid more then the maximum wage!");           
            if (contract.monthHours > 184) throw new Exception("too much hours! what about TORA!?!?!?");
            dal.updateContract(contract);                           
        }

        public void updateEmployee(Employee employee)
        {
            if (employee.CellPhoneNum < 10000000) throw new Exception("invalid employee's cell number");
            if (employee.phoneNum < 10000000) throw new Exception("invalid employee's cell number");
            if (employee.ID < 100000000 || employee.ID > 1000000000) throw new Exception("invalid employee's id");
            if (employee.firstName == "") throw new Exception("you must enter a name");
            if (employee.familyName == "") throw new Exception("you must enter last name");
            if (employee.phoneNum == 0) throw new Exception("you must enter phone number");
            if (employee.CellPhoneNum == 0) throw new Exception("you must enter cell phone number");
            if (employee.City == "") throw new Exception("you must enter city");
            if (employee.address == "") throw new Exception("you must enter address");
            if (employee.EmailAddress == "") throw new Exception("you must enter email address");
            if (!((employee.EmailAddress.EndsWith(".com") ||
                employee.EmailAddress.EndsWith(".co.il") ||
                employee.EmailAddress.EndsWith(".ac.il") ||
                employee.EmailAddress.EndsWith(".net") ||
                employee.EmailAddress.EndsWith(".org")) && employee.EmailAddress.Contains('@') && employee.EmailAddress.IndexOf('@') < employee.EmailAddress.IndexOf('.')))
                throw new Exception("invalid email address!");
            if (employee._AcountNumber == 0) throw new Exception("invalid account number");
            //there is no reason to check if account number is alraedy used since the bank is full of accounts already...            
            if (employee.numOfJobs < 0) throw new Exception("invalid number of jubs");
            TimeSpan age = DateTime.Now - employee.birth;
            if (age.Days / 365 < 25) throw new Exception("too young, go to yeshiva!!!");
            List<Contract> listC = GetAllContract(s=>s.employeeID==employee.ID).ToList();
            foreach (Contract item in listC)
            {
                if (getEmployer(item.employerID).field1 != getSpecialization(employee.numOfSpecialization).field1) throw new Exception("cannot change employees specialization! he is working for a company that needs it!");
            }
            dal.updateEmployee(employee);
        }

        public void updateEmployer(Employer employer)
        {
            if (employer.freelancer == true)
            {
                if (employer.firstName == "") throw new Exception("must enter first name!");
                if (employer.familyName == "") throw new Exception("must enter last name!");
                if (employer.ID < 100000000 || employer.ID > 1000000000) throw new Exception("invalid employee's id");
            }
            if (employer.phoneNum < 10000000) throw new Exception("invalid employee's cell number");
            if (employer.companyName == "" && employer.freelancer == false) throw new Exception("must enter company name!");
            if (employer.phoneNum == 0) throw new Exception("must enter phone number!");
            if (employer.EmailAddress == "") throw new Exception("must enter email address!");
            if (!((employer.EmailAddress.EndsWith(".com") ||
                employer.EmailAddress.EndsWith(".co.il") ||
                employer.EmailAddress.EndsWith(".ac.il") ||
                employer.EmailAddress.EndsWith(".net") ||
                employer.EmailAddress.EndsWith(".org")) && employer.EmailAddress.Contains('@') && employer.EmailAddress.IndexOf('@') < employer.EmailAddress.IndexOf('.')))
                throw new Exception("invalid email address!");
            if(employer.birth>DateTime.Now) throw new Exception("your gilgool didn't come yet!");
            if (employer.address == "") throw new Exception("must enter address!");
            if (employer.freelancer == true) employer.companyName = employer.firstName + " " + employer.familyName;
            dal.updateEmployer(employer);
        }

        public void updateSpecialization(Specialization specialization)
        {
            List<Contract> contracts = dal.GetAllContract(s=>getEmployee(s.employeeID).numOfSpecialization==specialization.numOfSpecialization).ToList();
            foreach (Contract contract in contracts)
            {
                if (specialization.wageMin > contract.net) throw new Exception(getEmployee(contract.employeeID).firstName + " " + getEmployee(contract.employeeID).familyName + " is getting paid less then minimum!");
                if (specialization.wageMax < contract.net) throw new Exception(getEmployee(contract.employeeID).firstName + " " + getEmployee(contract.employeeID).familyName + " is getting paid more then maximum!");
            }
            if (specialization.SpecializationName.Length == 0) throw new Exception("must enter Value for name!");
            if (specialization.wageMin < 5000) throw new Exception("minimum wage cannot less then 5000");
            if (specialization.wageMax <= specialization.wageMin) throw new Exception("minimum wage cannot be bigger or equals to maximum wage!");
            dal.updateSpecialization(specialization);
        }

        public bool removeContract(int IDContract)
        {
            return dal.removeContract(IDContract);
        }

        public bool removeEmployee(int IDEmployee)
        {
            List<Contract> contracts = dal.GetAllContract(s => s.employeeID == IDEmployee).ToList();
            if (contracts.Count != 0) throw new Exception(getEmployee(IDEmployee).firstName + getEmployee(IDEmployee).familyName + " is in a contract: " + contracts[0].contractNum);
            return dal.removeEmployee(IDEmployee);
        }

        public bool removeEmployer(int IDEmployer)
        {
            List<Contract> contracts = dal.GetAllContract(s => s.employerID == IDEmployer).ToList();
            if (contracts.Count != 0) throw new Exception(getEmployer(IDEmployer).companyName + " is in a contract: " + contracts[0].contractNum);
            return dal.removeEmployer(IDEmployer);
        }

        public bool removeSpecialization(int IDSpecialization)
        {
            List<Employee> employees = dal.GetAllEmployees(s => s.numOfSpecialization == IDSpecialization).ToList();
            if (employees.Count != 0) throw new Exception(employees[0].firstName + " " + employees[0].familyName + " has this specialization!");
            return dal.removeSpecialization(IDSpecialization);
        }       
       
        public bool checkAgeOfCompany(int employerID)
        {
            Employer employer = getEmployer(employerID);
            if (employer == null) throw new Exception("employer does not exsist");
            TimeSpan age = DateTime.Now - employer.birth;
            if (age.Days / 365 >= 1) return true;
            else return false;
        }

        public double calculateNetoByEmployee(Contract contract)
        {            
            double amla = 15;
            
            amla -= getEmployee(contract.employeeID).numOfJobs;
            if (amla > 5)
            {
                 return (double)(contract.gross)*((100 - amla) / 100);
            }
            return contract.gross * (0.95);
        }

        public Double calculateNetoByEmployer(Contract contract)
        {
            double amla = 15;
            
            amla -= getEmployer(contract.employerID).NumOfEmployees;
            if (amla > 3)
            {
                return (double)(contract.gross) * ((100 - amla) / 100);
            }
            return contract.gross * (0.97);
        }
        public double employeesNetoAfterCalculation(Contract contract)//average of calculate according to employer and employee
        {            
            return  (calculateNetoByEmployee(contract) + calculateNetoByEmployer(contract))/2;            
        } 
        /// <summary>
        /// the company revenue from a contract by month
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public double monthlyEarningsFromContract(int contractNum)
        {
            Contract contract = getContract(contractNum);
            if (contract.contractSignd == false) return 0;
            return (double)(contract.gross) - contract.net;
        }

        /// <summary>
        /// how much company earns in specific year and month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public double monthInYearEarnings(int year, int month)
        {
            double monthSum=0;
            List<Contract> list = GetAllContract
                (s=>((s.employementBegin.Year ==year&& s.employementBegin.Year==s.employementEnd.Year)&&(s.employementBegin.Month<=month&&s.employementEnd.Month>=month))||
                    ((s.employementBegin.Year != s.employementEnd.Year)&&
                        ((s.employementBegin.Year ==year && s.employementBegin.Month <= month)||
                        (s.employementEnd.Year==year && s.employementEnd.Month >= month)))||
                    (s.employementBegin.Year < year&&s.employementEnd.Year > year)).ToList();
            foreach (var contract in list)
            {
                if(contract.contractSignd==true) monthSum += (double)(contract.gross) - contract.net;
            }
            return monthSum;
        }
        /// <summary>
        /// how much the company earns from a contract in a given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public double yearlyEarningsFromContract(int year)
        {
            double sumy = 0;
            List<Contract> list = GetAllContract(null).ToList();
            foreach (var item in list)
            {
                if (year >= item.employementBegin.Year && year <= item.employementEnd.Year)
                {
                    if (year == item.employementBegin.Year)
                    {
                        if(item.employementBegin.Year== item.employementEnd.Year)
                            sumy+= (1+item.employementEnd.Month - item.employementBegin.Month) * monthlyEarningsFromContract(item.contractNum);
                        else
                            sumy += (13 - item.employementBegin.Month) * monthlyEarningsFromContract(item.contractNum);
                    }
                    else if (year == item.employementEnd.Year)
                        sumy += (item.employementEnd.Month) * monthlyEarningsFromContract(item.contractNum);
                    else
                        sumy += 12 * monthlyEarningsFromContract(item.contractNum);
                }
            }

            return sumy;
        }
        /// <summary>
        /// the amount the company earns from a contract
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public double earningFromContract(int contractNum)
        {
            int months;
            TimeSpan range;
            Contract contract = getContract(contractNum);
            if (DateTime.Now < contract.employementEnd)
            {
                range = DateTime.Now - contract.employementBegin;
            }
            else
            {
                range = contract.employementEnd - contract.employementBegin;
            }
            months = (range.Days) / 30;
            return months * monthlyEarningsFromContract(contractNum);
        }

        public int GetNumOfContracts(Func<Contract, bool> predicat = null)
        {
            List<Contract> list =  GetAllContract(predicat).ToList();
            return list.Count;            
        }
      /// <summary>
      /// confirmation email if user created an account
      /// </summary>
      /// <param name="recieverEmailaddress"></param>
        public void emailConfirmation(string recieverEmailaddress)
        {           
            MailMessage mail = new MailMessage("highTekContracts@gmail.com", recieverEmailaddress, "Account confirmation", "congratulations! you are now part of the HTC family!");
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("highTekContracts", "HT123456");
            client.EnableSsl = true;
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                // Create and show the Window
                client.Send(mail);
                // Start the Dispatcher Processing
                System.Windows.Threading.Dispatcher.Run();
            }));
            // Set the apartment state
            newWindowThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            newWindowThread.IsBackground = true;
            // Start the thread
            newWindowThread.Start();
            
        }
        /// <summary>
        /// it sends email to employer or employee
        /// </summary>
        /// <param name="receiverID">the reciever's id</param>
        /// <param name="emailSubject">the email subject</param>
        /// <param name="emailBody">the email body</param>
        public void emailSender(int receiverID, string emailSubject, string emailBody)
        {
            string emailreceiver;
            Employer employer = getEmployer(receiverID);
            Employee employee = getEmployee(receiverID);
            if (employer != null) emailreceiver = employer.EmailAddress;
            else if (employee != null) emailreceiver = employee.EmailAddress;
            else throw new Exception("Employer with this id not found...");
            MailMessage mail = new MailMessage("highTekContracts@gmail.com", emailreceiver, emailSubject, emailBody);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("highTekContracts", "HT123456");
            client.EnableSsl = true;
            client.Send(mail);
        }       

        public IEnumerable<BankAcount> GetAllBankAcounts(Func<BankAcount, bool> predicat = null)
        {
            return dal.GetAllBankAcounts(predicat);
        }

        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicat = null)
        {
            return dal.GetAllContract(predicat);
        }

        public IEnumerable<Employee> GetAllEmployees(Func<Employee, bool> predicat = null)
        {
            return dal.GetAllEmployees(predicat);
        }

        public IEnumerable<Employer> GetAllEmployers(Func<Employer, bool> predicat = null)
        {
            return dal.GetAllEmployers(predicat);
        }

        public IEnumerable<Specialization> GetAllSpecializations(Func<Specialization, bool> predicat = null)
        {
            return dal.GetAllSpecializations(predicat);
        }
       

        public IEnumerable<IGrouping<int,Contract>> ContractsBySpecialization(bool order)
        {
           var result1 = from Contracts in GetAllContract(null)
                         group Contracts by getEmployee(Contracts.employeeID).numOfSpecialization;
            
            
           var result2 = from Contracts in GetAllContract(null)
                         orderby getEmployee(Contracts.employeeID).numOfSpecialization
                         group Contracts by getEmployee(Contracts.employeeID).numOfSpecialization;


            if (order) return result2;
            return result1;           
        }
        
        public IEnumerable<IGrouping<string, Contract>> ContractsByCity(bool order)
        {
            var result1 = from Contracts in GetAllContract(null)
                          group Contracts by getEmployee(Contracts.employeeID).City;
                          

            var result2 = from Contracts in GetAllContract(null)
                          orderby Contracts.employementBegin
                          group Contracts by getEmployee(Contracts.employeeID).City;

            if (order) return result2;
            return result1;
        }
        /// <summary>
        /// group of benefits by year until today
        /// </summary>
        /// <param name="order">if group should be in order</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, double>> BenefitsByYearTillNow(bool order)
        {
            int[] array = new int[DateTime.Now.Year - 2001];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            var result1 = from year in array
                          let realYear = 2001 + year
                          let temp = yearlyEarningsFromContract(realYear)
                          group temp by realYear;

            var result2 = from year in array
                          let realYear = 2001 + year
                          let temp = yearlyEarningsFromContract(realYear)
                          orderby realYear
                          group temp by realYear;
            if (order)
                return result2;
            return result1;
        }
        /// <summary>
        /// group of revenue of company for specific year by month
        /// </summary>
        /// <param name="order"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, double>> BenefitsBymonthForAYear(bool order, int year)
        {          
            int[] array = new int[12];
            for (int i = 1; i <= array.Length; i++)
            {
                array[i-1] = i;
            }
            IEnumerable<IGrouping<int, double>> 
                result1 = from month in array
                          let temp = monthInYearEarnings(year,month)
                          group temp by month;

            IEnumerable<IGrouping<int, double>>
                result2 = from month in array
                          let temp = monthInYearEarnings(year, month)
                          orderby month
                          group temp by month;

            if (order)
                return result2;
            return result1;
        }
        /// <summary>
        /// revenue of company grouped by year and month
        /// </summary>
        /// <param name="order"></param>
        /// <param name="yearBegin"></param>
        /// <param name="yearEnd"></param>
        /// <returns></returns>
        public  IEnumerable<IGrouping<int, IEnumerable< IGrouping<int, double>>>>groupOfEarningsDevidedByYearsAndMonth(bool order,int yearBegin,int yearEnd)
        {
            int[] array = new int[yearEnd-yearBegin+1];
            for (int i = 0; i <array.Length; i++)
            {
                array[i] = i;
            }           
            var result1 = from year in array
                          let realYear = yearBegin + year
                          let temp = BenefitsBymonthForAYear(order, realYear)
                          group temp by realYear;
            return result1;
        }

        bool ifContractIsWithinYear(Contract contract, int year)
        {
            if (contract.employementBegin.Year <= year && contract.employementEnd.Year >= year)
                return true;
            return false;
        }
        /// <summary>
        /// revenue of company for next decade
        /// </summary>
        /// <param name="order">if to return group in order</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, double>> BenefitsByYearForNextDecade(bool order)
        {
            int[] array = new int[11];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            var result1 = from year in array
                          let realYear = DateTime.Now.Year + year
                          let temp = yearlyEarningsFromContract(realYear)
                          group temp by realYear;

            var result2 = from year in array
                          let realYear = DateTime.Now.Year + year
                          let temp = yearlyEarningsFromContract(realYear)
                          orderby realYear
                          group temp by realYear;
            if (order)
                return result2;
            return result1;
        }
        /// <summary>
        /// groups employers by area
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<Area, Employer>> employersByArea()
        {
            var group1 = from employers in GetAllEmployers(s=>s.NumOfEmployeesNeeded>=0)
                          orderby employers.field1
                          group employers by employers.area;
            return group1;
        }
       
        /// <summary>
        /// calculates entire pension(number of months times 0.3 of the net)
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public double calculatePension(Contract contract)
        {           
            Employee employee = getEmployee(contract.employeeID);
            TimeSpan months = contract.employementEnd - contract.employementBegin;
            if (months.Days / 30 == 0) return contract.net * 0.3;
            else return (months.Days / 30) * (contract.net * 0.3);
        }
        /// <summary>
        /// confirm that an employee isn't working in two contracts at once
        /// </summary>
        /// <param name="newContract"></param>
        /// <returns></returns>
        public bool checkIfEmployeeIsAlreadyWorking(Contract newContract)
        {
            List<Contract> contracts = GetAllContract(s => s.employeeID == newContract.employeeID).ToList();
            foreach (Contract contract in contracts)
            {
                if ((newContract.employementBegin < contract.employementBegin && newContract.employementEnd > contract.employementBegin) || 
                    (newContract.employementBegin > contract.employementBegin && newContract.employementEnd < contract.employementEnd)) return true;              
            }
            return false;
        }

        public void addUser(HTC_User_Account user)
        {
            dal.addUser(user);
        }

        public bool removeUser(string userName)
        {
            return dal.removeUser(userName);
        }

        public HTC_User_Account getUser(string userName)
        {
           return dal.getUser(userName);
        }

        public bool banksDownloaded()
        {
            return dal.banksDownloaded();
        }

        public IEnumerable<BankAcount> GetBankAcountsList(Func<BankAcount, bool> predicat = null)
        {
            return dal.GetBankAcountsList(predicat);
        }

        public IEnumerable<Employee> GetEmployeesList()
        {
            return dal.GetEmployeesList();
        }

        public IEnumerable<Employer> GetEmployersList()
        {
            return dal.GetEmployersList();
        }

        public IEnumerable<Specialization> GetSpecializationsList()
        {
           return dal.GetSpecializationsList();
        }

        public Employee getEmployeeFromList(int IDEmployee)
        {
            return dal.getEmployeeFromList(IDEmployee);
        }

        public Employer getEmployerFromList(int IDEmployer)
        {
            return dal.getEmployerFromList(IDEmployer);
        }

        public Specialization getSpecializationFromList(int IDSpecialization)
        {
            return dal.getSpecializationFromList(IDSpecialization);
        }

        public void addID()
        {
            dal.addID();
        }
    }
}
