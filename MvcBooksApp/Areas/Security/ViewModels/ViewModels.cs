using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBooksApp.Areas.Security.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }

    public class EditRoleViewModel
    {
        [Required]
        [Range(1, 9999999999)]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }
    }

    public class DisplayRoleViewModel
    {
        [Required]
        [Range(1, 9999999999)]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}