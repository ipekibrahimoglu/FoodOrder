using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Entities.Concrete
{
    public class Review : IEntity
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }

        //[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")] 
        public int Rating { get; set; } // fluent validation kodu yazıldı.

        public User? User { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
