using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Contracts
{
    public interface ICitizen
    {
        string Name { get; set; }
        int Age { get; set; }
        
    }
}
