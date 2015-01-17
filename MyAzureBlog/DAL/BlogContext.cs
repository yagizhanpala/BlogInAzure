using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyAzureBlog.Models;
using MyAzureBlog.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using MyAzureBlog.Security;

namespace MyAzureBlog.DAL
{
    // 03.01.2014 DbContext yerine  IdentityDbContext<MyIdentityUser> ypala
    public class BlogContext : IdentityDbContext<MyIdentityUser>
    {
        public BlogContext() : base("BlogContext")
        {
            this.Configuration.LazyLoadingEnabled = false; // ypala 17.01.2014
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext,Configuration>("BlogContext"));
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}