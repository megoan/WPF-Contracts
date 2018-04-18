using System;
using System.Collections.Generic;
using System.Globalization;
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
    public  class Revenue
    {
        public int Year { get; set; }
        public double January { get; set; }
        public double February { get; set; }
        public double March { get; set; }
        public double April { get; set; }
        public double May { get; set; }
        public double June { get; set; }
        public double July { get; set; }
        public double August { get; set; }
        public double September { get; set; }
        public double October { get; set; }
        public double November { get; set; }
        public double December { get; set; }
    }
    /// <summary>
    /// Interaction logic for CompantRevenue.xaml
    /// </summary>
    public partial class CompanyRevenue : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBLInstance();
        List<Revenue> listOfRevenues = new List<Revenue>();
        public CompanyRevenue()
        {
            InitializeComponent();          
            dataGrid.ItemsSource = listOfRevenues;
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listOfRevenues.Clear();
                int number;
                int arrayCount;
                bool result = Int32.TryParse(beginYearTextBox.Text, out number);
                if (result == false) throw new Exception("a real number please!");
                bool result2 = Int32.TryParse(endYearTextBox.Text, out number);
                if (result2 == false) throw new Exception("a real number please!");
                if (Int32.Parse(beginYearTextBox.Text) > Int32.Parse(endYearTextBox.Text)) throw new Exception("normal numbers please!!");
                if (Int32.Parse(endYearTextBox.Text) - Int32.Parse(beginYearTextBox.Text) > 40) throw new Exception("only 40 years please!");
                arrayCount = Int32.Parse(endYearTextBox.Text) - Int32.Parse(beginYearTextBox.Text);
                int[] array = new int[arrayCount];
                IEnumerable<IGrouping<int, IEnumerable<IGrouping<int, double>>>> seperatedBenefits = bl.groupOfEarningsDevidedByYearsAndMonth(false, Int32.Parse(beginYearTextBox.Text), Int32.Parse(endYearTextBox.Text));
                DateTimeFormatInfo info = new DateTimeFormatInfo();
                int i = 0;
                foreach (var item in seperatedBenefits)
                {
                    listOfRevenues.Add(new Revenue());
                    listOfRevenues[i].Year = item.Key;                
                    foreach (var n in item)
                    {
                        IEnumerable<double> money = n.SelectMany(group => group);
                        List<double> Hodesh = money.ToList();
                        listOfRevenues[i].January = Hodesh[0];
                        listOfRevenues[i].February = Hodesh[1];
                        listOfRevenues[i].March = Hodesh[2];
                        listOfRevenues[i].April = Hodesh[3];
                        listOfRevenues[i].May = Hodesh[4];
                        listOfRevenues[i].June = Hodesh[5];
                        listOfRevenues[i].July = Hodesh[6];
                        listOfRevenues[i].August = Hodesh[7];
                        listOfRevenues[i].September = Hodesh[8];
                        listOfRevenues[i].October = Hodesh[9];
                        listOfRevenues[i].November = Hodesh[10];
                        listOfRevenues[i].December = Hodesh[11];                        
                    }
                    i++;
                }
                List<Revenue> newList =new List<Revenue>(listOfRevenues);
                dataGrid.ItemsSource = newList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "don't do that again!", MessageBoxButton.OK, MessageBoxImage.Error);
            }          
        }
    }
}
