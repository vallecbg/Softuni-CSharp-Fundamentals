using System;
using System.Collections.Generic;
using System.Text;


public abstract class Provider
{
    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }
    public string Id { get; }

    private double energyOutput;

    public virtual double EnergyOutput
    {
        get => energyOutput;
        private set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }

            energyOutput = value;
        }
    }


}
