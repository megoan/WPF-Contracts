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
using System.Collections.ObjectModel;

namespace PLWPF
{
    public class DemoValidator : ValidationRule
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
           
            int IntValue = 0;
           // ValidationResult result = null;
            try
            {                
                IntValue = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Please provide a number");
            }
            if (IntValue < 0) return new ValidationResult(false, "Please provide a number greater than 0");
            return new ValidationResult(true, null);
        }
    }
    /// <summary>
    /// Interaction logic for SpecializationWindow.xaml
    /// </summary>
    public partial class SpecializationWindow : Window
    {
        int check = 1;
        BE.Specialization spetialization = new Specialization();      
        BL.IBL bl = BL.FactoryBL.GetBLInstance();

        public SpecializationWindow()
        {
            InitializeComponent();
            
            DataContext = spetialization;                    
            fieldComboBox.ItemsSource = Enum.GetValues(typeof(BE.Field));        
            this.comboBox.ItemsSource = (bl.GetAllSpecializations()).ToList();
        }
        private void addRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            spetialization = new Specialization();
            this.DataContext = spetialization;
        }

        private void updateRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            spetialization = (Specialization)(comboBox.SelectedItem);
            this.DataContext = spetialization;
        }

        private void removeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            spetialization = (Specialization)(comboBox.SelectedItem);
            this.DataContext = spetialization;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (check > 1)
            {
                spetialization = (Specialization)(comboBox.SelectedItem);
                this.DataContext = spetialization;
            }
            check++;
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                bl.addSpecialization(spetialization);
                string msg =   "!!!אך, הן יראת ה' היא חכמה  : "+ spetialization;
                MessageBox.Show(msg);
                this.comboBox.ItemsSource = (bl.GetAllSpecializations()).ToList();
                spetialization = new Specialization();
                this.DataContext = spetialization;
                
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
                spetialization = (Specialization)(comboBox.SelectedItem);
                bl.updateSpecialization(spetialization);
                string msg = spetialization + " was updated sucssesfully";
                MessageBox.Show(msg);                
                this.comboBox.ItemsSource = (bl.GetAllSpecializations()).ToList();
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
                if (spetialization != null)
                {
                    spetialization = (Specialization)(comboBox.SelectedItem);
                    bl.removeSpecialization(spetialization.numOfSpecialization);

                    this.comboBox.ItemsSource = bl.GetAllSpecializations().ToList();
                    spetialization = (Specialization)(comboBox.SelectedItem); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dont do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void specialList(object sender, MouseEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            box.ToolTip = "list of specializations";
        }
    }
}
