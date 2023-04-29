using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBooksApp.Models.Configurations
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            ToTable("Authors");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName)
                .HasMaxLength(30)
                .HasColumnName("FirstName");

            Property(x => x.LastName)
                .HasMaxLength(30)
                .HasColumnName("LastName");
        }
    }
}
