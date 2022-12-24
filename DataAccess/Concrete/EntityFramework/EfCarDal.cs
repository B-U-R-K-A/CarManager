using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Cars.Remove(context.Cars.SingleOrDefault(c=>c.Id==car.Id));
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {  
                return context.Cars.ToList();
            }

        }

        public Car GetById()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Car>().SingleOrDefault();
            }
        }

        public void Update(Car car)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var carToUpdate = context.Cars.SingleOrDefault(c=>c.Id==car.Id);
                carToUpdate.CategoryId = car.CategoryId;
                carToUpdate.Id = car.Id;
                carToUpdate.DailyPrice = car.DailyPrice;
                context.SaveChanges();
            }
        }
    }
}
