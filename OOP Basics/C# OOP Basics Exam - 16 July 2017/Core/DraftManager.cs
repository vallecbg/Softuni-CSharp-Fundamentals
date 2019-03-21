using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Enum mode;
    private readonly List<Harvester> harvesters;
    private readonly List<Provider> providers;
    private double totalEnergyStored;
    private double totalMinedOre;

    private readonly HarvesterFactory harvesterFactory;
    private readonly ProviderFactory providerFactory;

    public DraftManager()
    {
        this.mode = Modes.FullMode;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();

        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }


    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);
            return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }

    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);

            return $"Successfully registered {arguments[0]} Provider - {provider.Id}";
        }
        catch (ArgumentException e)
        {
            return(e.Message);
        }
    }
    public string Day()
    {
        double totalEnergyNeeded = 0;
        double summedOreOutput = 0;
        double summedEnergyOutput = this.providers.Sum(p => p.EnergyOutput);
        this.totalEnergyStored += summedEnergyOutput;
        switch (this.mode)
        {
            case Modes.FullMode:
                totalEnergyNeeded = this.harvesters.Sum(h => h.EnergyRequirement);
                if (this.totalEnergyStored >= totalEnergyNeeded)
                {
                    summedOreOutput = this.harvesters.Sum(h => h.OreOutput);
                    this.totalMinedOre += summedOreOutput;
                    this.totalEnergyStored -= totalEnergyNeeded;
                }
                break;

            case Modes.HalfMode:
                totalEnergyNeeded = this.harvesters.Sum(h => h.EnergyRequirement) * 0.60;
                if (this.totalEnergyStored >= totalEnergyNeeded)
                {
                    summedOreOutput = this.harvesters.Sum(h => h.OreOutput) * 0.50;
                    this.totalMinedOre += summedOreOutput;
                    this.totalEnergyStored -= totalEnergyNeeded;
                }
                break;

            case Modes.EnergyMode:
                break;

            default:
                break;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {summedEnergyOutput}");
        sb.Append($"Plumbus Ore Mined: {summedOreOutput}");

        return sb.ToString();
    }
    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        switch (mode)
        {
            case "Full":
                this.mode = Modes.FullMode;
                break;
            case "Half":
                this.mode = Modes.HalfMode;
                break;
            case "Energy":
                this.mode = Modes.EnergyMode;
                break;
        }

        return $"Successfully changed working mode to {mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        Harvester harvester = this.harvesters.FirstOrDefault(x => x.Id == id);
        Provider provider = this.providers.FirstOrDefault(x => x.Id == id);
        var sb = new StringBuilder();

        if (harvester != null)
        {
            switch (harvester.GetType().Name)
            {
                case "HammerHarvester":
                    sb.Append($"Hammer Harvester - {id}" + Environment.NewLine);
                    break;
                case "SonicHarvester":
                    sb.Append($"Sonic Harvester - {id}" + Environment.NewLine);
                    break;
            }
            sb.Append($"Ore Output: {harvester.OreOutput}" + Environment.NewLine +
                   $"Energy Requirement: {harvester.EnergyRequirement}");
            return sb.ToString();
        }

        if (provider != null)
        {
            switch (provider.GetType().Name)
            {
                case "PressureProvider":
                    sb.Append($"Pressure Provider - {id}" + Environment.NewLine);
                    break;
                case "SolarProvider":
                    sb.Append($"Solar Provider - {id}" + Environment.NewLine);
                    break;
            }
            sb.Append($"Energy Output: {provider.EnergyOutput}");
            return sb.ToString();
        }
        return $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
               $"Total Energy Stored: {this.totalEnergyStored}" + Environment.NewLine +
               $"Total Mined Plumbus Ore: {this.totalMinedOre}";
    }

}
