using ProjetRetard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjetRetard.DAL
{
    public class ProjetRetardContext:DbContext
    {
        public ProjetRetardContext() : base("name=ProjetRetardBDD")
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<BilletRetard> BilletsRetards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}