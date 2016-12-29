using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.LocalRepository
{
    public class LocalProductRepository:IRepository<ISellable>
    {
      
        public static List<ISellable> Products = new List<ISellable>()
        {
            new MountingMaterial("Aluminium Frame", 004, 100, "Custom made", "Dit is montagemateriaal", 10, "Aluminium",10),
            new SolarPanel(270, Enums.CelType.Poly, "Zwart", 100, 20, 10, "Solarmax 270", 001, 10, "Solarmax", "Dit is een mooi zonnepaneel", 20,250),
            new SolarPanel(270, Enums.CelType.Poly, "Zwart", 100, 20, 10, "Solarmax 270", 002, 10, "Solarmax", "Dit is een mooi zonnepaneel", 10,250),
            new Inverter("KLNE 3600", 003, 10, "KLNE", "Dit is een goede omvormer", 10, 3600, 10, "Oranje", true,1000),
            new Inverter("KLNE 3600", 003, 10, "KLNE", "Dit is een goede omvormer", 10, 3600, 10, "Oranje", true,1100)
        };
        private LocalCrud<ISellable> ProductCrud = new LocalCrud<ISellable>(Products);

        public void Insert(ISellable entity)
        {
            ProductCrud.Insert(entity); 
        }

        public void Update(int id, ISellable entity)
        {
            ProductCrud.Update(id, entity);
        }

        public void Delete(int id)
        {
            ProductCrud.Delete(id);
        }

        public ISellable GetById(int id)
        {
            return ProductCrud.GetById(id);
        }

        public List<ISellable> GetAll()
        {
            return ProductCrud.GetAll();
        }


    }
}