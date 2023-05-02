using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CatalogService.Domain
{
    public class Category
    {
        [Key]
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
