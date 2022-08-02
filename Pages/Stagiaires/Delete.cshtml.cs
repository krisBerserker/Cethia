using redestro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace redestro.Pages.Stagiaires
{
    public class DeleteModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(redestro.Data.CethiaContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Stagiaire Stagiaire { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stagiaire = await _context.Stagiaire
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Stagiaire == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Stagiaire = await _context.Stagiaire.FindAsync(id);

            if (Stagiaire == null)
            {
                return NotFound();
            }

            try
            {
                _context.Stagiaire.Remove(Stagiaire);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}