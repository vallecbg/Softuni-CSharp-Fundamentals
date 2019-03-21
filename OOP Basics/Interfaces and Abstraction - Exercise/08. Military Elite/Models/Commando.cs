using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstname, string lastname, decimal salary, Corps corps) 
            : base(id, firstname, lastname, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                $"Corps: {Corps}" + Environment.NewLine +
                "Missions:" + (Missions.Count == 0 ? "" : 
                       Environment.NewLine + $"  {string.Join(Environment.NewLine + "  ", Missions)}");
        }
    }
}
