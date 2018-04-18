using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupEmailSender.xaml
    /// </summary>
    public partial class GroupEmailSender : Window
    {
        
        List<Contract> ContracthatEndedtsList;
        List<Employee> EmployeesList;
        List<Employer> EmployersList;
        List<Employee> EmployersListWithBirthday;
        BL.IBL bl = BL.FactoryBL.GetBLInstance();
        Progress ProgressWindow = new Progress();
        public GroupEmailSender()
        {
            InitializeComponent();

            ContracthatEndedtsList = new List<Contract>(bl.GetAllContract()).ToList();
            EmployeesList = new List<Employee>(bl.GetAllEmployees()).ToList();
            EmployersList = new List<Employer>(bl.GetAllEmployers()).ToList();
            EmployersListWithBirthday = new List<Employee>(bl.GetAllEmployees(s => s.birth.DayOfYear == DateTime.Now.DayOfYear)).ToList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjecttextBox.Text == "") throw new Exception("must enter subject");
                if (bodyTextBox.Text == "") throw new Exception("must enter body");
                if (sendtoallcheckBox.IsChecked == false)
                {
                    switch ((string)(groupscomboBox.Text))
                    {
                        case ("Employers"):
                            {
                                Thread newWindowThread = new Thread(new ThreadStart(() =>
                                {
                                    // Create and show the Window
                                    ProgressWindow = new Progress();
                                    ProgressWindow.Show();
                                    // Start the Dispatcher Processing
                                    System.Windows.Threading.Dispatcher.Run();
                                }));
                                // Set the apartment state
                                newWindowThread.SetApartmentState(ApartmentState.STA);
                                // Make the thread a background thread
                                newWindowThread.IsBackground = true;
                                // Start the thread
                                newWindowThread.Start();

                                foreach (var employer in EmployersList)
                                {
                                    bl.emailSender(employer.ID, "Dear: " + employer.companyName + ": " + subjecttextBox.Text, bodyTextBox.Text);
                                }
                                newWindowThread.Abort();
                                MessageBox.Show("emails sent!");
                                //System.Windows.Threading.Dispatcher.Run();

                            }
                            break;
                        case ("Emloyees"):
                            {
                                Thread newWindowThread = new Thread(new ThreadStart(() =>
                                {
                                    // Create and show the Window
                                    ProgressWindow = new Progress();
                                    ProgressWindow.Show();
                                    // Start the Dispatcher Processing
                                    System.Windows.Threading.Dispatcher.Run();
                                }));
                                // Set the apartment state
                                newWindowThread.SetApartmentState(ApartmentState.STA);
                                // Make the thread a background thread
                                newWindowThread.IsBackground = true;
                                // Start the thread
                                newWindowThread.Start();
                                foreach (var employee in EmployeesList)
                                {
                                    bl.emailSender(employee.ID, "Dear: " + employee.firstName + ": " + subjecttextBox.Text, bodyTextBox.Text);
                                }
                                newWindowThread.Abort();
                                MessageBox.Show("emails sent!");
                            }
                            break;
                        case ("Contracts that have ended"):
                            {
                                Thread newWindowThread = new Thread(new ThreadStart(() =>
                                {
                                    // Create and show the Window
                                    ProgressWindow = new Progress();
                                    ProgressWindow.Show();
                                    // Start the Dispatcher Processing
                                    System.Windows.Threading.Dispatcher.Run();
                                }));
                                // Set the apartment state
                                newWindowThread.SetApartmentState(ApartmentState.STA);
                                // Make the thread a background thread
                                newWindowThread.IsBackground = true;
                                // Start the thread
                                newWindowThread.Start();
                                foreach (var contract in ContracthatEndedtsList)
                                {
                                    bl.emailSender(contract.employeeID, "Dear: " + (bl.getEmployee(contract.employeeID)).firstName + ": " + subjecttextBox.Text, bodyTextBox.Text);
                                }
                                foreach (var contract in ContracthatEndedtsList)
                                {
                                    bl.emailSender(contract.employerID, "Dear: " + (bl.getEmployer(contract.employerID)).companyName + ": " + subjecttextBox.Text, bodyTextBox.Text);
                                }
                                newWindowThread.Abort();
                                MessageBox.Show("emails sent!");
                            }
                            break;
                        case ("Employess with birthdays"):
                            {
                                Thread newWindowThread = new Thread(new ThreadStart(() =>
                                {
                                    // Create and show the Window
                                    ProgressWindow = new Progress();
                                    ProgressWindow.Show();
                                    // Start the Dispatcher Processing
                                    System.Windows.Threading.Dispatcher.Run();
                                }));
                                // Set the apartment state
                                newWindowThread.SetApartmentState(ApartmentState.STA);
                                // Make the thread a background thread
                                newWindowThread.IsBackground = true;
                                // Start the thread
                                newWindowThread.Start();
                                foreach (var employee in EmployersListWithBirthday)
                                {
                                    bl.emailSender(employee.ID, "Dear: " + employee.firstName + ": " + subjecttextBox.Text, bodyTextBox.Text);
                                }
                                newWindowThread.Abort();
                                MessageBox.Show("emails sent!");
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Thread newWindowThread = new Thread(new ThreadStart(() =>
                    {
                        // Create and show the Window
                        ProgressWindow = new Progress();
                        ProgressWindow.Show();
                        // Start the Dispatcher Processing
                        System.Windows.Threading.Dispatcher.Run();
                    }));
                    // Set the apartment state
                    newWindowThread.SetApartmentState(ApartmentState.STA);
                    // Make the thread a background thread
                    newWindowThread.IsBackground = true;
                    // Start the thread
                    newWindowThread.Start();
                    foreach (var employer in EmployersList)
                    {
                        bl.emailSender(employer.ID, "Dear: " + employer.firstName + ": " + subjecttextBox.Text, bodyTextBox.Text);
                    }
                    foreach (var employee in EmployersList)
                    {
                        bl.emailSender(employee.ID, "Dear: " + employee.firstName + ": " + subjecttextBox.Text, bodyTextBox.Text);
                    }
                    newWindowThread.Abort();
                    MessageBox.Show("emails sent!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dont do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void showWindow() { ProgressWindow.Show(); }
        private void groupscomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
