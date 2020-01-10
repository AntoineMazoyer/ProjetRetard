using ProjetRetard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetRetard.DAL
{
    public class ProjetRetardInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProjetRetardContext>
    {
        protected override void Seed(ProjetRetardContext context)
        {
            var utilisateurs = new List<Utilisateur>
            {
            new Utilisateur{Nom="Montagne", Prenom="Wilfried", Classe="B3 Classe 2", AdresseMail="wilfried@epsi.fr",  MotDePasse="123"},
            new Utilisateur{Nom="Mazoyer", Prenom="Antoine", Classe="B3 Classe 2", AdresseMail="antoine@epsi.fr",  MotDePasse="123"},
            };

            utilisateurs.ForEach(u => context.Utilisateurs.Add(u));
            context.SaveChanges();
        }

    }
}