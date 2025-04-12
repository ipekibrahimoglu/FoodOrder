using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Entities.Concrete
{
    public class MenuItem : IEntity
    {
        public Guid MenuItemId { get; set; }
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; } // nullable
        public Menu Menu { get; set; }
    }
}
