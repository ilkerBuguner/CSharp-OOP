using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (width + height);
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DrawLine(width, '*', '*'));

            for (int i = 1; i < height - 1; ++i)
            {
                sb.AppendLine(DrawLine(width, '*', ' '));
            }

            sb.AppendLine(DrawLine(width, '*', '*'));

            return sb.ToString().TrimEnd();
        }

        private string DrawLine(int width, char end, char mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(end.ToString());

            for (int i = 1; i < width - 1; ++i)
            {
                sb.Append(mid);
            }

            sb.AppendLine(end.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
