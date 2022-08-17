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
            dataBaseContext.Kitchen.Add(element);
            dataBaseContext.SaveChanges();
            return element;
        }
        public bool Delete(Guid id)
        {
            Kitchen deleteElement = Get(id);
            if (deleteElement != null)
            {
                dataBaseContext.Kitchen.Remove(deleteElement);
                dataBaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Kitchen Edit(Kitchen element)
        {
            Kitchen existingRestoran = Get(element.Id);
            if(element.NameKitchen !="")
            {
                existingRestoran.NameKitchen = element.NameKitchen;
            }          
            dataBaseContext.SaveChanges();
            return existingRestoran;
        }
        public List<Kitchen> Get()
        {
            return dataBaseContext.Kitchen.ToList();
        }
        public Kitchen Get(Guid id)
        {
            return dataBaseContext.Kitchen.SingleOrDefault(x => x.Id == id);
        }
    }
}
