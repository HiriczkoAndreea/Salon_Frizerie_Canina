using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Data;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Pages.Genders
{
    public class DetailsModel : PageModel
    {
        private readonly Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext _context;

        public DetailsModel(Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext context)
        {
            _context = context;
        }

      public Gender Gender { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gender == null)
            {
                return NotFound();
            }

            var gender = await _context.Gender.FirstOrDefaultAsync(m => m.Id == id);
            if (gender == null)
            {
                return NotFound();
            }
            else 
            {
                Gender = gender;
            }
            return Page();
        }
    }
}
