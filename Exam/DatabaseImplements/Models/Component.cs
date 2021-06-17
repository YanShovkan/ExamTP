using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplements.Models
{
    public class Component
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
