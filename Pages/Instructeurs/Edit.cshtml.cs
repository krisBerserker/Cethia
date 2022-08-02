using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Instructeurs
{
    public class EditModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public EditModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instructeur Instructeur { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Instructeurs == null)
            {
                return NotFound();
            }

            var instructeur =  await _context.Instructeurs.FirstOrDefaultAsync(m => m.ID == id);
            if (instructeur == null)
            {
                return NotFound();
            }
            Instructeur = instructeur;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Instructeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructeurExists(Instructeur.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InstructeurExists(int id)
        {
          return _context.Instructeurs.Any(e => e.ID == id);
        }
    }
}
