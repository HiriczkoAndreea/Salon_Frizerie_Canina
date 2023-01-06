namespace Salon_Frizerie_Canina.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public ICollection<Dog>? Dogs { get; set; }
    }

      
  
}

    

