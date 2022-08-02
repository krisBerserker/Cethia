using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Stagiaires
{
    public class IndexModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public IndexModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        public IList<Stagiaire> Stagiaire { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stagiaire != null)
            {
                Stagiaire = await _context.Stagiaire.ToListAsync();
            }
        }
    }
}
