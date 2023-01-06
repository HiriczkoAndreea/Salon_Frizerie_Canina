using Microsoft.AspNetCore.Mvc.RazorPages;
using Salon_Frizerie_Canina.Data;

namespace Salon_Frizerie_Canina.Models
{
    public class DogGendersModel : PageModel
    {
        public List<AssignedGenderData> AssignedGenderDataList;
        public void PopulateAssignedGenderData(Salon_Frizerie_CaninaContext context, Appointment appointment)
        {
            var allGenders = context.Gender;
            var appointmentGenders = new HashSet<int>(
            appointment.DogGenders.Select(c => c.GenderId)); //
            AssignedGenderDataList = new List<AssignedGenderData>();
            foreach (var cat in allGenders)
            {
                AssignedGenderDataList.Add(new AssignedGenderData
                {
                    GenderId = cat.Id,
                    Name = cat.GenderName,
                    Assigned = appointmentGenders.Contains(cat.Id)
                });
            }
        }

        public void UpdateDogGenders(Salon_Frizerie_CaninaContext context,
            string[] selectedGenders, Appointment appointmentToUpdate)
        {
            if (selectedGenders == null)
            {
                appointmentToUpdate.DogGenders = new List<DogGender>();
                return;
            }

            var selectedGendersHS = new HashSet<string>(selectedGenders);
            var appointmentGenders = new HashSet<int>
            (appointmentToUpdate.DogGenders.Select(c => c.Gender.Id));
            foreach (var cat in context.Gender)
            {
                if (selectedGendersHS.Contains(cat.Id.ToString()))
                {
                    if (!appointmentGenders.Contains(cat.Id))
                    {
                        appointmentToUpdate.DogGenders.Add(
                        new DogGender
                        {
                            DogId = appointmentToUpdate.Id,
                            GenderId = cat.Id
                        });
                    }
                }

                else
                {
                    if (appointmentGenders.Contains(cat.Id))
                    {
                        DogGender courseToRemove
                        = appointmentToUpdate
                        .DogGenders
                        .SingleOrDefault(i => i.GenderId == cat.Id);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}