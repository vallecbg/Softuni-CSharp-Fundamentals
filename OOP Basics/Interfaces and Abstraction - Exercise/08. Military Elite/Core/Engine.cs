using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                /*
                 * Private <id> <firstName> <lastName> <salary>
                 * LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>
                 * Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>
                 * Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>
                 * Spy <id> <firstName> <lastName> <codeNumber>
                 */
                var inputTokens = input.Split();
                var type = inputTokens[0];
                var id = int.Parse(inputTokens[1]);
                var firstName = inputTokens[2];
                var lastName = inputTokens[3];
                decimal salary;

                switch (type)
                {
                    case "Private":
                        salary = decimal.Parse(inputTokens[4]);
                        if (this.soldiers.Any(x => x.Id == id))
                        {
                            break;
                        }
                        CreatePrivateSoldier(id, firstName, lastName, salary);
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(inputTokens[4]);
                        if (this.soldiers.Any(x => x.Id == id))
                        {
                            break;
                        }
                        CreateLieutenantGeneral(inputTokens, id, firstName, lastName, salary);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(inputTokens[4]);
                        if (this.soldiers.Any(x => x.Id == id))
                        {
                            break;
                        }
                        CreateEngineer(inputTokens, id, firstName, lastName, salary);
                        break;
                    case "Commando":
                        salary = decimal.Parse(inputTokens[4]);
                        if (this.soldiers.Any(x => x.Id == id))
                        {
                            break;
                        }
                        CreateCommando(inputTokens, id, firstName, lastName, salary);
                        break;
                    case "Spy":
                        if (this.soldiers.Any(x => x.Id == id))
                        {
                            break;
                        }
                        CreateSpy(inputTokens, id, firstName, lastName);
                        break;
                }
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private void CreateSpy(string[] inputTokens, int id, string firstName, string lastName)
        {
            var codeNumber = int.Parse(inputTokens[4]);
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);
            this.soldiers.Add(spy);
        }

        private void CreateCommando(string[] inputTokens, int id, string firstName, string lastName, decimal salary)
        {
            var commandoCorpToString = inputTokens[5];
            if (Enum.TryParse(commandoCorpToString, out Corps commandoCorps))
            {
                ICommando commando = new Commando(id, firstName, lastName, salary, commandoCorps);
                for (int i = 6; i < inputTokens.Length; i += 2)
                {
                    var missionCodeName = inputTokens[i];
                    var missionState = inputTokens[i + 1];
                    if (Enum.TryParse(missionState, out State missionResult))
                    {
                        IMission mission = new Mission(missionCodeName, missionResult);
                        commando.Missions.Add(mission);
                    }
                }
                this.soldiers.Add(commando);
            }
        }

        private void CreateEngineer(string[] inputTokens, int id, string firstName, string lastName, decimal salary)
        {
            var engineerCorpToString = inputTokens[5];
            if (Enum.TryParse(engineerCorpToString, out Corps engineerCorps))
            {
                IEngineer engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);
                for (int i = 6; i < inputTokens.Length; i += 2)
                {
                    var partName = inputTokens[i];
                    var hoursWorked = int.Parse(inputTokens[i + 1]);
                    IRepair repair = new Repair(partName, hoursWorked);
                    engineer.Repairs.Add(repair);
                }
                this.soldiers.Add(engineer);
            }
        }

        private void CreateLieutenantGeneral(string[] inputTokens, int id, string firstName, string lastName, decimal salary)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
            for (int i = 5; i < inputTokens.Length; i++)
            {
                var privateId = int.Parse(inputTokens[i]);
                if (this.soldiers.Any(x => x.Id == privateId))
                {
                    foreach (var soldier in soldiers)
                    {
                        if (soldier.Id == privateId)
                        {
                            lieutenantGeneral.Privates.Add((IPrivate)soldier);
                            break;
                        }
                    }
                }
            }

            this.soldiers.Add(lieutenantGeneral);
        }

        private void CreatePrivateSoldier(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
            this.soldiers.Add(privateSoldier);
        }
    }
}
