namespace Salon_Frizerie_Canina.Models
{
    public class AppointmentData
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<DogGender> DogGenders { get; set; }
    }
}
