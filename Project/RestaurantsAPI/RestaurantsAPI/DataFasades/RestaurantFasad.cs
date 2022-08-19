using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsAPI.DataFasades
{
    public class RestaurantFasad : ICRUDdbOperations<Restaurant>
    {
        private DataBaseContext dataBaseContext { get; set; }
        public RestaurantFasad(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public Restaurant Add(Restaurant element)
        {
            dataBaseContext.Restaurants.Add(element);
            dataBaseContext.SaveChanges();
            return element;
        }
        public bool Delete(Guid id, out string errorMessage)
        {
            Restaurant deleteRestaurant = Get(id);
            if (deleteRestaurant != null)
            {
                dataBaseContext.Restaurants.Remove(deleteRestaurant);
                dataBaseContext.SaveChanges();
                errorMessage = null;
                return true;
            }
            else
            {
                errorMessage = $"Ресторан с id:{id} не найден";
                return false;
            }
        }
        public Restaurant Edit(Restaurant element)
        {
            Restaurant existingRestaurant = Get(element.Id);
            if (!string.IsNullOrWhiteSpace(element.Name))
            {
                existingRestaurant.Name = element.Name;
            }
            if (element.OpenTime != null)
            {
                existingRestaurant.OpenTime = element.OpenTime;
            }       
            if (element.CloseTime != null)
            {
                existingRestaurant.CloseTime = element.CloseTime;
            }
            if (!string.IsNullOrWhiteSpace(element.Address))
            {
                existingRestaurant.Address = element.Address;
            }
            if (element.Rating != null)
            {
                existingRestaurant.Rating = element.Rating;
            }
            if (dataBaseContext.Kitchens.FirstOrDefault(k => k.Id == element.KitchenID) != null || element.KitchenID == Guid.Empty)
            {
                existingRestaurant.KitchenID = element.KitchenID;
            }
            dataBaseContext.SaveChanges();
            return existingRestaurant;          
        }
        public List<Restaurant> Get()
        {
           return dataBaseContext.Restaurants.Include(r=>r.Kitchen).ToList();
        }
        public Restaurant Get(Guid id)
        {
            return dataBaseContext.Restaurants.Include(r => r.Kitchen).SingleOrDefault(x => x.Id == id);
        }
    }
}
