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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private int num = 0;
        public int Value
        {
            get { return num; }
            set
            {
                if (value > MaxValue)
                    num = MaxValue;
                else if (value < MinValue)
                    num = MinValue;
                else
                    num = value;

                textNumber.Text =num.ToString();
            }
        }

        public int calculateOf(int number)
        {
            if (number > MaxValue)
                return MaxValue;
            else if (number < MinValue)
                return MinValue;
            else
                return number;
        }


        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, calculateOf(value)); textNumber.Text= calculateOf(value).ToString(); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(UserControl1), new PropertyMetadata(0));



        public int MinValue { get; set; }
        //  public int MaxValue { get; set; }



        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(UserControl1), new PropertyMetadata(100));

        public UserControl1()
        {
            InitializeComponent();
            MaxValue = 15;
            MinValue = 6;
            textNumber.Text = "6";
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {          
            MyProperty++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            MyProperty--;           
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            int val;
            if (!int.TryParse(textNumber.Text, out val))
                textNumber.Text = MyProperty.ToString();
            else
            {              
                MyProperty = (int)val;
            }
        }
    }
}
