using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;

namespace EcoRP.Repositories.LocalRepository
{
    public class LocalCrud<T> where T : class, ICruddable
    {
        public List<T> All = new List<T>();
        public int Counter = 0;


        public LocalCrud()
        {
            
        }

        public LocalCrud(List<T> all)
        {

            if (Counter == 0)
            {
                Init(all);
            }
            else
            {
                All = all;
            }
        }

        /// <summary>
        /// initialize the class by adding the given list of ICruddable to the Property 
        /// use the Insert method so the Id's are consistent
        /// </summary>
        private void Init(List<T> startItems)
        {
            for (int i = 0; i < startItems.Count; i++)
            {
                Insert(startItems[i]);
            }

        }
        /// <summary>
        /// Inserts object into a list and gives it an ID 
        /// </summary>
        /// <param name="item"></param>
        public void Insert(T item)
        {
            Counter++;
            item.Id = Counter;
            All.Add(item);
        }
        /// <summary>
        /// Removes object from a list
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public void Delete(int id)
        {
            T toBeDeleted = null;
            foreach (T cruddable in All)
            {
                if (cruddable.Id == id)
                {
                    toBeDeleted = cruddable;
                    break;
                }
            }
            if (toBeDeleted != null)
            {
                All.Remove(toBeDeleted);
            }
        }
        /// <summary>
        /// Updates an item in the list 
        /// </summary>
        /// <param name="id">id of the item that needs to be removed</param>
        /// <param name="item">object that needs to be replacing the old obejct</param>
        public void Update(int id, T item)
        {
            All.RemoveAll(x => x.Id == id);
            item.Id = id;
            All.Add(item);
        }

        /// <summary>
        /// Returns every object in the list 
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            List<T> returnObjects = new List<T>();
            foreach (T crudItem in All)
            {
                returnObjects.Add(crudItem);
            }

            return returnObjects;

        }
        /// <summary>
        /// Returns an object of any type by the id
        /// </summary>
        /// <param name="id">ID of the object that you want to retrieve</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            T returnValue = All.First(x => x.Id == id);

            return returnValue;
        }


    }
}