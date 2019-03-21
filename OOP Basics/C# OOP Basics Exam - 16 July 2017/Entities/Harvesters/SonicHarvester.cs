using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    public int SonicFactor { get; private set; }
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement / sonicFactor)
    {
        this.SonicFactor = sonicFactor;
    }
}
