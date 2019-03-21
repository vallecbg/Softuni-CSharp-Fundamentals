using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Contracts.Characters
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
