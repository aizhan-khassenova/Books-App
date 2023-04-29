using Microsoft.AspNet.Identity.EntityFramework;
//using MvcBooksApp.Models.Configurations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MvcBooksApp.Models
{
    public partial class BooksEntities : IdentityDbContext<User
            , Role
            , int
            , UserLogin
            , RelUserRole
            , UserClaim>
    {
        public BooksEntities()
            : base("name=BooksEntities")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public static BooksEntities Create()
        {
            return new BooksEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new AuthorConfiguration());
            //modelBuilder.Configurations.Add(new CategoryConfiguration());
            //modelBuilder.Configurations.Add(new BookConfiguration());

            //modelBuilder.Configurations.Add(new UserLoginConfiguration());
            //modelBuilder.Configurations.Add(new RelUserRoleConfiguration());
            //modelBuilder.Configurations.Add(new UserClaimConfiguration());
            //modelBuilder.Configurations.Add(new UserConfiguration());
            //modelBuilder.Configurations.Add(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
