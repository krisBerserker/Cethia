using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redestro.Models
{
    public class Instructeur
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [Column("Prenom")]
        [Display(Name = "Prenom")]
        [StringLength(50)]
        public string Prenom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime DateEmbauche { get; set; }

        public string email { get; set; }
        public int telephone { get; set; }

        [Display(Name = "Nom Complet")]
        public string FullName
        {
            get { return Nom + ", " + Prenom; }
        }

        public ICollection<Tache> Taches { get; set; }
    }
}