using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        private static IBL_imp factory = null;
        private FactoryBL() { }
        public static IBL GetBLInstance()
        {          
                if (null == factory)
                {
                    factory = new IBL_imp();
                }
                return factory;            
        }
    }
}
