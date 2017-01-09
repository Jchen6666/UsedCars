using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FinalExamExercise
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static readonly CarModel CarModel=new CarModel();
        public bool AddCar(Car car)
        {
            if (car!=null)
            {
                CarModel.Cars.Add(car);
                CarModel.SaveChanges();
                return true;
            }
           
            return false;

        }

        public List<Car> GetCars()
        {
           return new List<Car>(CarModel.Cars);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Car> SearchCars(int id)
        {
            return CarModel.Cars.Where(x => x.Id == id).ToList();
        }
    }
}
