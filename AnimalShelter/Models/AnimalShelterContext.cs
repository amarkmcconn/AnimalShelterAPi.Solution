using System;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {   
    }
    public DbSet<Animal> Animals { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Animal>()
            .HasData(
                new Animal { AnimalId = 1, Name = "Matilda", Neutered = "Y", Age = 7, Species = "Dog",  Gender = "Female", DateAdd = DateTime.Parse("2022-08-01,")},
                new Animal { AnimalId = 2, Name = "Rexie", Neutered = "Y", Age = 10, Species = "Dog",  Gender = "Female", DateAdd = DateTime.Parse("2022-02-01,")},
                new Animal { AnimalId = 3, Name = "Matilda", Neutered = "N", Age = 2, Species = "Cat",  Gender = "Female", DateAdd = DateTime.Parse("2022-03-01,")},
                new Animal { AnimalId = 4, Name = "Pip", Neutered = "Y", Age = 4, Species = "Bird",  Gender = "Male", DateAdd = DateTime.Parse("2022-07-01,")},
                new Animal { AnimalId = 5, Name = "Bartholomew", Neutered = "N", Age = 22, Species = "Cat",  Gender = "Male", DateAdd = DateTime.Parse("2022-06-01,")}
            );
        }
    }
}
