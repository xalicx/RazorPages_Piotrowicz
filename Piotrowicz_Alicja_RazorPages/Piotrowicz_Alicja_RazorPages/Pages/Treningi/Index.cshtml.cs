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
    public class IndexModel : PageModel
    {
        private readonly Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext _context;

        public IndexModel(Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Trening> Trening { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Trening != null)
            {
                Trening = await _context.Trening.ToListAsync();
            }
        }
    }
}
