using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBooksApp.Models.Configurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            ToTable("Books");
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption
                    .Identity);

            Property(x => x.Title)
                 .HasMaxLength(15)
                .HasColumnName("Title")
                .IsRequired();

            Property(x => x.AuthorId)
                .HasColumnName("AuthorId")
                .IsRequired();

            Property(x => x.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            Property(x => x.Pages)
                .HasColumnName("Pages")
                .IsRequired();

            Property(x => x.Cost)
                .HasColumnName("Cost")
                .IsRequired();

            HasRequired(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Category)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
