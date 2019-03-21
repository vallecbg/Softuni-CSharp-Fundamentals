using System;
using AnimalCentre.Core;
using DungeonsAndCodeWizards.Core.IO;
using DungeonsAndCodeWizards.Core.IO.Contracts;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
