using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }
        public string Driver { get; set; }
        public string Model { get; set; }
        public string Brake()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brake()}/{this.Gas()}/{this.Driver}";
        }
    }
}
