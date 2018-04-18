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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Contracts.xaml
    /// </summary>
    public partial class Contracts : Window
    {
        int check = 1;
        int checkBank = 1;
        BE.Contract contract = new Contract();
        BL.IBL bl = BL.FactoryBL.GetBLInstance();

        public Contracts()
        {
            InitializeComponent();
            DataContext = contract;           
            this.listOfContractsComboBox.DisplayMemberPath = "Cname";
            this.listOfContractsComboBox.ItemsSource = (bl.GetAllContract()).ToList();
            this.employeeComboBox.ItemsSource = (bl.GetEmployeesList()).ToList();
            this.employerComboBox.ItemsSource = (bl.GetEmployersList()).ToList();
        }

        private void updateRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            contract = (Contract)(listOfContractsComboBox.SelectedItem);
            this.DataContext = contract;         
        }

        private void removeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            contract = (Contract)(listOfContractsComboBox.SelectedItem);
            this.DataContext = contract;     
        }

        private void addRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            contract = new Contract();
            this.DataContext = contract;         
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                bl.addContract(contract);
                string msg = "contract num " + contract.contractNum + " was added sucssesfully";
                MessageBox.Show(msg);
                contract = new Contract();
                this.DataContext = contract;              
                this.listOfContractsComboBox.ItemsSource = (bl.GetAllContract()).ToList();
                this.employeeComboBox.ItemsSource = (bl.GetEmployeesList()).ToList();
                this.employerComboBox.ItemsSource = (bl.GetEmployersList()).ToList();
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
                bl.updateContract(contract);
                string msg = "contract num " + contract.contractNum + " was updated sucssesfully";
                MessageBox.Show(msg);
                this.listOfContractsComboBox.ItemsSource = (bl.GetAllContract()).ToList();
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
                if (contract != null)
                {
                    bl.removeContract(contract.contractNum);
                    this.listOfContractsComboBox.ItemsSource = (bl.GetAllContract()).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "don't do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listOfContracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (check > 1)
            {
                contract = (Contract)(listOfContractsComboBox.SelectedItem);
                this.DataContext = contract;             
            }
            check++;
            checkBank++;
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            pdfCreator.createPDFofContract(contract);
        }

        private void showInfoemployee(object sender, MouseEventArgs e)
        {
            ComboBox combo = (sender) as ComboBox;
            Employee worker = (Employee)combo.SelectedItem;
            Specialization mumhiut = bl.getSpecialization(worker.numOfSpecialization);
            if(combo!=null)
            { combo.ToolTip = "works in: " + mumhiut + " employee ID: " + worker.ID; }
        }

        private void employerInfo(object sender, MouseEventArgs e)
        {
            ComboBox combo = (sender) as ComboBox;
            Employer maavid = (Employer)combo.SelectedItem;
            if (maavid!=null)
            {
                combo.ToolTip = " employer ID: " + maavid.ID + " phoneNum: " + maavid.phoneNum; 
            }
        }
    }
}


