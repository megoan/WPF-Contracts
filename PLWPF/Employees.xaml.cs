using BE;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Globalization;
namespace PLWPF
{

    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        int check = 1;
        int checkBank = 1;
        BE.Employee employee = new Employee();        
        BL.IBL bl = BL.FactoryBL.GetBLInstance();

        public Employees()
        {
            InitializeComponent();
            this.AllowDrop = true;
            employee.bankAccount = bl.GetBankAcountsList(s => s.bankID == employee.bankAccount.bankID && s.branchID == employee.bankAccount.branchID).FirstOrDefault();
            this.DataContext = employee;
            this.degreeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Degree));
            this.statusComboBox.ItemsSource = Enum.GetValues(typeof(BE.Status));      

            this.listOfEmployeesComboBox.ItemsSource = (bl.GetAllEmployees()).ToList(); ;

            
            this.bankComboBox.ItemsSource = (bl.GetBankAcountsList()).ToList();
            
            this.specializationComboBox.ItemsSource = (bl.GetSpecializationsList()).ToList();
            
        }

        private void updateRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            employee = (Employee)(listOfEmployeesComboBox.SelectedItem);
            employee.bankAccount = bl.GetBankAcountsList(s => s.bankID == employee.bankAccount.bankID && s.branchID == employee.bankAccount.branchID).FirstOrDefault();
            this.DataContext = employee;
        }

        private void removeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            employee = (Employee)(listOfEmployeesComboBox.SelectedItem);
            employee.bankAccount = bl.GetBankAcountsList(s => s.bankID == employee.bankAccount.bankID && s.branchID == employee.bankAccount.branchID).FirstOrDefault();
            this.DataContext = employee;
        }

        private void addRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            employee = new Employee();
            employee.bankAccount = bl.GetBankAcountsList(s => s.bankID == employee.bankAccount.bankID && s.branchID == employee.bankAccount.branchID).FirstOrDefault();
            this.DataContext = employee;
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                if (this.bankComboBox.SelectedItem == null) throw new Exception("banks didn't finish downloading close page and start again!");                
                bl.addEmployee(employee);
                string msg = employee + "- !'עבדו את ה";
                MessageBox.Show(msg);                               
                employee.bankAccount = bl.GetBankAcountsList(s => s.bankID == employee.bankAccount.bankID && s.branchID == employee.bankAccount.branchID).FirstOrDefault();               
                this.listOfEmployeesComboBox.ItemsSource = (bl.GetAllEmployees()).ToList();                
                this.bankComboBox.ItemsSource = (bl.GetBankAcountsList()).ToList();               
                this.specializationComboBox.ItemsSource = (bl.GetSpecializationsList()).ToList();
                employee = new Employee();
                this.DataContext = employee;
               
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "dont do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (this.bankComboBox.SelectedItem == null) throw new Exception("banks didn't finish downloading close page and start again!");             
                bl.updateEmployee(employee);
                string msg = employee + " was updated sucssesfully";
                MessageBox.Show(msg);             
                this.listOfEmployeesComboBox.ItemsSource = (bl.GetAllEmployees()).ToList();


            }
            catch (Exception ex)
            {           
                MessageBox.Show(ex.Message, "dont do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void removebutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.banksDownloaded();
                if (employee != null)
                {
                    bl.removeEmployee(employee.ID);
                    List<Employee> list = (bl.GetAllEmployees()).ToList();
                    this.listOfEmployeesComboBox.ItemsSource = (bl.GetAllEmployees()).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "don't do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listOfEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (check > 1)
            {
                employee = (Employee)(listOfEmployeesComboBox.SelectedItem);
                employee.bankAccount = bl.GetBankAcountsList(s => s.bankID == employee.bankAccount.bankID && s.branchID == employee.bankAccount.branchID).FirstOrDefault();
                this.DataContext = employee;               
            }
            check++;
            checkBank++;
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            Image temp = new Image();
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)         
            {
                image2.Source = new BitmapImage(new Uri(ofdPicture.FileName));
                employee.ImageSource = ofdPicture.FileName;
                DataContext = employee;
            }
        }
        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                ((Control)sender).ToolTip = "value is good!";
            }
        }

        private void imagehere(object sender, DragEventArgs e)
        {

        }

        private void imageDropHere(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {           
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                HandleFileOpen(files[0]);
            }
        }

        private void HandleFileOpen(string v)
        {
            try
            {
                if (v.EndsWith(".jpg") || v.EndsWith(".png") || v.EndsWith(".gif"))
                {
                    image2.Source = new BitmapImage(new Uri(v));
                    employee.ImageSource = v;
                    DataContext = employee;
                }
                else
                {
                    throw new Exception("only image files are allowed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dont do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            pdfCreator.createPDFofEmployee(employee);
        }

        private void closeit(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            cb.IsDropDownOpen = false;
        }

        private void banktooltip(object sender, MouseEventArgs e)
        {
            ComboBox bank = sender as ComboBox;
            if (bank!=null)
            {
                bank.ToolTip = ((BankAcount)bankComboBox.SelectedItem).ToString(); 
            }
        }
    }
}
