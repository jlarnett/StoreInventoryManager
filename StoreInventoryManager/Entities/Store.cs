using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManager.Entities
{
    public class Store
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength]
        [Required]
        public string Description { get; set; }

        [Range(0, 400000)]
        public decimal Capital { get; set; }
    }
}
