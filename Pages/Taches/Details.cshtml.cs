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
    public class DetailsModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public DetailsModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

      public Tache Tache { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tache == null)
            {
                return NotFound();
            }

            var tache = await _context.Tache.FirstOrDefaultAsync(m => m.TacheID == id);
            if (tache == null)
            {
                return NotFound();
            }
            else 
            {
                Tache = tache;
            }
            return Page();
        }
    }
}
