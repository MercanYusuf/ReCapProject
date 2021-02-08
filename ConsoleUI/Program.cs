
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            #region -Car Crud-
           //CarCrud();
            #endregion

            #region -BrandCrud-
            //BrandCrud();
            #endregion

            #region -ColorCrud-
          //  ColorCrud();
            #endregion

        }

        private static void ColorCrud()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------Color Add-----");
            Color color = new Color
            {
                Id = 3,
                ColorName = "Yeşil"
            };
            colorManager.Add(color);
        }

        private static void BrandCrud()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-----BrandID-----");
            foreach (var item in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("ID:" + item.Id + " Model Yılı:" + item.ModelYear + " Fiyat:" + item.DailyPrice + " Bilgi:" + item.Description);
            }

            Console.WriteLine("-----BrandName----- ");

            //Brand brand = new Brand
            //{
            //    Id = 2,
            //    BrandName = "BMW2"
            //};
            //brandManager.Add(brand);
        }

        private static void CarCrud()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Car car1 = new Car
            //{
            //    /* Id = 2,*/ // identity yapıldı
            //    BrandId = 6,
            //    ColorId = 7,
            //    ModelYear = 1800,
            //    DailyPrice = 3000,
            //    Description = "Elektrikli",
            //    CarName = "Ferrai"

            //};
           // carManager.Add(car1);
          // carManager.Delete(new Car { Id=1});
            //carManager.Update(new Car { Id = 1, BrandId = 3, ColorId = 4, DailyPrice = 1800, Description = "İyi Araba", CarName = "Bugatti" ,ModelYear=1993});

            Console.WriteLine("-----Car GetAll-----");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("ID : " + item.Id + " BrandID : " + " " + item.BrandId + " " + "ColorID : " + " " + item.ColorId + " " + "Model Year : " + item.ModelYear + " " + "Daily Price : " + " " + item.DailyPrice + " " + "Description : " + item.Description);
                

            }
         

            Console.WriteLine("------Car GetById------");
     
            var carById = carManager.GetById(1003);
            Console.WriteLine("ID : " + carById.Id + " BrandID : " + " " + carById.BrandId + " " + "ColorID : " + " " + carById.ColorId + " " + "Model Year : " + carById.ModelYear + " " + "Daily Price : " + " " + carById.DailyPrice + " " + "Description : " + carById.Description);

            Console.WriteLine("-----Car GetByDailyPrice----- ");
            foreach (var item in carManager.GetByDailyPrice(150, 3001))
            {
                Console.WriteLine("ID : " + item.Id + " BrandID : " + " " + item.BrandId + " " + "ColorID : " + " " + item.ColorId + " " + "Model Year : " + item.ModelYear + " " + "Daily Price : " + " " + item.DailyPrice + " " + "Description : " + item.Description);
            }

            Console.WriteLine("-----Car DetailsDto----- ");

            
            foreach (var item in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(item.Id+ " " +item.CarName+ " " + item.BrandName +" " + item.ColorName+ " " + item.DailyPrice );
            }

        }
    }
}
