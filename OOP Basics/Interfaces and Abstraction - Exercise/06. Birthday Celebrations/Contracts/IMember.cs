using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Contracts
{
    public interface IMember : IPet, IRobot, ICitizen
    {
        long Id { get; set; }
        string Birthdate { get; set; }
    }
}
