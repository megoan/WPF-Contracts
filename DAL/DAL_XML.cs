using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using DS;
using System.Net.NetworkInformation;

namespace DAL
{

    class DAL_XML : IDAL
    {
        public static List<Specialization> SpecializationList;
        public static List<Employee> EmployeeList;
        public static List<Employer> EmployerList;
        public static List<BankAcount> BankAcountList;

        IDnumbers runningNumbers = new IDnumbers();
        bool downloadFinished = false;
        bool internetConnection = false;
        WebClient wc = new WebClient();

        XElement bankRoot;
        string xmlLocalPath = @"atm.xml";


        XElement specializationRoot;
        string specializationPath = @"specializationXml.xml";


        XElement employeeRoot;
        string employeePath = @"employeeXml.xml";


        XElement employerRoot;
        string employerPath = @"employerXml.xml";


        XElement contractRoot;
        string contractPath = @"contractXml.xml";

        XElement userRoot;
        string userPath = @"userXml.xml";

        XElement IDRoot;
        string IDPath = @"IDXml.xml";

        public DAL_XML()
        {
            SpecializationList = new List<Specialization>();
            EmployeeList = new List<Employee>();
            EmployerList = new List<Employer>();
            BankAcountList = new List<BankAcount>();

            internetConnection = NetworkInterface.GetIsNetworkAvailable();
            if (internetConnection)
            {
                //trying to download banks from website
                Thread newWindowThread = new Thread(new ThreadStart(() =>
                {

                    try
                    {
                        string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                        wc.DownloadFile(xmlServerPath, xmlLocalPath);
                        downloadFinished = true;
                    }
                    catch (Exception)
                    {
                        string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                        try
                        {
                            wc.DownloadFile(xmlServerPath, xmlLocalPath);
                            downloadFinished = true;
                        }
                        catch (Exception ex)
                        {


                        }
                    }
                    finally
                    {
                        wc.Dispose();
                        if (downloadFinished == true)
                        {
                            bankRoot = XElement.Load(xmlLocalPath);
                            BankAcountList = GetAllBankAcounts().ToList();
                        }
                    }
                    System.Windows.Threading.Dispatcher.Run();
                }));

                // Set the apartment state
                //newWindowThread.SetApartmentState(ApartmentState.STA);
                // Make the thread a background thread
                newWindowThread.IsBackground = true;
                // Start the thread
                newWindowThread.Start();
            }
            else
            {
                xmlLocalPath = @"atm2.xml";
                bankRoot = XElement.Load(xmlLocalPath);
                BankAcountList = GetAllBankAcounts().ToList();
            }

            if (!File.Exists(userPath))
                CreateFiles();
            else
                LoadData();
            runningNumbers.specializationID = int.Parse(IDRoot.Elements().ToList()[0].Element("specializationID").Value);
            runningNumbers.EmployerID = int.Parse(IDRoot.Elements().ToList()[0].Element("employerID").Value);
            runningNumbers.ContractID = int.Parse(IDRoot.Elements().ToList()[0].Element("contractID").Value);
            SpecializationList = GetAllSpecializations().ToList();
            EmployeeList = GetAllEmployees().ToList();
            EmployerList = GetAllEmployers().ToList();

        }


        /// <summary>
        /// the functions add the running numbers to XML file
        /// </summary>
        public void addID()
        {
            XElement specializationID = new XElement("specializationID", runningNumbers.specializationID);
            XElement employerID = new XElement("employerID", runningNumbers.EmployerID);
            XElement contractID = new XElement("contractID", runningNumbers.ContractID);
            IDRoot.RemoveAll();
            IDRoot.Add(new XElement("IDnumbers", specializationID, employerID, contractID));

            IDRoot.Save(IDPath);
        }

