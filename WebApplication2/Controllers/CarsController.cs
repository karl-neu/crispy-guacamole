using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Models.DTO;
using WebApplication2.Models.Repository;

namespace WebApplication2.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IDataRepository<Car, CarDTO> _repository;
        public CarsController(IDataRepository<Car, CarDTO> repository)
        {
            _repository = repository;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCar()
        {
            var cars = await _repository.GetAll();
            return Ok(cars);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            
            try
            {
                var car = await _repository.GetDto(id);
                return Ok(car);
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            var carToUpdate = await _repository.Get(id);

            if (carToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Update(carToUpdate, car);

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            if (car is null)
            {
                return BadRequest("Car is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(car);

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _repository.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            _repository.Delete(car);

            return car;
        }
    }
}
