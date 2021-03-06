﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.CarName.Length>2)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba Başırıyla Eklendi.");
            }
            else
            {
                Console.WriteLine("Araba Günlük Fiyatı  0 dan  büyük  Olmalı ve Araba İsmi 2 karakterden uzun olmalı");
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

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(b => b.DailyPrice > min && b.DailyPrice < max).ToList();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c=>c.Id==id); 
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetailDtos();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(b => b.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(b => b.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
