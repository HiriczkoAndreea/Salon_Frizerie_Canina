using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Data;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Pages.Dogs
{
    public class DeleteModel : PageModel
    {
        private readonly Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext _context;

        public DeleteModel(Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dog == null)
            {
                return NotFound();
            }

            var dog = await _context.Dog.FirstOrDefaultAsync(m => m.Id == id);

            if (dog == null)
            {
                return NotFound();
            }
            else 
            {
                Dog = dog;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dog == null)
            {
                return NotFound();
            }
            var dog = await _context.Dog.FindAsync(id);

            if (dog != null)
            {
                Dog = dog;
                _context.Dog.Remove(Dog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
