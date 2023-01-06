using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Data;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext _context;

        public IndexModel(Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; }
        public AppointmentData AppointmentD { get; set; }
        public int AppointmentId { get; set; }
        public int GenderId { get; set; }
        public async Task OnGetAsync(int? id, int? genderId)
        {
            AppointmentD = new AppointmentData();
            AppointmentD.Appointments = await _context.Appointment
            .Include(b => b.Dog)
            .Include(b => b.Breed)
            .Include(b => b.DogGenders)
            .ThenInclude(b => b.Gender)
            .AsNoTracking()
            .OrderBy(b => b.AppointmentDate)
            .ToListAsync();
             if (id != null)
            {
                AppointmentId = id.Value;
                Appointment appointment = AppointmentD.Appointments
                .Where(i => i.Id == id.Value).Single();
                AppointmentD.Genders = appointment.DogGenders.Select(s => s.Gender);
            }
        }
    }
}