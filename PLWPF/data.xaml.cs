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
using System.ComponentModel;
using System.Reflection;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for data.xaml
    /// </summary>
    public partial class data : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBLInstance();      
        public ICollectionView specializations { get; private set; }

        public data()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();            
        }      
    }
}
