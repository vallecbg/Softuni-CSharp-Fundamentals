using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int HitPointsDamaged = 20;

        public PoisonPotion()
            : base(weight: 5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health = Math.Max(0, character.Health - HitPointsDamaged);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
