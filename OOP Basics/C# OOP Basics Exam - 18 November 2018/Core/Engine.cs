using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Core.IO.Contracts;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly AnimalCentre animalCentre;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalCentre = new AnimalCentre();
        }
        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = this.reader.ReadLine();
                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine("ArgumentException: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("InvalidOperationException: " + e.Message);
                }

                if (this.isRunning == false)
                {
                    this.writer.WriteLine(this.animalCentre.GetAdoptedAnimals());
                    return;
                }
            }
        }

        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command) ||
                command == "End")
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            string name;
            int procedureTime;
            switch (commandName)
            {
                case "RegisterAnimal":
                    var type = args[0];
                    name = args[1];
                    var energy = int.Parse(args[2]);
                    var happiness = int.Parse(args[3]);
                    procedureTime = int.Parse(args[4]);
                    output = this.animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                    break;
                case "Chip":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Chip(name, procedureTime);
                    break;
                case "Vaccinate":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Vaccinate(name, procedureTime);
                    break;
                case "Fitness":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Fitness(name, procedureTime);
                    break;
                case "Play":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.Play(name, procedureTime);
                    break;
                case "DentalCare":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.DentalCare(name, procedureTime);
                    break;
                case "NailTrim":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);
                    output = this.animalCentre.NailTrim(name, procedureTime);
                    break;
                case "Adopt":
                    var animalName = args[0];
                    var owner = args[1];
                    output = this.animalCentre.Adopt(animalName, owner);
                    break;
                case "History":
                    var procedureType = args[0];
                    output = this.animalCentre.History(procedureType);
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
