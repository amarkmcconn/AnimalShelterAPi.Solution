using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AnimalsController : ControllerBase
    {
      private readonly AnimalShelterContext _db;
			public AnimalsController(AnimalShelterContext db)
			{
				_db = db;
			}
			/// <summary>
			/// Returns a list of Animals with their respective attributes
			/// </summary>
			/// <returns>a list of Animals</returns>
			/// <response code="200"> Returns a list of Animals</response>
			[HttpGet]
			[ProducesResponseType(StatusCodes.Status200OK)]
    	[ProducesDefaultResponseType]
			public async Task<List<Animal>> Get(string name, string neutered, int minimumage, string species, string gender, DateTime date)
			{
				IQueryable<Animal> query = _db.Animals.AsQueryable();
				if(name != null)
				{
					query = query.Where(entry => entry.Name == name);
				}
				if(neutered != null)
				{
					query = query.Where(entry => entry.Neutered == neutered);
				}
				if(minimumage > 0)
				{
					query = query.Where(entry => entry.Age >= minimumage);
				}
				if(species != null)
				{
					query = query.Where(entry => entry.Species == species);
				}
				if(gender != null)
				{
					query = query.Where(entry => entry.Gender == gender);
				}
				if(date != DateTime.MinValue)
				{
					query = query.Where(entry => entry.DateAdd == date);
				}
				return await query.ToListAsync();
			}
			/// <summary>
			/// Creates a new Animal
			/// </summary>
			/// <returns>a new Animal</returns>
			/// <remarks>
			/// Sample Request POST /api/Animals
			/// </remarks>
			/// <response code="201"> Animal created successfully</response>
			[HttpPost]
			[ProducesResponseType(StatusCodes.Status201Created)]
			[ProducesDefaultResponseType]
			public async Task<ActionResult<Animal>> Post( Animal animal)
			{
				_db.Animals.Add(animal);
				await _db.SaveChangesAsync();
				return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId}, animal);
			}
			/// <summary>
			/// Gets a specific Animal
			/// </summary>
			/// <returns>a Animal</returns>
			/// <response code="200"> Returns a Animal</response>
			[HttpGet("{id}")]
			[ProducesResponseType(StatusCodes.Status200OK)]
			[ProducesDefaultResponseType]
			public async Task<ActionResult<Animal>> GetAnimal(int id)
			{
				var animal= await _db.Animals.FindAsync(id);
				if(animal == null)
				{
					return NotFound();
				}
				return animal;
			}
			/// <summary>
			/// Edits a specific Animal
			/// </summary>
			/// <returns>an edited Animal</returns>
			/// <response code="204"> Animal edited successfully</response>
			[HttpPut("{id}")]
			[ProducesResponseType(StatusCodes.Status204NoContent)]
			[ProducesDefaultResponseType]
			public async Task<IActionResult> Put(int id, Animal animal)
			{
				if(id != animal.AnimalId)
				{
					return BadRequest();
				}
				_db.Entry(animal).State = EntityState.Modified;
				try
				{
					await _db.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if(!AnimalExists(id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return NoContent();
			}
			/// <summary>
			/// Deletes a Animal
			/// </summary>
			/// <returns>a list of Animals</returns>
			/// <response code="204"> Animal deleted successfully</response>
			[HttpDelete("{id}")]
			[ProducesResponseType(StatusCodes.Status204NoContent)]
			[ProducesDefaultResponseType]
			public async Task<IActionResult> DeleteAnimal(int id)
			{
				var animal = await _db.Animals.FindAsync(id);
				if(animal == null)
				{
					return NotFound();
				}
				_db.Animals.Remove(animal);
				await _db.SaveChangesAsync();
				return NoContent();
			}
			private bool AnimalExists(int id)
			{
				return _db.Animals.Any(e => e.AnimalId == id);
			}
    }
}