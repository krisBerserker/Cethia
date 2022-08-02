using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Marches
{
    public class DeleteModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public DeleteModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Marche Marche { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marches == null)
            {
                return NotFound();
            }

            var marche = await _context.Marches.FirstOrDefaultAsync(m => m.MarcheId == id);

            if (marche == null)
            {
                return NotFound();
            }
            else 
            {
                Marche = marche;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Marches == null)
            {
                return NotFound();
            }
            var marche = await _context.Marches.FindAsync(id);

            if (marche != null)
            {
                Marche = marche;
                _context.Marches.Remove(Marche);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
