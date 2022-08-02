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
    public class DetailsModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public DetailsModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

      public Instructeur Instructeur { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Instructeurs == null)
            {
                return NotFound();
            }

            var instructeur = await _context.Instructeurs.FirstOrDefaultAsync(m => m.ID == id);
            if (instructeur == null)
            {
                return NotFound();
            }
            else 
            {
                Instructeur = instructeur;
            }
            return Page();
        }
    }
}
