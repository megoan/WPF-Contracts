using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;

namespace BE
{
    public class Employer: INotifyPropertyChanged //: //DependencyObject
    {

        private DateTime _birth;                        // if its a company then its the date of the companies "birth"
        private int _phoneNum;                          //the company's phone number
        private bool _freelancer = true;                       //value to check if employer is a freelancer or company
        private double _stockValue;                     //if its a company then shows the companies stocks
        private string emailAddress = "";                    //the employer's email address
        private int _id;                                //the employers id
        private string _familyName = "";                     //the employers family name (if its a company this will stay blank)
        private string _firstName = "";                      //the employers first name (if its a company this will stay blank)
        private string _companyName = "";                    // the company's name (first name and last name will stay blank)
        private Field _field;                           // the employers field  DATASTRUCTORS/NETWORKING/PROGRRAMING/SYBER/ANIMATION
        private Status _status;                         //the employers status (if its a company this will stay blank)
        private int _numOfEmployees;                    //the number of employees this employer has
        private int _numOfEmployeesNeeded;              //number of employees the employer needs
        private string _address = "";                        //the employers address
        private Area _area;                             //the area of working place      
        private string _imageSource = @"images\drag&drop.png";
        private string companySummary = "summary of company...";
        private bool _isCompany;
        public Employer()
        {
            NumOfEmployeesNeeded = 20;
            ImageSource = @"images\drag&drop.png";
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
        
        public string companyName { get { return _companyName; } set { _companyName = value; } }
        public Field field1 { get { return _field; } set { _field = value; } }
        public Area area { get { return _area; } set { _area = value; } }
        public string address { get { return _address; } set { _address = value; } }
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
                    _phoneNum = value;
                else throw new Exception("unvalid phone number");
            }
        }
        public double stockValue
        {
            get { return _stockValue; }
            set
            {
                if (value.GetType() == typeof(double))
                {
                    _stockValue = value;
                }
                else throw new Exception("unvalid value");
            }
        }
       public DateTime birth
        {
            get { return _birth; }
            set
            {
                if (value.GetType() == typeof(DateTime))
                    _birth = value;
                else throw new Exception("unvalid value");
            }
        }
        public Status status { get { return _status; } set { _status = value; } }
        public string ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ImageSource")); }
        }



        public int NumOfEmployees
        {
            get { return _numOfEmployees; }
            set
            {
                if (value.GetType() == typeof(int))
                    _numOfEmployees = value;
                else throw new Exception("unvalid value");
            }
        }
        public int NumOfEmployeesNeeded
        {
            get { return _numOfEmployeesNeeded; }
            set
            {
                if (value.GetType() == typeof(int))
                    _numOfEmployeesNeeded = value;
                else throw new Exception("unvalid value");
            }
        }
        public string CompanySummary { get { return companySummary; } set { companySummary = value; } }
       
        
        public bool isCompany { get { return _isCompany; } set { _isCompany = value; } }

        public bool freelancer
        {
            get { return _freelancer; }
            set
            {
                if (value.GetType() == typeof(bool))
                {
                    _freelancer = value;
                }
                else throw new Exception("unvalid value");
            }
        }
        public string firstName { get { return _firstName; } set { _firstName = value; } }
        public string familyName { get { return _familyName; } set { _familyName = value; } }


        public override string ToString()
        {
            if (freelancer)
            {
                return
                familyName +
                " " + firstName +
                ", " + (Enum.GetName(typeof(Field), field1));
            }
            return
                companyName + "-" + (Enum.GetName(typeof(Area), area)) +
                ", " + (Enum.GetName(typeof(Field), field1));

        }
    }
}
