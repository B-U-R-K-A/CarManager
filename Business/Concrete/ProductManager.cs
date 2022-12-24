using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IEntityRepository<Car> _carDal;
        public ProductManager(IEntityRepository<Car> carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Name.Length < 2)
            {
                if (car.DailyPrice < 0)
                {
                    _carDal.Add(car);
                }
            }
            else
            {
                throw new Exception("The name of car must be a minimum 2 words or daily price must be a greater than 0!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }


        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
