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
    public class DeleteModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public DeleteModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Instructeurs == null)
            {
                return NotFound();
            }
            var instructeur = await _context.Instructeurs.FindAsync(id);

            if (instructeur != null)
            {
                Instructeur = instructeur;
                _context.Instructeurs.Remove(Instructeur);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
