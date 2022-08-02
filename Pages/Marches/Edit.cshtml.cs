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

namespace redestro.Pages.Marches
{
    public class EditModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public EditModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Marche Marche { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marches == null)
            {
                return NotFound();
            }

            var marche =  await _context.Marches.FirstOrDefaultAsync(m => m.MarcheId == id);
            if (marche == null)
            {
                return NotFound();
            }
            Marche = marche;
           ViewData["InstructeurID"] = new SelectList(_context.Instructeurs, "ID", "Nom");
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

            _context.Attach(Marche).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcheExists(Marche.MarcheId))
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

        private bool MarcheExists(int id)
        {
          return _context.Marches.Any(e => e.MarcheId == id);
        }
    }
}
