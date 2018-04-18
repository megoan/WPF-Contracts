using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        private static DAL_XML factory = null;       
        private FactoryDal() { }
        public static IDAL GetDalInstance()
        {            
                if (null == factory)
                {
                    factory = new DAL_XML();
                }
                return factory;           
        }
    }
}
