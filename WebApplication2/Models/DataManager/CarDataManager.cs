using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.DTO;
using WebApplication2.Models.Repository;

namespace WebApplication2.Models.DataManager
{
    public class CarDataManager : IDataRepository<Car, CarDTO>
    {
        private readonly carsDatabaseContext _context;
        public CarDataManager(carsDatabaseContext context)
        {
            _context = context;
        }
        public void Add(Car entity)
        {
            _context.Car.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Car entity)
        {
            _context.Car.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Car> Get(int id)
        {
            var car = _context.Car.SingleOrDefaultAsync(c => c.Id == id);
            return await car;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Car.Include(car => car.Engine).ToListAsync();
        }

        public async Task<CarDTO> GetDto(int id)
        {
            //_context.ChangeTracker.LazyLoadingEnabled = true;

            using (var context = new carsDatabaseContext())
            {
                Car car = await context.Car.SingleOrDefaultAsync(c => c.Id == id);

                return CarDTOMapper.MapToDTO(car);
            }
        }

        public void Update(Car entityToUpdate, Car entity)
        {
            entityToUpdate = _context.Car
                .Include(c => c.Engine)
                .Include(c => c.Manufacturer)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Title = entity.Title;
            entityToUpdate.Model = entity.Model;
            entityToUpdate.Color = entity.Color;

            entityToUpdate.Engine.Series = entity.Engine.Series;
            entityToUpdate.Engine.Type = entity.Engine.Type;
            entityToUpdate.Engine.Volume = entity.Engine.Volume;

            _context.SaveChanges();
        }
    }
}
