using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redestro.Models.CethiaViewModels
{
    public class InstructeurIndexData
    {
        public IEnumerable<Instructeur> Instructeurs { get; set; }
        public IEnumerable<Tache> Taches { get; set; }
        public IEnumerable<Inscription> Inscriptions { get; set; }
    }
}