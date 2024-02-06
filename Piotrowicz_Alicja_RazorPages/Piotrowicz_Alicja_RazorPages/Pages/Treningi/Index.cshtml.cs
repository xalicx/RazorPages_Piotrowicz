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
    public class IndexModel : PageModel
    {
        private readonly Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext _context;

        public IndexModel(Piotrowicz_Alicja_RazorPages.Data.Piotrowicz_Alicja_RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Trening> Trening { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TreningType { get; set; }

        public async Task OnGetAsync()
        {
            var trening = from m in _context.Trening
                          select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                trening = trening.Where(s => s.Type.Contains(SearchString));
            }

                Trening = await trening.ToListAsync();
            
        }
    }
}
