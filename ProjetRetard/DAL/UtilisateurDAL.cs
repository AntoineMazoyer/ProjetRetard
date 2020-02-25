using ProjetRetard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetRetard.DAL
{
    public static class UtilisateurDAL
    {

        // Récupère un utilisateur dans la BDD grâce à l'ID correspondant passé en paramètre.
        public static Utilisateur getUtilisateurFromId(int idParam)
        {
            using (var db = new ProjetRetardContext())
            {
                var resultat = (from u in db.Utilisateurs
                              where u.ID.Equals(idParam)
                              select u).FirstOrDefault();
                return resultat;
            }
        }

        // Récupère l'ID d'un utilisateur dans la BDD grâce à l'adresse mail correspondante passée en paramètre.
        public static int getIdUtilisateurFromEmail(string emailParam)
        {
            using (var db = new ProjetRetardContext())
            {
                var resultat = (from u in db.Utilisateurs
                                where u.AdresseMail.Equals(emailParam)
                                select u.ID).FirstOrDefault();
                return resultat;
            }
        }
}
}