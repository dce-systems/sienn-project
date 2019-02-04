using System.Linq;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.DAL
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var types = new Type[]
            {
            new Type{Code=100,Description="Klasa 1"},
            new Type{Code=101,Description="Klasa 2"},
            new Type{Code=102,Description="Klasa 3"},
            new Type{Code=103,Description="Klasa 4"},
            new Type{Code=104,Description="Klasa Premium"},
            };
            foreach (Type t in types)
            {
                context.Types.Add(t);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
            new Category{Code=100,Description="Ciastka"},
            new Category{Code=101,Description="Ryby"},
            new Category{Code=102,Description="Mięso"},
            new Category{Code=103,Description="Pieczywo"},
            new Category{Code=104,Description="Napoje"},
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var units = new Unit[]
            {
            new Unit{Code=100,Description="sztuka"},
            new Unit{Code=101,Description="kilogram"},
            new Unit{Code=102,Description="tona"},
            new Unit{Code=103,Description="litr"},
            new Unit{Code=104,Description="gram"},
            };
            foreach (Unit u in units)
            {
                context.Units.Add(u);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{Code=100,Description="Chleb",Price=3.22m,IsAvailable=true,DeliveryDate=System.DateTime.Parse("2019-02-01"),TypeId=1,UnitId=1},
            new Product{Code=101,Description="Masło",Price=111.5m,IsAvailable=false,DeliveryDate=System.DateTime.Parse("2019-02-01"),TypeId=1,UnitId=2},
            new Product{Code=102,Description="Mleko",Price=32.0m,IsAvailable=true,DeliveryDate=System.DateTime.Parse("2019-02-02"),TypeId=2,UnitId=4},
            new Product{Code=103,Description="Makowiec",Price=7.58m,IsAvailable=true,DeliveryDate=System.DateTime.Parse("2019-02-02"),TypeId=3,UnitId=2},
            new Product{Code=104,Description="Sernik",Price=22.5m,IsAvailable=true,DeliveryDate=System.DateTime.Parse("2019-02-03"),TypeId=1,UnitId=2},
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

        }
    }
}