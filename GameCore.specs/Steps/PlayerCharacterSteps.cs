using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;
using System;
using System.Collections.Generic;

namespace GameCore.Specs.Features
{
    [Binding]
    public class PlayerCharacterSteps : TechTalk.SpecFlow.Steps
    {
        private PlayerCharacterStepsContext _context;

        public PlayerCharacterSteps(PlayerCharacterStepsContext context) => _context = context;

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowing(Table table)
        {
            //loosely typed
            string race = table.Rows.First(row => "Race".Equals(row["attribute"]))["value"];
            string damageResistance = table.Rows.First(row => "Resistance".Equals(row["attribute"]))["value"];
            _context.Player.Race = race;
            _context.Player.DamageResistance = int.Parse(damageResistance);

            //strongly typed
            //var attributes = table.CreateInstance<PlayerAttributes>();

            //dynamically typed
            dynamic attributes = table.CreateDynamicInstance();

            _context.Player.Race = attributes.Race;
            _context.Player.DamageResistance = attributes.Resistance;
        }

        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetTo(CharacterClass characterClass) => _context.Player.CharacterClass = characterClass;

        [Given(@"My character race is set to (.*)")]
        public void GivenMyCharacterRaceIsSetTo(string characterRace) => _context.Player.Race = characterRace;

        [Given(@"I have the followingt magical items")]
        public void GivenIHaveTheFollowingtMagicalItems(Table table)
        {
            //weakly typed
            //foreach (var row in table.Rows)
            //{
            //    var name = row["name"];
            //    var power = row["power"];
            //    var value = row["value"];

            //    _context.Player.MagicalItems.Add(new MagicalItem
            //    {
            //        Name = name,
            //        Power = int.Parse(power),
            //        Value = int.Parse(value)
            //    });
            //}

            //strongly typed version
            //foreach (var row in table.Rows)
            //{
            //    MagicalItem magicalItem = row.CreateInstance<MagicalItem>();
            //    _context.Player.MagicalItems.Add(magicalItem);
            //}

            //_context.Player.MagicalItems.AddRange(table.CreateSet<MagicalItem>());

            dynamic magicalItems = table.CreateDynamicSet();
            foreach (var magicalItem in magicalItems)
            {
                _context.Player.MagicalItems.Add(new MagicalItem()
                {
                    Name = magicalItem.name,
                    Power = magicalItem.power,
                    Value = magicalItem.value
                });
            }
        }

        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastSleepTime) => _context.Player.LastSleepTime = lastSleepTime;

        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<Weapon> weapons) => _context.Player.Weapons.AddRange(weapons);

        [Given(@"I have a magical (.*) with a power of (.*)")]
        public void GivenIHaveAMagicalWithAPowerOf(string itemName, int power)
        {
            _context.Player.MagicalItems.Add(new MagicalItem()
            {
                Name = itemName,
                Power = power
            });
            _context.StartingMagicalPower = power;
        }

        [When(@"I use a magical (.*)")]
        public void WhenIUseAMagical(string magicalItem) => _context.Player.UseMagicalItem(magicalItem);

        [Then(@"The magical (.*) power should not be reduced")]
        public void ThenTheAmuletPowerShouldNotBeReduced(string itemName) => Assert.Equal(_context.StartingMagicalPower, _context.Player.MagicalItems.First(item => item.Name.Equals(itemName)).Power);

        [Then(@"My weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldBeWorth(int weaponsWorth) => Assert.Equal(weaponsWorth, _context.Player.WeaponsValue);

        [When(@"I read a restore health scroll")]
        public void WhenIReadARestoreHealthScroll() => _context.Player.ReadHealthScroll();

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int expectedPower) => Assert.Equal(_context.Player.MagicalPower, expectedPower);

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell() => _context.Player.CastHealingSpell();

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage) => _context.Player.Hit(damage);

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth) => Assert.Equal(expectedHealth, _context.Player.Health);

        [Then(@"I should be dead")]
        public void ThenIShouldBeDead() => Assert.True(_context.Player.IsDead);
    }
}
