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
    public class EfColorDal : IColorDal
    {
        public void Add(Color color)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Colors.Add(color);
                context.SaveChanges();
            }
        }

        public void Delete(Color color)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Colors.Remove(context.Colors.SingleOrDefault(c=>c.Id==color.Id));
                context.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Colors.ToList();
            }
        }

        public Color GetById()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Color>().SingleOrDefault();
            }
        }

        public void Update(Color color)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var colorToUpdate = context.Colors.SingleOrDefault(c=>c.Id==color.Id);
                colorToUpdate.Name = color.Name;
                colorToUpdate.Id = color.Id;
                context.SaveChanges();

            }
        }
    }
}
