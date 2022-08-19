using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsAPI.DataFasades
{
    public class KitchenFasad : ICRUDdbOperations<Kitchen>
    {
        private DataBaseContext dataBaseContext { get; set; }
        public KitchenFasad(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public Kitchen Add(Kitchen element)
        {
            dataBaseContext.Kitchens.Add(element);
            dataBaseContext.SaveChanges();
            return element;
        }
        public bool Delete(Guid id,out string errorMessage)
        {
            Kitchen deleteKitchen = Get(id);
            if (deleteKitchen != null)
            {
                if (dataBaseContext.Restaurants.FirstOrDefault(k => k.KitchenID == id) != null)
                {
                    errorMessage = "Присутствуют связные записи в таблице Restaurant. Удаление отменено";
                    return false;
                }
                else
                {
                    dataBaseContext.Kitchens.Remove(deleteKitchen);
                    dataBaseContext.SaveChanges();
                    errorMessage = null;
                    return true;
                }               
            }
            else
            {
                errorMessage = $"Кухня с id:{id} не найдена";
                return false;
            }
        }
        public Kitchen Edit(Kitchen element)
        {
            Kitchen existingKitchen = Get(element.Id);
            if(element.NameKitchen !="")
            {
                existingKitchen.NameKitchen = element.NameKitchen;
            }          
            dataBaseContext.SaveChanges();
            return existingKitchen;
        }
        public List<Kitchen> Get()
        {
            return dataBaseContext.Kitchens.Include(k => k.Restaurants).ToList();
        }
        public Kitchen Get(Guid id)
        {
            return dataBaseContext.Kitchens.SingleOrDefault(x => x.Id == id);
        }
    }
}
