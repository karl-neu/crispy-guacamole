using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestWebApplication2
{
    public class CarsControllerTests
    {
        [Fact]
        public void GetCarReturnAllCar()
        {
            var mock=new Mock<IDataRepository<Car, CarDTO>>
        }
    }
}
