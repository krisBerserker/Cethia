using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Instructeurs
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
            return Page();
        }

        [BindProperty]
        public Instructeur Instructeur { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Instructeurs.Add(Instructeur);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
