using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface IFerrari
    {
        string Driver { get; set; }
        string Model { get; set; }
        string Brake();
        string Gas();
    }
}
