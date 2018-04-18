using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace BE
{
    public class Employee :/* DependencyObject,*/ INotifyPropertyChanged//  DependencyObject
    {
        private int _id;                               //the employee's id
        private DateTime _birth;                          //the employee's date of birth
        private int _phoneNum;                         //the employee's phome number
        private int _cellPhoneNum;                     //the employee's cell phone number
        private bool _afterArmy = true;                     //value the defines if the employee served in the army
        private int _numOfSpecialization = 10000001;              //the id of spetialization that the employee has
        private string emailAddress = "";                      //the employee's email address 
        private int _numOfJobs;                           //the number of jubs the employee has
        private string _city = "";                             //which city the employee lives
        private string _familyName = "";                       //the employee's last name
        private string _firstName = "";                        //the employee's first name
        private string _address = "";                          //the employee's address
        public BE.Degree _degree;                          //the employees degree: first second phd...
        private BE.Status _status;                       //the employees status israel/levi/cohen
        private int _acountNumber;
        //public BankAcount bankAcount = new BankAcount(); //the employees bank account information
        private string _imageSource = @"\images\drag&drop.png";
        private string summary = "extra info on employee...";
        private BankAcount _bankAccount = new BankAcount { bankID = 111, bankName = "leumi", branchAddress = "betshemesh", branchCity = "bs", branchID = 111 };
        public Employee()
        {
            _bankAccount.AccountNumber = _acountNumber;
            ImageSource = @"\images\drag&drop.png";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int ID
        {
            get { return _id; }
            set
            {
                if (value.GetType() == typeof(int))
                    _id = value;
                else throw new Exception("unvalid ID");
            }
        }

        public string firstName { get { return _firstName; } set { _firstName = value; } }
        public string familyName { get { return _familyName; } set { _familyName = value; } }
        public BE.Status status { get { return _status; } set { _status = value; } }

        public BE.Degree degree { get { return _degree; } set { _degree = value; } }
        public int numOfSpecialization
        {
            get { return _numOfSpecialization; }
            set
            {
                if (value.GetType() == typeof(int))
                    _numOfSpecialization = value;
                else throw new Exception("unvalid value for Specialization");
            }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;

            }
        }
        public int phoneNum
        {
            get { return _phoneNum; }
            set
            {
                if (value.GetType() == typeof(int))
                {
                    _phoneNum = value;
                }
                else throw new Exception("unvalid phone number");
            }
        }

        public int CellPhoneNum
        {
            get { return _cellPhoneNum; }
            set
            {
                if (value.GetType() == typeof(int))
                    _cellPhoneNum = value;
                else throw new Exception("unvalid cell phone number");
            }
        }
        public string City { get { return _city; } set { _city = value; } }
        public string address { get { return _address; } set { _address = value; } }
        public DateTime birth
        {
            get { return _birth; }
            set
            {
                if (value.GetType() == typeof(DateTime))
                    _birth = value;
                else throw new Exception("unvalid date type");
            }
        }
        public bool afterArmy
        {
            get { return _afterArmy; }
            set
            {
                if (value.GetType() == typeof(bool))
                    _afterArmy = value;
                else throw new Exception("unvalid value");
            }
        }
        public int numOfJobs
        {
            get { return _numOfJobs; }
            set
            {
                if (value.GetType() == typeof(int))
                    _numOfJobs = value;
                else throw new Exception("unvalid value");
            }
        }
        //private BE.Degree deg;
        // public BE.Degree degree { get { return (BE.Degree)GetValue(UserProperty1); } set { deg = value; SetValue(UserProperty1, value); } }
        //public static readonly DependencyProperty UserProperty1 = DependencyProperty.Register("degree", typeof(obj), typeof(Employee), new UIPropertyMetadata(""));     

        

        public BankAcount bankAccount { get { return _bankAccount; } set { _bankAccount = value; } }
        public int _AcountNumber
        {
            get { return _acountNumber; }
            set { _acountNumber = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_AcountNumber")); }
        }
        public string Summary { get { return summary; } set { summary = value; } }
        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ImageSource")); }
        }
        public string imageSource { get { return _imageSource; } set { _imageSource = value; } }





       

        public override string ToString()
        {
            if (degree != Degree.PHD)
            {
                return familyName + " " + firstName;
            }
            else
            {
                return "Dr. " + familyName + " " + firstName;
            }
        }
    }
}
