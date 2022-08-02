using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Marches
{
    public class CreateModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public CreateModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstructeurID"] = new SelectList(_context.Instructeurs, "ID", "Nom");
            return Page();
        }

        [BindProperty]
        public Marche Marche { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Marches.Add(Marche);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
