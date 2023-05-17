using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public class PlayerCharacter
    {
        public int Health { get; private set; } = 100;
        public bool IsDead { get; private set; }
        public int DamageResistance { get; set; }
        public string Race { get; set; }
        public List<MagicalItem> MagicalItems { get; set; } = new List<MagicalItem>();

        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public CharacterClass CharacterClass { get; set; }
        public DateTime LastSleepTime { get; set; }

        public int WeaponsValue
        {
            get => Weapons.Sum(x => x.Value);
        }

        public int MagicalPower
        {
            get => MagicalItems.Sum(x => x.Power);
        }

        public void Hit(int damage)
        {
            var raceSpecificDamageResistance = Race == "Elf" ? 20 : 0;

            var totalDamageTaken = Math.Max(damage - raceSpecificDamageResistance - DamageResistance, 0);

            Health -= totalDamageTaken;
            if (Health <= 0) IsDead = true;
        }
        public void CastHealingSpell() => Health = CharacterClass.Healer.Equals(CharacterClass) ? 100 : Health + 10;

        public void ReadHealthScroll()
        {
            var daysSinceLastSleep = DateTime.Now.Subtract(LastSleepTime).Days;
            if (daysSinceLastSleep <= 2) Health = 100;
        }

        public void UseMagicalItem(string itemName)
        {
            var itemToReduce = MagicalItems.First(item => item.Name.Equals(itemName));
            itemToReduce.Power -= "Elf".Equals(Race) ? 0 : 10;
        }
    }
}