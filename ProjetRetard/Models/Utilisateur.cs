using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetRetard.Models
{
    public class Utilisateur
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prenom { get; set; }

        [Required]
        [MaxLength(20)]
        public string Classe { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdresseMail { get; set; }

        [Required]
        [MaxLength(50)]
        public string MotDePasse { get; set; }

        public virtual List<BilletRetard> BilletsRetards { get; set; }
    }
}