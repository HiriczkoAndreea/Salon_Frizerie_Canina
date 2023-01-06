using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Data;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Pages.Breeds
{
    public class DeleteModel : PageModel
    {
        private readonly Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext _context;

        public DeleteModel(Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Breed Breed { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Breed == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed.FirstOrDefaultAsync(m => m.Id == id);

            if (breed == null)
            {
                return NotFound();
            }
            else 
            {
                Breed = breed;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Breed == null)
            {
                return NotFound();
            }
            var breed = await _context.Breed.FindAsync(id);

            if (breed != null)
            {
                Breed = breed;
                _context.Breed.Remove(Breed);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
