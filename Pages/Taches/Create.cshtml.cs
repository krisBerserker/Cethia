using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Taches
{
    public class CreateModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public CreateModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

 public IList<Tache> Taches { get; set; }

        public IActionResult OnGet()
        {
        ViewData["MarcheId"] = new SelectList(_context.Marches, "MarcheId", "MarcheId");
            return Page();
        }

        [BindProperty]
        public Tache Tache { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tache.Add(Tache);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
