// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;

Console.WriteLine("Hello, World!");
ProductManager productManager = new ProductManager(new EfCarDal());
//Car car1 = new Car() { Name = "Sedan", BrandId = 1, CategoryId = 1, ColorId = 1, DailyPrice = 150000, Description = "It's a very good choice for a man", Id = 1, ModelYear = 2011 };
productManager.Add(new Car { Name = "Deneme", CategoryId = 3, DailyPrice = 0});
foreach (var cars in productManager.GetAll())
{
    Console.WriteLine("{0} {1} {2}",cars.Id,cars.Name,cars.CategoryId);
}
// 78 id'li sedan arabasını sildiğim için 77, 79 diye ilerliyor id karşılığı