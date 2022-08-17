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
            dataBaseContext.Restaurant.Add(element);
            dataBaseContext.SaveChanges();
            return element;
        }
        public bool Delete(Guid id)
        {
            Restaurant deleteElement = Get(id);
            if (deleteElement != null)
            {
                dataBaseContext.Restaurant.Remove(deleteElement);
                dataBaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Restaurant Edit(Restaurant element)
        {
            Restaurant existingRestoran = Get(element.Id);
            if (!string.IsNullOrWhiteSpace(element.Name))
            {
                existingRestoran.Name = element.Name;
            }
            if (element.OpenTime != null)
            {
                existingRestoran.OpenTime = element.OpenTime;
            }       
            if (element.CloseTime != null)
            {
                existingRestoran.CloseTime = element.CloseTime;
            }
            if (!string.IsNullOrWhiteSpace(element.Address))
            {
                existingRestoran.Address = element.Address;
            }
            if (element.Rating != null)
            {
                existingRestoran.Rating = element.Rating;
            }
            if (dataBaseContext.Kitchen.FirstOrDefault(k => k.Id == element.KitchenID) != null || element.KitchenID == Guid.Empty)
            {
                existingRestoran.KitchenID = element.KitchenID;
            }
            dataBaseContext.SaveChanges();
            return existingRestoran;          
        }
        public List<Restaurant> Get()
        {
            return dataBaseContext.Restaurant.ToList();        
        }
        public Restaurant Get(Guid id)
        {
            return dataBaseContext.Restaurant.SingleOrDefault(x => x.Id == id);
        }
    }
}
