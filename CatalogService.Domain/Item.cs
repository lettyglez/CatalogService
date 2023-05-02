using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CatalogService.Domain
{
    public class Item
    {
        [Key]
        public string NameItem { get; set; } 
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Name))]
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
