using System;
using System.Collections.Generic;
using System.Text;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        if (oreOutput < 0)
        {
            throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
        }

        var energyRequirement = double.Parse(arguments[3]);
        if (energyRequirement < 0 || energyRequirement >= 20000)
        {
            throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
        }

        Harvester harvester = null;
        switch (type)
        {
            case "Sonic":
                var sonicFactor = int.Parse(arguments[4]);
                harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                break;
            case "Hammer":
                harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                break;
        }

        return harvester;
    }
}
