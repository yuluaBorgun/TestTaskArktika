using RestaurantsAPI.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsAPI.Models
{
    public class Kitchen
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string NameKitchen { get; set; }
        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}
