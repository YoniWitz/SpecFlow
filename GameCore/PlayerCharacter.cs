using System;

namespace GameCore
{
    public class PlayerCharacter
    {
        public int Health { get; private set; } = 100;
        public bool IsDead { get; private set; }
        public int DamageResistance { get; set; }
        public string Race { get; set; }

        public void Hit(int damage)
        {
            var raceSpecificDamageResistance = Race == "Elf" ? 20 : 0;

            var totalDamageTaken = Math.Max(damage - raceSpecificDamageResistance - DamageResistance, 0);

            Health -= totalDamageTaken;
            if (Health <= 0) IsDead = true;
        }
    }
}