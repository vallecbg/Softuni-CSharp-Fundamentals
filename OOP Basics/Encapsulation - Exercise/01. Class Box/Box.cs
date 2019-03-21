using System;
using System.Collections.Generic;
using System.Text;

class Box
{
    private readonly double length;
    private readonly double width;
    private readonly double height;
    private double volume;
    private double lateralSurface;
    private double surfaceArea;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
        Calculate(this.length, this.width, this.height);
    }

    public void Calculate(double length, double width, double height)
    {
        this.volume = this.length * this.width * this.height;
        this.lateralSurface =
            2 * this.length * this.height +
            2 * this.width * this.height;
        this.surfaceArea =
            2 * this.length * this.width +
            2 * this.length * this.height +
            2 * this.width * this.height;
    }

    public override string ToString()
    {
        return $"Surface Area - {surfaceArea:f2}" + Environment.NewLine +
               $"Lateral Surface Area - {lateralSurface:f2}" + Environment.NewLine +
               $"Volume - {volume:f2}";
    }
}
