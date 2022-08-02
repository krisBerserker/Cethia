using redestro.Models.CethiaViewModels;
using redestro.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using redestro.Models;

namespace redestro.Pages
{
    public class HistoriqueModel : PageModel
    {
        private readonly CethiaContext _context;

        public HistoriqueModel(CethiaContext context)
        {
            _context = context;
        }

        public IList<InscriptionDateGroup> Stagiaires { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<InscriptionDateGroup> data =
                from student in _context.Stagiaire
                group student by student.DateInscription into dateGroup
                select new InscriptionDateGroup()
                {
                    InscriptionDate = dateGroup.Key,
                    StagiaireCount = dateGroup.Count()
                };

            Stagiaires = await data.AsNoTracking().ToListAsync();
        }
    }
}