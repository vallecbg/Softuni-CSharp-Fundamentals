using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstname, string lastname, decimal salary) 
            : base(id, firstname, lastname, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                "Privates:" + (Privates.Count == 0 ? "" :
                       Environment.NewLine + $"  {string.Join(Environment.NewLine + "  ", Privates)}");
        }
    }
}
