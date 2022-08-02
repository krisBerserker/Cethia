using System;
using System.ComponentModel.DataAnnotations;

namespace redestro.Models.CethiaViewModels
{
    public class InscriptionDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? InscriptionDate { get; set; }

        public int StagiaireCount { get; set; }
    }
}