using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FashionStyles.Models
{
   public  class Store
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name="store Name")]
        public string Name { get; set; }
     //   public Product Products { get; set; }
    }
}
