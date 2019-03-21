using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Contracts.Characters;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Characters.Factory;
using DungeonsAndCodeWizards.Models.Items;
using DungeonsAndCodeWizards.Models.Items.Factory;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private readonly List<Character> party;
        private readonly Stack<Item> pool;

        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.pool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }
        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];

            Character character = characterFactory.CreateCharacter(faction, characterType, name);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            Item item = itemFactory.CreateItem(itemName);
            this.pool.Push(item);

            return $"{item.GetType().Name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var lastItem = this.pool.Peek();
            Character character = party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            this.pool.Pop();
            character.ReceiveItem(lastItem);
            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];
            Character character = party.First(x => x.Name == characterName);
            if (character.Name != characterName)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];
            Character giver = party.First(x => x.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            Character receiver = party.First(x => x.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giver.Bag.GetItem(itemName);
            receiver.UseItemOn(item, receiver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];
            Character giver = party.First(x => x.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            Character receiver = party.First(x => x.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, receiver);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            var count = 0;
            foreach (var character in party
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                if (count == 0)
                {
                    sb.Append(character);
                }
                else
                {
                    sb.Append(Environment.NewLine + character);
                }

                count++;
            }

            return sb.ToString();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];
            Character attacker = party.FirstOrDefault(x => x.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (!(attacker is IAttackable attackCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attackCharacter.Attack(receiver);

            var output = $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (receiver.Health <= 0)
            {
                receiver.IsAlive = false;
                output += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return output;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];
            Character healer = party.First(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            Character healReceiver = party.First(x => x.Name == healingReceiverName);
            if (healReceiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (!(healer is IHealable healCharacter))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            healCharacter.Heal(healReceiver);
            var output = $"{healer.Name} heals {healReceiver.Name} for {healer.AbilityPoints}! {healReceiver.Name} has {healReceiver.Health} health now!";
            return output;
        }

        public string EndTurn(string[] args)
        {
            var characters = party.Where(x => x.IsAlive).ToArray();
            var sb = new StringBuilder();

            foreach (var character in characters)
            {
                var healthBeforeRest = character.Health;

                character.Rest();

                var healthAfterRest = character.Health;

                sb.Append($"{character.Name} rests ({healthBeforeRest} => {healthAfterRest})");
                sb.Append(Environment.NewLine);
            }

            if (characters.Length <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.party.Count(c => c.IsAlive) <= 1;
            var lastSurviverSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }

    }
}
