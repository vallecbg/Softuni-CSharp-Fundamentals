using System;
using System.Collections.Generic;
using System.Text;

class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return length; }
        private set
        {
            length = value;
        }
    }
    public double Width
    {
        get { return width; }
        private set
        {
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            height = value;
        }
    }
    public double CalculateVolume()
    {
        return this.Length * this.Width * this.Height;
    }

    public double CalculateLateralSurface()
    {
        return 2 * this.Length * this.Height +
               2 * this.Width * this.Height;
    }
    public double CalculateSurfaceArea()
    {
        return 2 * this.Length * this.Width +
               2 * this.Length * this.Height +
               2 * this.Width * this.Height;
    }
}
