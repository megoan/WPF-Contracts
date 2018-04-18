using BE;
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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBLInstance();
        Uri dictUri;
        IDnumbers runningNumbers = new IDnumbers();       
        public Categories()
        {
            InitializeComponent();          
            if (MainWindow.english)
            {
                dictUri = new Uri(@"/rec/languages/English.xaml", UriKind.Relative);
            }
            else
            {
                dictUri = new Uri(@"/rec/languages/Hebrew.xaml", UriKind.Relative);
            }
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            this.Closing += OnWindowClosing;           
        }
       
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {        
            bl.addID();
            Application.Current.Shutdown();
            Environment.Exit(0);
        }

        private void specializationbutton_Click(object sender, RoutedEventArgs e)
        {
            new SpecializationWindow().ShowDialog();
        }

        private void employeesbutton_Click(object sender, RoutedEventArgs e)
        {
            new Employees().ShowDialog();
        }

        private void employersbutton_Click(object sender, RoutedEventArgs e)
        {
            new EmployerWindow().ShowDialog();
        }

        private void contractsbutton_Click(object sender, RoutedEventArgs e)
        {
            new Contracts().ShowDialog();
        }

        private void groupEmailSenderbutton4_Click(object sender, RoutedEventArgs e)
        {
            new GroupEmailSender().ShowDialog();
        }

        private void companyRevenuebutton_Click(object sender, RoutedEventArgs e)
        {
            new CompanyRevenue().ShowDialog();
        }

        private void contractsbutton_Copy_Click(object sender, RoutedEventArgs e)
        {
            new data().ShowDialog();

        }

        private void hebrewL_Click(object sender, RoutedEventArgs e)
        {
            dictUri = new Uri(@"/rec/languages/Hebrew.xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);          
        }

        private void englishL_Click(object sender, RoutedEventArgs e)
        {
            dictUri = new Uri(@"/rec/languages/English.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);            
        }
    }
}
