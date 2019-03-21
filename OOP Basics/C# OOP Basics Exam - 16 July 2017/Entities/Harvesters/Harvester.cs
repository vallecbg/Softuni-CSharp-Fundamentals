using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester
{
    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
    public string Id { get; }

    private double oreOutput;

    public double OreOutput
    {
        get => oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }
            oreOutput = value;
        }
    }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get => energyRequirement;
        protected set
        {
            if (value < 0 || value >= 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            energyRequirement = value;
        }
    }


}
