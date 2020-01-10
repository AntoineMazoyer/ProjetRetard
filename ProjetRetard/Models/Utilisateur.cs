using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetRetard.Models
{
    public class Utilisateur
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Vous devez mettre votre nom")]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Vous devez mettre votre prénom")]
        [MaxLength(50)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Vous devez renseigné votre classe")]
        [MaxLength(20)]
        public string Classe { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer votre adresse mail")]
        [MaxLength(50)]
        [EmailAddress]
        public string AdresseMail { get; set; }

        [Required(ErrorMessage = "Vous devez mettre un mot de passe")]
        [MaxLength(50)]
        public string MotDePasse { get; set; }

        public virtual ICollection<BilletRetard> BilletsRetards { get; set; }

        public Utilisateur()
        {
            BilletsRetards = new List<BilletRetard>();
        }
    }
}