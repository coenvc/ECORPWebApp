using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public class Roof
    {
        public int Width;
        public int Height;
        public int Angle;
        public int Id; 

        public Roof()
        {
            
        }

        public Roof(int width, int height, int angle, int id)
        {
            Width = width;
            Height = height;
            Angle = angle;
            Id = id; 
        }

        public Roof(int width, int height, int angle)
        {
            Width = width;
            Height = height;
            Angle = angle;
        }
    } 
}