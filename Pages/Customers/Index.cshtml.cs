using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Frizerie_Canina.Data;
using Salon_Frizerie_Canina.Models;

namespace Salon_Frizerie_Canina.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext _context;

        public IndexModel(Salon_Frizerie_Canina.Data.Salon_Frizerie_CaninaContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer != null)
            {
                Customer = await _context.Customer.ToListAsync();
            }
        }
    }
}
