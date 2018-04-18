using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {       
        int checkIfDone = 0;
        BL.IBL bl = BL.FactoryBL.GetBLInstance();
        BE.HTC_User_Account user = new HTC_User_Account();
        BE.HTC_User_Account userTemp = new HTC_User_Account();
        public CreateAccount()
        {
            InitializeComponent();
            DataContext = user;
        }

        private void changeButton(object sender, MouseEventArgs e)
        {
            done.Height += 15;
            done.Width += 15;
            done.Foreground = Brushes.Orange;
        }

        private void reviveButton(object sender, MouseEventArgs e)
        {
            done.Height -= 15;
            done.Width -= 15;
            done.Foreground = Brushes.Black;
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            checkIfDone = 0;

            userTemp = bl.getUser(user.UserName);

            if (userTemp != null)
            {
                checkIfDone++;
                userNameError.Content = "this username already exists";
                userNameError.Visibility = Visibility.Visible;
                UserNametextBox.BorderBrush = Brushes.Red;
            }
            else if (user.UserName==null || user.UserName == "")
            {
                checkIfDone++;
                userNameError.Content = "can't leave this field empty!";
                userNameError.Visibility = Visibility.Visible;
                UserNametextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                userNameError.Visibility = Visibility.Collapsed;
                UserNametextBox.BorderBrush = Brushes.Black;
            }
            if (user.Password == null || user.Password == "")
            {
                checkIfDone++;
                passWordError.Content = "can't leave this field empty!";
                passWordError.Visibility = Visibility.Visible;
                passWordtextBox.BorderBrush = Brushes.Red;
            }
            else if (!(user.Password.Any(char.IsDigit) && user.Password.Any(char.IsUpper) && user.Password.Any(char.IsLower)))
            {
                checkIfDone++;
                passWordError.Content = "Upercase and numbers must be included";
                passWordError.Visibility = Visibility.Visible;
                passWordError.BorderBrush = Brushes.Red;
            }
            else
            {
                passWordError.Visibility = Visibility.Collapsed;
                passWordtextBox.BorderBrush = Brushes.Black;
            }
            if (user.EmailAddress == null || !(((user.EmailAddress.EndsWith(".com")) || (user.EmailAddress.EndsWith(".net"))) || user.EmailAddress.IndexOf('@') < 1 && user.EmailAddress.IndexOf('@') > user.EmailAddress.IndexOf('.')))
            {
                checkIfDone++;
                emailAddressError.Visibility = Visibility.Visible;
                emailAddresstextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                emailAddressError.Visibility = Visibility.Collapsed;
                emailAddresstextBox.BorderBrush = Brushes.Black;
            }
            if  (checkIfDone == 0)
            {
                bl.addUser(user);
                bl.emailConfirmation(user.EmailAddress);
                this.Close();
            }   
        }
    }
}
