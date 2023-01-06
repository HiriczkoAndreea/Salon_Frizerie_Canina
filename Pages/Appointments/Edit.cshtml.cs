using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Data;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Pages.Appointments
{
    public class EditModel : DogGendersModel
    {
        private readonly Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext _context;

        public EditModel(Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointment
            .Include(b => b.Dog)
            .Include(b => b.DogGenders)
            .ThenInclude(b => b.Gender)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            var appointment = await _context.Appointment.FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            PopulateAssignedGenderData(_context, Appointment);

            Appointment = appointment;

            ViewData["BreedId"] = new SelectList(_context.Set<Breed>(), "Id", "BreedName");
            ViewData["DogId"] = new SelectList(_context.Set<Dog>(), "Id", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenders)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointmentToUpdate = await _context.Appointment
.Include(i => i.Dog)
.Include(i => i.DogGenders)
.ThenInclude(i => i.Gender)
.FirstOrDefaultAsync(s => s.Id == id);
            if (appointmentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Appointment>(
            appointmentToUpdate,
            "Appointment",
            i => i.AppointmentDate, i => i.AppointmentHour,
            i => i.Dog, i => i.Breed))
            {
                UpdateDogGenders(_context, selectedGenders, appointmentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateDogGenders(_context, selectedGenders, appointmentToUpdate);
            PopulateAssignedGenderData(_context, appointmentToUpdate);
            return Page();
        }
    }
}