using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TramApi.Models;

namespace TramApi.Repository
{
    public class LocalTramRepository
    {
        private List<Tram> Trams = new List<Tram>();

        public List<Tram> GetAll()
        {
            List<Tram> _trams = Trams;

            return _trams;
        }

        public void Insert(Tram tram)
        {
            Trams.Add(tram); 
        }
    } 
}