using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetRetard.Models
{
    public class Vote
    {
        [Key]
        public int ID { get; set; }

        public int PouceVert { get; set; }

        public int PouceRouge { get; set; }
    }
}