namespace MvcBooksApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Выберите автора")]
        public int? AuthorId { get; set; }

        [Required]
        [Display(Name = "Выберите категорию")]
        public int? CategoryId { get; set; }

        [Required]
        [Display(Name = "Количество страниц")]
        [Range(3,9999)]
        public int? Pages { get; set; }

        [Required]
        [Display(Name = "Цена")]
        [Range(10, 999999)]
        public int? Cost { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }
    }
}
