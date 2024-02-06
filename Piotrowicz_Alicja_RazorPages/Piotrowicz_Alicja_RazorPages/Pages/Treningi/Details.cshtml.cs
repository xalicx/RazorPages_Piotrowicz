using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Piotrowicz_Alicja_RazorPages.Data;
using Piotrowicz_Alicja_RazorPages.Models;

namespace Piotrowicz_Alicja_RazorPages.Pages.Treningi
{
    public class DetailsModel : PageModel
    {
        private readonly Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext _context;

        public DetailsModel(Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext context)
        {
            _context = context;
        }

      public Trening Trening { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trening == null)
            {
                return NotFound();
            }

            var trening = await _context.Trening.FirstOrDefaultAsync(m => m.Id == id);
            if (trening == null)
            {
                return NotFound();
            }
            else 
            {
                Trening = trening;
            }
            return Page();
        }
    }
}
