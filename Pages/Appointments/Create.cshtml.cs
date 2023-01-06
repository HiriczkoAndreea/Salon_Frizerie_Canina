using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Data;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Pages.Appointments
{
    public class CreateModel : DogGendersModel
    {
        private readonly Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext _context;

        public CreateModel(Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BreedId"] = new SelectList(_context.Set<Breed>(), "Id", "BreedName");
            ViewData["DogId"] = new SelectList(_context.Set<Dog>(), "Id", "Name");
            

            var appointment = new Appointment();
            appointment.DogGenders = new List<DogGender>();
            PopulateAssignedGenderData(_context, appointment);


            return Page();

        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedGenders)
        {
            var newAppointment = new Appointment();
            if (selectedGenders != null)
            {
                newAppointment.DogGenders = new List<DogGender>();
                foreach (var cat in selectedGenders)
                {
                    var catToAdd = new DogGender
                    {
                        GenderId = int.Parse(cat)
                    };
                    newAppointment.DogGenders.Add(catToAdd);
                }
            }
            Appointment.DogGenders = newAppointment.DogGenders;
            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        
            PopulateAssignedGenderData(_context, newAppointment);
            return Page();
        }
    }

}