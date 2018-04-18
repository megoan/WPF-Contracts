using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
using System.ComponentModel;
using System.Windows.Data;

namespace PLWPF
{
    class MainWindowViewModel
    {
        BL.IBL bl = BL.FactoryBL.GetBLInstance();
        public ICollectionView mumhiut { get; private set; }
        public ICollectionView oved { get; private set; }
        public ICollectionView maavid { get; private set; }
        public ICollectionView hoze { get; private set; }


        public MainWindowViewModel()
        {
            mumhiut = CollectionViewSource.GetDefaultView(bl.GetAllSpecializations().ToList());
            oved = CollectionViewSource.GetDefaultView(bl.GetAllEmployees().ToList());
            maavid = CollectionViewSource.GetDefaultView(bl.GetAllEmployers().ToList());
            hoze = CollectionViewSource.GetDefaultView(bl.GetAllContract().ToList());

        }
    }
}
