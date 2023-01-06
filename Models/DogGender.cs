namespace Salon_Frizerie_Canina.Models
{
    public class DogGender
    {
        public int Id { get; set; }
        public int DogId { get; set; }
        public Dog Dog { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
