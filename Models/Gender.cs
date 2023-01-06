namespace Salon_Frizerie_Canina.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; }
        public ICollection<DogGender>? DogGenders { get; set; }
    }
}
