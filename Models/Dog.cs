namespace Salon_Frizerie_Canina.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public string Age { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }   

    }
}