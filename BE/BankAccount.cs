using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct BankAcount: INotifyPropertyChanged//according to isreal bank xml
    {        
        public int bankID { get; set; }
        public string bankName { get; set; }
        public int branchID { get; set; }
        public string branchAddress { get; set; }
        public string branchCity { get; set; }
        public bool amla { get; set; }
        private int accountNumber { get; set; }
        public bool handicapAccess { get; set; }
        public string type { get; set; }
        public string area { get; set; }
        public int coordinatesX { get; set; }
        public int coordinatesY { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int AccountNumber { get { return accountNumber; } set { accountNumber = value; if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("AccountNumber")); } }

        public override string ToString()
        {
            return bankName +" "+ branchCity +" "+"קוד סניף: " + branchID;
        }
        //public string BankAcountName { get { return bankName + " branch ID: " + branchID; } }
    }
}
//<קוד_בנק>13</קוד_בנק>
//<שם_בנק>בנק אגוד לישראל בע"מ</שם_בנק>
//<קוד_סניף>75</קוד_סניף>
//<כתובת_ה-ATM>אחוזה 153 153</כתובת_ה-ATM>
//<ישוב>רעננה</ישוב>
//<עמלה>לא</עמלה>
//<סוג_ATM>משיכת מזומן</סוג_ATM>
//<מיקום_ה-ATM_ביחס_לסניף>על קיר הסניף</מיקום_ה-ATM_ביחס_לסניף>
//<גישה_לנכים>כן</גישה_לנכים>
//<קואורדינטת_X>187980</קואורדינטת_X>
//<קואורדינטת_Y>676470</קואורדינטת_Y>