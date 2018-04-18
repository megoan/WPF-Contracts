using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;
using System.Media;
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        bool otherWindowOpened = false;       
        bool cannotContinue = true;
        BE.HTC_User_Account user = new HTC_User_Account();        
        HTC_User_Account users;
        public static bool english = true;
        public MainWindow()
        {
            
            InitializeComponent();

           //Thread t = new Thread(backGroundMusic);
           // t.Start();
            this.Closing += OnWindowClosing;
            this.DataContext = user;            
        }
        public void backGroundMusic()
        {
           // SoundPlayer player;
            //player = new SoundPlayer(@"has.wav");
            //player.PlayLooping();
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (otherWindowOpened == false) Application.Current.Shutdown();
        }

        private void changeColor(object sender, MouseEventArgs e)
        {
            this.SignIn.Foreground = Brushes.Orange;
            SignIn.Height += 10;
            SignIn.Width += 10;
        }

        private void reviveColor(object sender, MouseEventArgs e)
        {
            this.SignIn.Foreground = Brushes.Black;
            SignIn.Height -= 10;
            SignIn.Width -= 10;

        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.IBL bl = BL.FactoryBL.GetBLInstance();

                users = bl.getUser(user.UserName);
                if (users == null)
                {
                    cannotContinue = true;
                    UserNameError.Visibility = Visibility.Visible;
                    UserNametextBox.BorderBrush = Brushes.Red;
                }
                else
                {
                    cannotContinue = false;
                    if (user.Password != users.Password)
                    {
                        cannotContinue = true;
                        passwordError.Visibility = Visibility.Visible;
                        PasswordtextBox.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        cannotContinue = false;
                        passwordError.Visibility = Visibility.Collapsed;
                        PasswordtextBox.BorderBrush = Brushes.Gray;
                    }
                    UserNameError.Visibility = Visibility.Collapsed;
                    UserNametextBox.BorderBrush = Brushes.Gray;

                    if (cannotContinue == false)
                    {
                        otherWindowOpened = true;
                        new Categories().Show();
                        this.Close();                      
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "dont do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            {
                new CreateAccount().Show();
            }
        }        
    }
}
