using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Piotrowicz_Alicja_RazorPages.Data;
using Piotrowicz_Alicja_RazorPages.Models;

namespace Piotrowicz_Alicja_RazorPages.Pages.Treningi
{
    public class EditModel : PageModel
    {
        private readonly Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext _context;

        public EditModel(Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trening Trening { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trening == null)
            {
                return NotFound();
            }

            var trening =  await _context.Trening.FirstOrDefaultAsync(m => m.Id == id);
            if (trening == null)
            {
                return NotFound();
            }
            Trening = trening;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trening).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreningExists(Trening.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TreningExists(int id)
        {
          return (_context.Trening?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
