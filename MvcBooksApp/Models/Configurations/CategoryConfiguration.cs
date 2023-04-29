using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBooksApp.Models.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption
                    .Identity);

            Property(x => x.Name)
                 .HasMaxLength(20)
                .HasColumnName("FirstName");

        }
    }
}
