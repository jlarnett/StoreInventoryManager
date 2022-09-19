using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryManager.Entities
{
    public class StoreItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RemainingQuantity { get; set; }
        public Store Store { get; set; }
        public int StoreId { get; set; }

    }
}
