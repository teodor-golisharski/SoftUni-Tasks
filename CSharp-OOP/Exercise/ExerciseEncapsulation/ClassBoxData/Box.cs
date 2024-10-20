﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width; 
            Height = height;
        }

        private double length;
        private double width;
        private double height;
        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"Length cannot be zero or negative.");
                length = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"Width cannot be zero or negative.");
                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException($"Height cannot be zero or negative.");
                height = value;
            }
        }
        public double SurfaceArea()
        {
            return (2 * width * height) + (2 * length * height) + (2 * width * length);
        }
        public double LateralSurfaceArea()
        {
            return (2 * width * height) + (2 * length * height);
        }
        public double Volume()
        {
            return width * height * length;
        }
    }
}
