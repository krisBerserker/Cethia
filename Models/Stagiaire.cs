using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redestro.Models
{
    public class Stagiaire
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Prenom cannot be longer than 50 characters.")]
        [Column("Prenom")]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }
        public string email { get; set; }
        public int telephone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Inscription")]

        public DateTime DateInscription { get; set; }

        public ICollection<Inscription> Inscriptions { get; set; }
          [Display(Name = "Nom Complet")]
          public string FullName
        {
            get
            {
                return Nom + ", " + Prenom;
            }
        }
    }
}