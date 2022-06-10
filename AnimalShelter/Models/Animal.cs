using System;
namespace AnimalShelter.Models
{
    public class Animal
    {
        public string AnimalId { get; set; }
        public string Name { get; set; }
        public string Neutered { get; set;}
        public int Age { get; set; }
        public string Species { get; set; }
        public DateTime DateAdd { get; set; }
    }
}