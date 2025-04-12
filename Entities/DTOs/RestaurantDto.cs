using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class RestaurantDto : IDto
    {
        public Guid RestaurantId { get; set; }
        public Guid OwnerId { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; } 
    }
}
