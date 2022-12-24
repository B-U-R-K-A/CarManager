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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Brands.Add(brand);
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Brands.Remove(context.Brands.SingleOrDefault(b=>b.Id==brand.Id));
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Brands.ToList();
            }
        }

        public Brand GetById()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Brand>().SingleOrDefault();
            }
        }

        public void Update(Brand brand)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var brandToUpdate = context.Brands.SingleOrDefault(b=>b.Id==brand.Id);
                brandToUpdate.Id = brand.Id;
                brandToUpdate.Name = brand.Name;
                context.SaveChanges();
            }
        }
    }
}
