using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Models.DataManager;
using Xunit;

namespace WebApplication2.Tests
{
    public class CarDataMangerTests
    {
        private CarDataManager _carDataManager;

        public CarDataMangerTests()
        {
            _carDataManager = new CarDataManager(new carsDatabaseContext());
        }

        private Car GenerateCar()
        {
            var rndInt = new Random().Next(10);
            return new Car()
            {
                Title = "carTitle" + rndInt,
                Color = "carColor" + rndInt,
                Model = "carModel" + rndInt,
                Manufacturer = new Manufacturer()
                {
                    Title = "manufacturerTitle",
                    Headquarters = "manufacturerHeadquarters",
                    NumberOfEmployees = 10
                },
                Engine = new Engine()
                {
                    Series = "engineSeries",
                    Type = "engineType",
                    Volume = 2.0
                }
            };
        }

        [Fact]
        public void CheckAddCar()
        {
            // Arrange
            var car = GenerateCar();

            // Act
            _carDataManager.Add(car);
            var id = car.Id;

            // Assert
            var addedcar = _carDataManager.Get(id);
            Assert.Equal(car, addedcar.Result);
        }

        [Fact]
        public void CheckDeleteCar()
        {
            // Arrange
            var car = GenerateCar();

            // Act
            _carDataManager.Add(car);
            var id = car.Id;
            _carDataManager.Delete(car);

            // Assert
            var deletedcar = _carDataManager.Get(id);
            Assert.Null(deletedcar.Result);
        }

        [Fact]
        public async Task CheckGetAllCarAsync()
        {
            // Arrange
            var car = GenerateCar();
            var car2 = GenerateCar();
            var car3 = GenerateCar();

            _carDataManager.Add(car);
            _carDataManager.Add(car2);
            _carDataManager.Add(car3);
             
            // Act
            var res = await _carDataManager.GetAll();

            // Assert
            Assert.Equal(car, _carDataManager.Get(car.Id).Result);
            Assert.Equal(car2, _carDataManager.Get(car2.Id).Result);
            Assert.Equal(car3, _carDataManager.Get(car3.Id).Result);
        }

        [Fact]
        public async Task CheckUpdateCar()
        {
            // Arrange
            var car = GenerateCar();
            _carDataManager.Add(car);
            var newCar = GenerateCar();


            // Act
            _carDataManager.Update(car, newCar);
            var res = _carDataManager.Get(car.Id);

            // Assert
            Assert.Equal(res.Result, _carDataManager.Get(car.Id).Result);

        }
    }
}
