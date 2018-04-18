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
using Microsoft.Win32;
using System.Globalization;

namespace PLWPF
{

   
    /// <summary>
    /// Interaction logic for EmployerWindow.xaml
    /// </summary>
    public partial class EmployerWindow : Window
    {
        int check = 1;
        BE.Employer employer = new Employer();
        
        BL.IBL bl = BL.FactoryBL.GetBLInstance();
        
        public EmployerWindow()
        {
            InitializeComponent();
            this.AllowDrop = true;
            
            this.DataContext = employer;
           
                   
            this.fieldComboBox.ItemsSource = Enum.GetValues(typeof(BE.Field));
            this.statusComboBox.ItemsSource = Enum.GetValues(typeof(BE.Status));
            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            
            this.listOfEmploersComboBox.ItemsSource = (bl.GetAllEmployers()).ToList();
        }

        private void updateRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            employer = (Employer)(listOfEmploersComboBox.SelectedItem);           
            this.DataContext = employer;
            if (employer!=null)
            {
                if (employer.freelancer) freelancerRadioButton.IsChecked = true;
                else companyRadioButton.IsChecked = true; 
            }
        }

        private void removeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            employer = (Employer)(listOfEmploersComboBox.SelectedItem);
            this.DataContext = employer;
            if (employer!=null)
            {
                if (employer.freelancer) freelancerRadioButton.IsChecked = true;
                else companyRadioButton.IsChecked = true; 
            }
        }

        private void addRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            employer = new Employer();
            this.DataContext = employer;
        }
       
        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                bl.addEmployer(employer);
                string msg = employer.ToString()+ " - כל הקונה עבד קונה אדון לעצמו ";
                MessageBox.Show(msg);
                this.listOfEmploersComboBox.ItemsSource = (bl.GetAllEmployers()).ToList();
                employer = new Employer();
                this.DataContext = employer;                               
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
               
                employer = (Employer)(this.listOfEmploersComboBox.SelectedItem);
                bl.updateEmployer(employer);
                string msg = employer.firstName + " " + employer.familyName + " was updated sucssesfully";
                MessageBox.Show(msg);               
                this.listOfEmploersComboBox.ItemsSource = (bl.GetAllEmployers()).ToList();
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
                if (employer!=null)
                {
                    bl.removeEmployer(employer.ID);                    
                    List<Employer> list = (bl.GetAllEmployers()).ToList();
                    this.listOfEmploersComboBox.DisplayMemberPath = "companyName";
                    this.listOfEmploersComboBox.ItemsSource = (bl.GetAllEmployers()).ToList(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dont do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listOfEmploers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (check > 1)
            {
                employer = (Employer)(listOfEmploersComboBox.SelectedItem);
                string msss = employer.ToString();
                this.DataContext = employer;
                if (employer!=null)
                {
                    if (employer.freelancer) freelancerRadioButton.IsChecked = true;
                    else companyRadioButton.IsChecked = true; 
                }
            }
            check++;
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            Image temp = new Image();
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)             
            employer.ImageSource = (new Uri(ofdPicture.FileName)).ToString();            
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
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                HandleFileOpen(files[0]);
            }
        }

        private void HandleFileOpen(string v)
        {
            try
            {
                if (v.EndsWith(".jpg") || v.EndsWith(".png") || v.EndsWith(".gif"))
                {
                    employer.ImageSource = v;
                    image.Source = new BitmapImage(new Uri(v));                    
                    DataContext = employer;
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
            pdfCreator.createPDFofEmployer(employer);
        }
    }
}
