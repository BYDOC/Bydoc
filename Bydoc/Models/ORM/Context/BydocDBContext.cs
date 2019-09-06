using Bydoc.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Bydoc.Models.ORM.Context
{
    public class BydocDBContext:DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public BydocDBContext()
        {
            Database.Connection.ConnectionString = "server=.;database=BydocDB;Trusted_connection=true";
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }
    }
}