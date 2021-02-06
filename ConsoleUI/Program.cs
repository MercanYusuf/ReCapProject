using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            #region Car Add
            Car car1 = new Car
            {
                Id = 9,
                BrandId = 7,
                ColorId = 6,
                ModelYear = 2023,
                DailyPrice = 300,
                Description = "Vurdun öldün.",
                CarName="Şahin"
                
            };
            carManager.Add(car1);
            //carManager.Delete(car1);
            #endregion

            //Console.WriteLine("-----Car GetAll-----");

            #region Car GetAll
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("ID : " + item.Id + " BrandID : " + " " + item.BrandId + " " + "ColorID : " + " " + item.ColorId + " " + "Model Year : " + item.ModelYear + " " + "Daily Price : " + " " + item.DailyPrice + " " + "Description : " + item.Description);
            }
            #endregion

            Console.WriteLine("------Car GetById------");
            #region Car GetById
            Car carById = carManager.GetbyId(8);
            Console.WriteLine("ID : " + carById.Id + " BrandID : " + " " + carById.BrandId + " " + "ColorID : " + " " + carById.ColorId + " " + "Model Year : " + carById.ModelYear + " " + "Daily Price : " + " " + carById.DailyPrice + " " + "Description : " + carById.Description);

            #endregion

            Console.WriteLine("-----Car GetByDailyPrice----- ");

            #region GetByDailyPrice
            foreach (var item in carManager.GetByDailyPrice(900,2500))
            {
                Console.WriteLine("ID : " + item.Id + " BrandID : " + " " + item.BrandId + " " + "ColorID : " + " " + item.ColorId + " " + "Model Year : " + item.ModelYear + " " + "Daily Price : " + " " + item.DailyPrice + " " + "Description : " + item.Description);
            }
            #endregion

            Console.WriteLine("-----BrandID-----");

            #region BrandId 
            foreach (var item in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine("ID:" + item.Id + " Model Yılı:" + item.ModelYear + " Fiyat:" + item.DailyPrice + " Bilgi:" + item.Description);
            }
            #endregion

            Console.WriteLine("-----BrandName----- ");

            #region BrandName
            //Brand brand = new Brand
            //{
            //    Id = 5,
            //    BrandName = "ar"
            //};
            //brandManager.Add(brand);
            #endregion

            //Console.WriteLine("------Color Add-----");
            //Color color = new Color
            //{
            //    Id = 3,
            //    ColorName = "Mavi"
            //};
            //colorManager.Add(color);


        }
    }
}
