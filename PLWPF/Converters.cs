using BE;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Documents;

namespace PLWPF
{
    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                BitmapImage b = new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));                
                return b;
            }
            catch (Exception)
            {
                return new BitmapImage(new Uri(@"images\drag&drop.png", UriKind.RelativeOrAbsolute));
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return ((BitmapImage)value).UriSource.AbsolutePath;
            }
            catch
            {
                return @"images\drag&drop.png";
            }
        }
    }

    public class flipBoolean : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true) return false;
            return true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true) return true;
            return false;
        }
    }

   
    public class numberToSpecialization : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BL.IBL bl = BL.FactoryBL.GetBLInstance();
            Specialization s = bl.getSpecializationFromList((int)value);
            return (Specialization)s;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Specialization)value).numOfSpecialization;
        }
    }
    public class numberToEmployer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BL.IBL bl = BL.FactoryBL.GetBLInstance();
            Employer s = bl.getEmployerFromList((int)value);
            return s;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Employer)value).ID;
        }
    }
    public class numberToemployee : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BL.IBL bl = BL.FactoryBL.GetBLInstance();
            Employee s = bl.getEmployeeFromList((int)value);
            return s;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Employee)value).ID;
        }
    }
    public class grossToNet : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            BL.IBL bl = BL.FactoryBL.GetBLInstance();
            Contract s = bl.getContract((int)value);
            return bl.employeesNetoAfterCalculation(s);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Contract)value).contractNum;
        }
    }
}