        /// <summary>
        /// the function creates new XML files for the data
        /// </summary>
        private void CreateFiles()
        {
            addID();

            specializationRoot = new XElement("specializations");
            specializationRoot.Save(specializationPath);

            employeeRoot = new XElement("employees");
            employeeRoot.Save(employeePath);

            employerRoot = new XElement("employers");
            employerRoot.Save(employerPath);

            contractRoot = new XElement("contracts");
            contractRoot.Save(contractPath);

            userRoot = new XElement("users");
            userRoot.Save(userPath);

            IDRoot = new XElement("IDs");
            IDRoot.Save(IDPath);

        }

        /// <summary>
        /// if files exist the the function loads the data
        /// </summary>
        private void LoadData()
        {
            try
            {
                specializationRoot = XElement.Load(specializationPath);
                employeeRoot = XElement.Load(employeePath);
                employerRoot = XElement.Load(employerPath);
                contractRoot = XElement.Load(contractPath);
                userRoot = XElement.Load(userPath);
                IDRoot = XElement.Load(IDPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }


        /// <summary>
        /// converts a bank struct to a bank XML element
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        XElement ConvertBank(BE.BankAcount bank)
        {
            XElement bankElement = new XElement("bank");

            foreach (PropertyInfo item in typeof(BE.BankAcount).GetProperties())
                bankElement.Add
                    (
                    new XElement(item.Name, item.GetValue(bank, null))
                    );

            return bankElement;
        }
        /// <summary>
        /// converts an XML element of a bank to bank struct
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BE.BankAcount ConvertBank(XElement element)
        {
            BankAcount bank = new BankAcount();
            object boxed = bank;
            foreach (PropertyInfo item in typeof(BE.BankAcount).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element("ATMs").Element("ATM").Element(item.Name).Value);

                item.SetValue(boxed, convertValue);
            }

            return (BankAcount)boxed;
        }


        /// <summary>
        /// converts user instance to XML Element
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        XElement ConvertUser(BE.HTC_User_Account user)
        {
            XElement userElement = new XElement("user");

            foreach (PropertyInfo item in typeof(BE.HTC_User_Account).GetProperties())
                userElement.Add
                    (
                    new XElement(item.Name, item.GetValue(user, null))
                    );

            return userElement;
        }
        /// <summary>
        /// converts xml Element of user to instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BE.HTC_User_Account ConvertUser(XElement element)
        {
            HTC_User_Account user = new HTC_User_Account();

            foreach (PropertyInfo item in typeof(BE.HTC_User_Account).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(user, convertValue);
            }

            return user;
        }

        /// <summary>
        /// converts specialization instance to XML element
        /// </summary>
        /// <param name="specialization"></param>
        /// <returns></returns>
        XElement ConvertSpecialization(BE.Specialization specialization)
        {
            XElement specializationElement = new XElement("specialization");

            foreach (PropertyInfo item in typeof(BE.Specialization).GetProperties())
                specializationElement.Add
                    (
                    new XElement(item.Name, item.GetValue(specialization, null))
                    );

            return specializationElement;
        }
        /// <summary>
        /// converts specialization XML element to instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BE.Specialization ConvertSpecialization(XElement element)
        {
            Specialization specialization = new Specialization();

            foreach (PropertyInfo item in typeof(BE.Specialization).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(specialization, convertValue);
            }

            return specialization;
        }

        /// <summary>
        /// converts employee instance to XML element
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        XElement ConvertEmployee(BE.Employee employee)
        {
            XElement employeeElement = new XElement("employee");
            XElement BankElement = new XElement("bankInfo");

            foreach (PropertyInfo item in typeof(BE.Employee).GetProperties())
            {
                if (item.Name == "bankAccount")
                {
                    foreach (PropertyInfo B in typeof(BE.BankAcount).GetProperties())
                    {
                        BankElement.Add(new XElement(B.Name, B.GetValue(employee.bankAccount, null)));
                    }
                    employeeElement.Add(BankElement);
                }
                else
                {
                    employeeElement.Add(new XElement(item.Name, item.GetValue(employee, null)));
                }

            }
            return employeeElement;
        }

        /// <summary>
        /// converts employee XML element to instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BE.Employee ConvertEmployee(XElement element)
        {
            Employee employee = new Employee();
            BankAcount bank = new BankAcount();
            object boxed = bank;
            foreach (PropertyInfo item in typeof(BE.Employee).GetProperties())
            {
                TypeConverter typeConverter;
                object convertValue = null;
                TypeConverter typeConverter2;
                object convertValue2 = null;
                if (item.Name != "bankAccount")
                {
                    typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                    convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
                }
                else
                {

                    foreach (PropertyInfo B in typeof(BE.BankAcount).GetProperties())
                    {
                        typeConverter2 = TypeDescriptor.GetConverter(B.PropertyType);
                        convertValue2 = typeConverter2.ConvertFromString(element.Element("bankInfo").Element(B.Name).Value);
                        B.SetValue(boxed, convertValue2);
                    }
                    bank = (BankAcount)boxed;

                }
                item.SetValue(employee, convertValue);
            }
            employee.bankAccount = (BankAcount)bank;
            return employee;
        }

        /// <summary>
        /// converts employer instance to XML element
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        XElement ConvertEmployer(BE.Employer employer)
        {
            XElement employerElement = new XElement("employer");

            foreach (PropertyInfo item in typeof(BE.Employer).GetProperties())
                employerElement.Add
                    (
                    new XElement(item.Name, item.GetValue(employer, null))
                    );

            return employerElement;
        }
        /// <summary>
        /// converts employer XML elemnt to instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BE.Employer ConvertEmployer(XElement element)
        {
            Employer employer = new Employer();

            foreach (PropertyInfo item in typeof(BE.Employer).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(employer, convertValue);
            }

            return employer;
        }

        /// <summary>
        /// converts contract instance to XML element
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        XElement ConvertContract(BE.Contract contract)
        {
            XElement contractElement = new XElement("contract");

            foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
                contractElement.Add
                    (
                    new XElement(item.Name, item.GetValue(contract, null))
                    );

            return contractElement;
        }
        /// <summary>
        /// converts contract XML element to instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        BE.Contract ConvertContract(XElement element)
        {
            Contract contract = new Contract();

            foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);

                item.SetValue(contract, convertValue);
            }

