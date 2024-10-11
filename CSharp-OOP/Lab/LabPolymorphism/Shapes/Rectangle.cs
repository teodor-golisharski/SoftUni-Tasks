using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        private double height;
        private double width;

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (width + height);
        }
        public override string Draw()
        {
            return $"Drawing {nameof(Rectangle)}";
        }
    }
}
