
using System;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;

    private readonly DraftManager draftManager;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        while (true)
        {
            var command = this.reader.ReadLine();
            if (command == "Shutdown")
            {
                this.writer.WriteLine(this.draftManager.ShutDown());
                return;
            }

            try
            {
                var commandResult = this.ProcessCommand(command);
                this.writer.WriteLine(commandResult);
            }
            catch (ArgumentException e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }

    private string ProcessCommand(string command)
    {
        var commandArgs = command.Split(' ');
        var commandName = commandArgs[0];
        var args = commandArgs.Skip(1).ToArray();

        var output = string.Empty;
        switch (commandName)
        {
            case "RegisterHarvester":
                output = this.draftManager.RegisterHarvester(args.ToList());
                break;
            case "RegisterProvider":
                output = this.draftManager.RegisterProvider(args.ToList());
                break;
            case "Day":
                output = this.draftManager.Day();
                break;
            case "Mode":
                output = this.draftManager.Mode(args.ToList());
                break;
            case "Check":
                output = this.draftManager.Check(args.ToList());
                break;
            case "Shutdown":
                output = this.draftManager.ShutDown();
                break;
        }

        return output;
    }
}