            return contract;
        }


        /// <summary>
        /// saves user in XML
        /// </summary>
        /// <param name="user"></param>
        #region User Function
        public void addUser(HTC_User_Account user)
        {
            HTC_User_Account user1 = getUser(user.UserName);
            if (user1 != null)
                throw new Exception("user with the same number already exists...");
            userRoot.Add(ConvertUser(user));
            userRoot.Save(userPath);
        }

        /// <summary>
        /// removes user from XML
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool removeUser(string userName)
        {
            XElement toRemove = (from item in userRoot.Elements()
                                 where item.Element("userName").Value == userName
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("user with the same user name not found...");

            toRemove.Remove();

            userRoot.Save(userPath);
            return true;
        }

        /// <summary>
        /// gets user from XML
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public HTC_User_Account getUser(string userName)
        {
            XElement user = null;

            try
            {
                user = (from item in userRoot.Elements()
                        where item.Element("UserName").Value == userName
                        select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (user == null)
                return null;

            return ConvertUser(user);
        }


        #endregion

        #region Specialization Function
        /// <summary>
        /// adds specialization to XML
        /// </summary>
        /// <param name="specialization"></param>
        public void addSpecialization(Specialization specialization)
        {
            Specialization spec = getSpecialization(specialization.numOfSpecialization);
            if (spec != null)
                throw new Exception("specialization with the same number already exists...");

            runningNumbers.specializationID++;
            specialization.numOfSpecialization = runningNumbers.specializationID;
            specializationRoot.Add(ConvertSpecialization(specialization));

            specializationRoot.Save(specializationPath);
            SpecializationList = GetAllSpecializations().ToList();
        }

        /// <summary>
        /// removes specialization from XML
        /// </summary>
        /// <param name="specializationNum"></param>
        /// <returns></returns>
        public bool removeSpecialization(int specializationNum)
        {
            XElement toRemove = (from item in specializationRoot.Elements()
                                 where int.Parse(item.Element("numOfSpecialization").Value) == specializationNum
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("specialization with the same id not found...");

            toRemove.Remove();

            specializationRoot.Save(specializationPath);
            SpecializationList = GetAllSpecializations().ToList();
            return true;
        }

        /// <summary>
        /// updates specialization in XML
        /// </summary>
        /// <param name="specialization"></param>
        public void updateSpecialization(Specialization specialization)
        {

            XElement toUpdate = (from item in specializationRoot.Elements()
                                 where int.Parse(item.Element("numOfSpecialization").Value) == specialization.numOfSpecialization
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Specialization with the same id not found...");

            foreach (PropertyInfo item in typeof(BE.Specialization).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(specialization));

            specializationRoot.Save(specializationPath);
            SpecializationList = GetAllSpecializations().ToList();

        }

        /// <summary>
        /// gets specialization from XML
        /// </summary>
        /// <param name="specializationNum"></param>
        /// <returns></returns>
        public Specialization getSpecialization(int specializationNum)
        {
            XElement spec = null;

            try
            {
                spec = (from item in specializationRoot.Elements()
                        where int.Parse(item.Element("numOfSpecialization").Value) == specializationNum
                        select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (spec == null)
                return null;

            return ConvertSpecialization(spec);
        }

        /// <summary>
        /// get list of specialization from XML
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        public IEnumerable<Specialization> GetAllSpecializations(Func<Specialization, bool> predicat = null)
        {

            if (predicat == null)
            {
                return from item in specializationRoot.Elements()
                       select ConvertSpecialization(item);
            }

            return from item in specializationRoot.Elements()
                   let s = ConvertSpecialization(item)
                   where predicat(s)
                   select s;
        }
        #endregion


        #region Employee Function
        /// <summary>
        /// adds employee to XML
        /// </summary>
        /// <param name="employee"></param>
        public void addEmployee(Employee employee)
        {
            Employee e = getEmployee(employee.ID);
            if (e != null)
                throw new Exception("Employee with the same id already exists...");
            employeeRoot.Add(ConvertEmployee(employee));
            employeeRoot.Save(employeePath);
            EmployeeList = GetAllEmployees().ToList();

        }

        /// <summary>
        /// removes employee from XML
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool removeEmployee(int id)
        {
            XElement toRemove = (from item in employeeRoot.Elements()
                                 where int.Parse(item.Element("ID").Value) == id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Employee with the same id not found...");

            toRemove.Remove();
            employeeRoot.Save(employeePath);
            EmployeeList = GetAllEmployees().ToList();

            return true;
        }
        /// <summary>
        /// updates employee in XML
        /// </summary>
        /// <param name="employee"></param>
        public void updateEmployee(Employee employee)
        {
            object boxed = employee.bankAccount;
            XElement toUpdate = (from item in employeeRoot.Elements()
                                 where int.Parse(item.Element("ID").Value) == employee.ID
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Employee with the same id not found...");

            foreach (PropertyInfo item in typeof(BE.Employee).GetProperties())

                if (item.Name != "bankAccount")
                {
                    toUpdate.Element(item.Name).SetValue(item.GetValue(employee));
                }
                else
                {
                    foreach (PropertyInfo item2 in typeof(BE.BankAcount).GetProperties())
                        if (item2.Name != "type" && item2.Name != "area" && item2.Name != "coordinatesX" && item2.Name != "coordinatesY")
                            toUpdate.Element("bankInfo").Element(item2.Name).SetValue(item2.GetValue((BankAcount)boxed));
                }
            employeeRoot.Save(employeePath);
            EmployeeList = GetAllEmployees().ToList();

        }

        /// <summary>
        /// gets employee from XML
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee getEmployee(int id)
        {
            XElement employee = null;
            try
            {
                employee = (from item in employeeRoot.Elements()
                            where int.Parse(item.Element("ID").Value) == id
                            select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            if (employee == null)
                return null;
            return ConvertEmployee(employee);
        }
        /// <summary>
        /// gets all employees from XML
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllEmployees(Func<Employee, bool> predicat = null)
        {
            if (predicat == null)
            {
                return from item in employeeRoot.Elements()
                       select ConvertEmployee(item);
            }

            return from item in employeeRoot.Elements()
                   let e = ConvertEmployee(item)
                   where predicat(e)
                   select e;
        }
        #endregion

        #region Employer Function
        /// <summary>
        /// adds employer to XML
        /// </summary>
        /// <param name="employer"></param>
        public void addEmployer(Employer employer)
        {
            Employer e = getEmployer(employer.ID);
            if (e != null)
                throw new Exception("Employer with the same id already exists...");
            if (employer.isCompany == true && employer.ID == 0)

            {
                runningNumbers.EmployerID++;
                employer.ID = runningNumbers.EmployerID;
            }
            employerRoot.Add(ConvertEmployer(employer));
            employerRoot.Save(employerPath);
            EmployerList = GetAllEmployers().ToList();
        }
        /// <summary>
        /// removes employer from XML
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool removeEmployer(int id)
        {
            XElement toRemove = (from item in employerRoot.Elements()
                                 where int.Parse(item.Element("ID").Value) == id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Employer with the same id not found...");

            toRemove.Remove();
            employerRoot.Save(employerPath);
            EmployerList = GetAllEmployers().ToList();
            return true;
        }

        /// <summary>
        /// updates employer in XML
        /// </summary>
        /// <param name="employer"></param>
        public void updateEmployer(Employer employer)
        {

            XElement toUpdate = (from item in employerRoot.Elements()
                                 where int.Parse(item.Element("ID").Value) == employer.ID
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Employer with the same id not found...");

            foreach (PropertyInfo item in typeof(BE.Employer).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(employer));
            employerRoot.Save(employerPath);
            EmployerList = GetAllEmployers().ToList();

        }

        /// <summary>
        /// gets employer from XML
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employer getEmployer(int id)
        {
            XElement employer = null;
            try
            {
                employer = (from item in employerRoot.Elements()
                            where int.Parse(item.Element("ID").Value) == id
                            select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            if (employer == null)
                return null;
            return ConvertEmployer(employer);
        }
        /// <summary>
        /// gets all employers from XML
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        public IEnumerable<Employer> GetAllEmployers(Func<Employer, bool> predicat = null)
        {
            if (predicat == null)
            {
                return from item in employerRoot.Elements()
                       select ConvertEmployer(item);
            }

            return from item in employerRoot.Elements()
                   let e = ConvertEmployer(item)
                   where predicat(e)
                   select e;
        }
        #endregion

        #region Contract Function
        /// <summary>
        /// adds contract to XML
        /// </summary>
        /// <param name="contract"></param>
        public void addContract(Contract contract)
        {
            Contract c = getContract(contract.contractNum);
            if (c != null)
                throw new Exception("Contract with the same num already exists...");
            Employer employer = getEmployer(contract.employerID);
            if (employer == null) throw new Exception("cannot add contract! employer does not exsist!");
            Employee employee = getEmployee(contract.employeeID);
            if (employee == null) throw new Exception("cannot add contract! employee does not exsist!");
            employee.numOfJobs++;
            updateEmployee(employee);
            employer.NumOfEmployees++;
            employer.NumOfEmployeesNeeded--;
            updateEmployer(employer);
            runningNumbers.ContractID++;
            contract.contractNum = runningNumbers.ContractID;
            contractRoot.Add(ConvertContract(contract));
            contractRoot.Save(contractPath);
        }

        /// <summary>
        /// removes contract from XML
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool removeContract(int id)
        {
            XElement toRemove = (from item in contractRoot.Elements()
                                 where int.Parse(item.Element("contractNum").Value) == id
                                 select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Contract with the same id not found...");

            toRemove.Remove();
            contractRoot.Save(contractPath);

            return true;
        }
        /// <summary>
        /// updates contract in XML
        /// </summary>
        /// <param name="contract"></param>
        public void updateContract(Contract contract)
        {

            XElement toUpdate = (from item in contractRoot.Elements()
                                 where int.Parse(item.Element("contractNum").Value) == contract.contractNum
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Contract with the same num not found...");

            foreach (PropertyInfo item in typeof(BE.Contract).GetProperties())
                toUpdate.Element(item.Name).SetValue(item.GetValue(contract));
            contractRoot.Save(contractPath);
        }

        /// <summary>
        /// gets contract from XML
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contract getContract(int id)
        {
            XElement contract = null;
            try
            {
                contract = (from item in contractRoot.Elements()
                            where int.Parse(item.Element("contractNum").Value) == id
                            select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            if (contract == null)
                return null;
            return ConvertContract(contract);
        }
        /// <summary>
        /// gets all contracts from XML
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicat = null)
        {
            if (predicat == null)
            {
                return from item in contractRoot.Elements()
                       select ConvertContract(item);
            }

            return from item in contractRoot.Elements()
                   let c = ConvertContract(item)
                   where predicat(c)
                   select c;
        }
        #endregion
        /// <summary>
        /// returns way of going over banks from XML
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        public IEnumerable<BankAcount> getAllBanks(Func<BankAcount, bool> predicat = null)
        {
            foreach (var item in bankRoot.Elements())
            {
                yield return new BankAcount
                {
                    bankID = int.Parse(item.Element("קוד_בנק").Value),
                    bankName = item.Element("שם_בנק").Value.Replace('\n', ' ').ToString(),
                    branchID = int.Parse(item.Element("קוד_סניף").Value),
                    branchCity = item.Element("ישוב").Value.Replace('\n', ' ').ToString(),
                    branchAddress = item.Element("כתובת_ה-ATM").Value.Replace('\n', ' ').ToString(),
                };
            }
        }
        /// <summary>
        /// gets all Banks without doubles
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        public IEnumerable<BankAcount> GetAllBankAcounts(Func<BankAcount, bool> predicat = null)
        {
            if (predicat == null)
                return getAllBanks()
                    .GroupBy(p => p.branchID)
                    .Select(g => g.First())
                    .ToList();
            return getAllBanks()
                    .GroupBy(p => p.branchID)
                    .Select(g => g.First())
                    .ToList();
        }

        public bool banksDownloaded()
        {
            if (downloadFinished == true) return true;
            throw new Exception("cannot add or update until bank file has finished downloading! close window and come back later!");
        }
        /// <summary>
        /// gets all banks
        /// </summary>
        /// <param name="predicat"></param>
        /// <returns></returns>
        /// 


        //thses next function get info from relative lists
        public IEnumerable<BankAcount> GetBankAcountsList(Func<BankAcount, bool> predicat = null)
        {
            if (predicat == null)
                return BankAcountList.AsEnumerable();
            return BankAcountList.Where(predicat);
        }

        public IEnumerable<Employee> GetEmployeesList()
        {
            return EmployeeList.AsEnumerable();
        }

        public IEnumerable<Employer> GetEmployersList()
        {
            return EmployerList.AsEnumerable();
        }

        public IEnumerable<Specialization> GetSpecializationsList()
        {
            return SpecializationList.AsEnumerable();
        }

        public Employee getEmployeeFromList(int IDEmployee)
        {
            return EmployeeList.FirstOrDefault(s => s.ID == IDEmployee);
        }

        public Employer getEmployerFromList(int IDEmployer)
        {
            return EmployerList.FirstOrDefault(s => s.ID == IDEmployer);
        }

        public Specialization getSpecializationFromList(int IDSpecialization)
        {
            return SpecializationList.FirstOrDefault(s => s.numOfSpecialization == IDSpecialization);
        }
    }
}
