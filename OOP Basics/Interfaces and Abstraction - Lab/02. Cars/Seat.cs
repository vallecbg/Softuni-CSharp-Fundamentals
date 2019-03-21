using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public override string ToString()
        {
            return $"{this.Color} Seat {this.Model}";
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Engine stopped";
        }
    }
}
