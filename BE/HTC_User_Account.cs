using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HTC_User_Account
    {
        private string userName;
        private string password;
        private string emailAddress;
        public string UserName { get { return userName; } set { userName = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string EmailAddress
        {
            get
            { return emailAddress; }
            set
            { emailAddress = value; } }                
    }
}
