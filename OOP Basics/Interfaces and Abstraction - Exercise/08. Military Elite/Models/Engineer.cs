using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstname, string lastname, decimal salary, Corps corps) : base(id, firstname, lastname, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Corps: {Corps}" + Environment.NewLine +
                "Repairs:" + (Repairs.Count == 0 ? "" :
                       Environment.NewLine + $"  {string.Join(Environment.NewLine + "  ", Repairs)}");
        }
    }
}
