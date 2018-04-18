using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BE
{
    public class Contract:INotifyPropertyChanged
    {
        private int _contractNum;                            //the contract code
        private int _employerID= 1001;                       //the employer's id
        private int _employeeID= 111111111;                  //the employees id
        private bool _interview;                             //value if employee had interview
        private bool _contractSignd;                         //value if contract was signed
        private int _gross;                                  //the bruto amount that the employee will get
        private double _net;                                 //the neto amount the employee will get
        private DateTime _employementBegin=DateTime.Now;     //the date the employee started working
        private DateTime _employementEnd=DateTime.Now;       //the date the employee stopped working
        private int _TORADayNum;
        private int _monthHours;                             //how many hours must you work a month 
             
        private int daysOffAYear = 6;
        private double pension;
        private string extraInfo="more info...";

      
        public event PropertyChangedEventHandler PropertyChanged;
                public string Cname { get { return ToString(); } set { } }
        public int employerID
        {
            get { return _employerID; }
            set
            {
                if (value.GetType() == typeof(int))
                    _employerID = value;
                else throw new Exception("unvalid employerID");
            }
        }
        public int employeeID
        {
            get { return _employeeID; }
            set
            {
                if (value.GetType() == typeof(int))
                    _employeeID = value;
                else throw new Exception("unvalid employeeID");
            }
        }
        public int monthHours
        {
            get { return _monthHours; }
            set
            {
                if (value.GetType() == typeof(int))                  
                        _monthHours =value;                  
                else throw new Exception("unvalid value");
            }
        }
        public int TORADayNum
        {
            get { return _TORADayNum; }
            set
            {
                if (value.GetType() == typeof(int))
                {                  
                        _TORADayNum = value;
                }
                else throw new Exception("unvalid value");
            }
        }
        public int DaysOffAYear
        {
            get { return daysOffAYear; }
            set
            {
                if (value.GetType() == typeof(int))                
                        daysOffAYear = value;                   
                else throw new Exception("unvalid value");
            }
        }
        public DateTime employementBegin
        {
            get { return _employementBegin; }
            set
            {
                if (value.GetType() == typeof(DateTime))
                {                   
                        _employementBegin = value;                    
                }
                else throw new Exception("unvalid value");
            }
        }
        public DateTime employementEnd
        {
            get { return _employementEnd; }
            set
            {

                if (value.GetType() == typeof(DateTime))
                {
                    _employementEnd = value;                        
                }
                else throw new Exception("unvalid value");
            }
        }

        public int gross
        {
            get { return _gross; }
            set
            {
                if (value.GetType() == typeof(int))
                    _gross = value;
                else throw new Exception("unvalid value");
            }
        }
        public double net
        {
            get { return _net; }
            set
            {
                if (value.GetType() == typeof(double) || value.GetType() == typeof(int))
                    _net = value;
                else throw new Exception("unvalid value"); if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("net"));
            }
        }
        public double Pension
        {
            get { return pension; }
            set
            {
                if (value.GetType() == typeof(double) || value.GetType() == typeof(int)) {
                    pension = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Pension")); }
                else throw new Exception("unvalid value");
            }
        }
         public bool interview
        {
            get { return _interview; }
            set
            {
                if (value.GetType() == typeof(bool))
                    _interview = value;
                else throw new Exception("unvalid value");
            }
        }
        public bool contractSignd
        {
            get { return _contractSignd; }
            set
            {
                if (value.GetType() == typeof(bool))
                    _contractSignd = value;
                else throw new Exception("unvalid value");
            }
        }
        public Contract()
        {
            
            ExtraInfo = "more info...";
        }
        public string ExtraInfo { get { return extraInfo; } set { extraInfo = value; } }

       
       public int contractNum
        {
            get { return _contractNum; }
            set
            {
                if (value.GetType() == typeof(int))
                    _contractNum = value;
                else throw new Exception("unvalid value");
            }
        }


        


        public override string ToString()
        {            
            return "CONTRACT: " + contractNum;
        }
    }
}
