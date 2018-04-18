using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Specialization
    {
        private int _numOfSpecialization;                           //the specialization number/id
        private int _wageMin;                                       //the minimum wage for this specialization
        private int _wageMax;                                       //the maximum wage for this specialization
        private int _numberOfWorkers;                               //the number of workers that work in this specialization
        private BE.Field _field;                                    //the field of this specialization       
        private string _specializationName = "";                    //the name of the specialization
        
      
        public int numOfSpecialization
        {
            get { return _numOfSpecialization; }
            set
            {
                if (value.GetType() == typeof(int))
                    _numOfSpecialization = value;
                else throw new Exception("unvalid value");
            }
        }
        public string SpecializationName { get { return _specializationName; } set { _specializationName = value; } }
        public BE.Field field1 { get { return _field; } set { _field = value; } }
        public int wageMin
        {
            get { return _wageMin; }
            set
            {
                if (value.GetType() == typeof(int))
                    _wageMin = value;
                else throw new Exception("unvalid value");
            }
        }

        public int wageMax
        {
            get { return _wageMax; }
            set
            {
                if (value.GetType() == typeof(int))
                    _wageMax = value;
                else throw new Exception("unvalid value");
            }
        }

        public int numberOfWorkers//number of workers in this specialization in isreal
        {
            get { return _numberOfWorkers; }
            set
            {
                if (value.GetType() == typeof(int))
                    _numberOfWorkers = value;
                else throw new Exception("unvalid value");
            }
        }

        public override string ToString()
        {
            return
                _specializationName+"-"+ (Enum.GetName(typeof(Field), field1));
            //"SPECIALIZATION: " +
            //"\nnumber of specialization: " + numOfSpecialization +
            //"\nname of specialization: " + SpecializationName +
            //"\nwage minimum: " + wageMin +
            //"\nwage maximum: " + wageMax +
            //"\nnumber of workers: " + numberOfWorkers +
            //"\nfield: " + (Enum.GetName(typeof(Field), field1));
        }
    }
}
