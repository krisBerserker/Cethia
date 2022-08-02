using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Instructeurs
{
    public class IndexModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public IndexModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        public IList<Instructeur> Instructeur { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Instructeurs != null)
            {
                Instructeur = await _context.Instructeurs.ToListAsync();
            }
        }
    }
}
