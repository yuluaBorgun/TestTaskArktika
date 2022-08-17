using RestaurantsAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantsAPI.Migrations
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        public double? Rating { get; set; }
        public Guid? KitchenID { get; set; }
        public virtual Kitchen Kitchen { get; set; }
    }
}
