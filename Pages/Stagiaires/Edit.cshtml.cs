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

namespace redestro.Pages.Stagiaires
{
    public class EditModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public EditModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stagiaire Stagiaire { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
             if (id == null)
    {
        return NotFound();
    }

    Stagiaire = await _context.Stagiaire.FindAsync(id);

    if (Stagiaire == null)
    {
        return NotFound();
    }
    return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var stagiaireToUpdate = await _context.Stagiaire.FindAsync(Stagiaire.ID);

    if (stagiaireToUpdate == null)
    {
        return NotFound();
    }

    if (await TryUpdateModelAsync<Stagiaire>(
        stagiaireToUpdate,
        "stagiaire",
        s => s.Nom, s => s.Prenom,s => s.email,s => s.telephone, s => s.DateInscription))
    {
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }

    return Page();
        }

        
        private bool StagiaireExists(int id)
        {
          return _context.Stagiaire.Any(e => e.ID == id);
        }
    }
}
