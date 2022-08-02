using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using redestro.Data;
using redestro.Models;

namespace redestro.Pages.Notifications
{
    public class DeleteModel : PageModel
    {
        private readonly redestro.Data.CethiaContext _context;

        public DeleteModel(redestro.Data.CethiaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Notification Notification { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification.FirstOrDefaultAsync(m => m.ID == id);

            if (notification == null)
            {
                return NotFound();
            }
            else 
            {
                Notification = notification;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }
            var notification = await _context.Notification.FindAsync(id);

            if (notification != null)
            {
                Notification = notification;
                _context.Notification.Remove(Notification);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
