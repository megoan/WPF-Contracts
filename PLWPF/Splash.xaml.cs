using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBLInstance();
        public System.Windows.Threading.DispatcherTimer dispatcherTimer;
        int timer = 0;
       // public static MainWindow mainWindow = new MainWindow();
        public Splash()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
            InitializeComponent();                       
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer % 300 == 0)
            {
                new MainWindow().Show();
                this.Close();
                
                dispatcherTimer.Tick -= new EventHandler(dispatcherTimer_Tick);
            }
        }
        private void move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }       
    }
}
