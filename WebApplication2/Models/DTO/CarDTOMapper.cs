using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.DTO
{
    public static class CarDTOMapper
    {
        public static CarDTO MapToDTO(Car car)
        {
            return new CarDTO()
            {
                Id = car.Id,
                Title = car.Title,
                Model = car.Model,
                Color = car.Color,

                Engine = new Engine()
                {
                    Id = car.EngineId,
                    Series = car.Engine.Series,
                    Type = car.Engine.Type,
                    Volume = car.Engine.Volume
                },
                Manufacturer = new Manufacturer()
                {
                    Id = car.ManufacturerId,
                    Title = car.Manufacturer.Title,
                    Headquarters = car.Manufacturer.Headquarters,
                    NumberOfEmployees = car.Manufacturer.NumberOfEmployees
                }
            };
        }
    }
}
