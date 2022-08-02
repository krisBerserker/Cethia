using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace redestro.Models
{
       public class Tache
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Display(Name = "Numero")]
         public int TacheID { get; set; }
         [StringLength(100, MinimumLength = 3)]
         public string Libelle { get; set; }
        [Range(0, 5)]
         public int Priorite { get; set; }
public int MarcheId { get; set; }

        public Marche Marche { get; set; }
        public ICollection<Inscription> Inscriptions { get; set; }
           public ICollection<Instructeur> Instructeurs { get; set; }
    }
}