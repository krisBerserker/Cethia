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

namespace redestro.Pages.Taches
{
    public class EditModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public EditModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tache Tache { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tache == null)
            {
                return NotFound();
            }

            var tache =  await _context.Tache.FirstOrDefaultAsync(m => m.TacheID == id);
            if (tache == null)
            {
                return NotFound();
            }
            Tache = tache;
           ViewData["MarcheId"] = new SelectList(_context.Marches, "MarcheId", "MarcheId");
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

            _context.Attach(Tache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacheExists(Tache.TacheID))
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

        private bool TacheExists(int id)
        {
          return _context.Tache.Any(e => e.TacheID == id);
        }
    }
}
