using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public bool Contains(Point point)
    {
        if (point.X >= TopLeft.X && point.Y >= TopLeft.Y
            && point.X <= BottomRight.X && point.Y <= BottomRight.Y)
        {
            return true;
        }
        return false;
    }
}

