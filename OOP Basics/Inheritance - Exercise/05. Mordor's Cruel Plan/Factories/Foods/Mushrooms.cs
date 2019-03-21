using System;
using System.Collections.Generic;
using System.Text;

namespace MordorCruelPlan.Factories.Foods
{
    public class Mushrooms : Food
    {
        private const int PointsOfHappiness = -10;

        public Mushrooms() : base(PointsOfHappiness)
        {
        }
    }
}