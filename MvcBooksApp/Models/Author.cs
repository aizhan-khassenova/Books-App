namespace MvcBooksApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [StringLength(30)]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name ="Имя")]
        public string FirstName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}