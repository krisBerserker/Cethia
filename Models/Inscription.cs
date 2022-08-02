using System.ComponentModel.DataAnnotations;

namespace redestro.Models
{
    
    public class Inscription
    {
        public int InscriptionID { get; set; }
        public int TacheID { get; set; }
        public int StagiaireID { get; set; }
        
        public Tache Tache { get; set; }
        public Stagiaire Stagiaire { get; set; }
    }
}