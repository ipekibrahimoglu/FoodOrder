using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class ReviewDto: IDto
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public int Rating { get; set; }

        //Navigation properties
        public UserDto? User { get; set; }
        public RestaurantDto? Restaurant { get; set; }
    }
}
