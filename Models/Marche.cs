using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace redestro.Models
{
    public class Marche
    {
        public int MarcheId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Libelle { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Budget")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Date Debut")]
        public DateTime DateDebut { get; set; }

        public int? InstructeurID { get; set; }

        public Instructeur Instructeur { get; set; }
        public ICollection<Tache> Taches { get; set; }
    }
}