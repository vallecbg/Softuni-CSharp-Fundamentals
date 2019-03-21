using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IMember : ICitizen, IRobot
    {
        string Id { get; set; }
    }
}
