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
    public class DetailsModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public DetailsModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

      public Stagiaire Stagiaire { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stagiaire == null)
            {
                return NotFound();
            }

            Stagiaire = await _context.Stagiaire
                .Include(s => s.Inscriptions)
                .ThenInclude(e => e.Tache)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            var stagiaire = await _context.Stagiaire.FirstOrDefaultAsync(m => m.ID == id);
            
            if (stagiaire == null)
            {
                return NotFound();
            }
       
            return Page();
        }
    }
}
