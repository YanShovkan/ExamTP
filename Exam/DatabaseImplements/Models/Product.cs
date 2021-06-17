using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplements.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<Component> ProductComponents { get; set; }
    }
}
