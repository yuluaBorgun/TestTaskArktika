using RestaurantsAPI.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaurantsAPI.Models
{
    public class Kitchen
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string NameKitchen { get; set; }
        [JsonIgnore]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
