using MvcBooksApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBooksApp.ViewModels
{
    public class DisplayBookViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Наименование")]
        public string Title { get; set; }

        public int? AuthorId { get; set; }

        public int? CategoryId { get; set; }

        [Display(Name = "Количество страниц")]
        public int? Pages { get; set; }

        [Display(Name = "Цена")]
        public int? Cost { get; set; }

        [Display(Name = "Автор")]
        public string AuthorName { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
    }
}