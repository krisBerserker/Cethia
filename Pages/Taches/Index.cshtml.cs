using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Taches
{
    public class IndexModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public IndexModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        public IList<Tache> Tache { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tache != null)
            {
                Tache = await _context.Tache
                .Include(t => t.Marche).ToListAsync();
            }
        }
    }
}
