using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetRetard.Models
{
    public class BilletRetard
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Motif { get; set; }

        
        public string Justificatif { get; set; }

        [Required]
        public DateTime DateHeure { get; set; }

        [Required]
        public int Score { get; set; }
    }
}