using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Circle : Shape
    {
        public Circle(double radius)
        {
            this.radius = radius;
        }

        private double radius;

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
        public override string Draw()
        {
            return $"Drawing {nameof(Circle)}";
        }
    }
}
