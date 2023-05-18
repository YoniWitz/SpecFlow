using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;
using System;

namespace GameCore.Specs.Features
{
    [Binding]
    public class PlayerCharacterSteps
    {
        private PlayerCharacter _player;

        [Given(@"I'm a new player")]
        public void GivenIMANewPlayer() => _player = new PlayerCharacter();

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowing(Table table)
        {
            //loosely typed
            string race = table.Rows.First(row => "Race".Equals(row["attribute"]))["value"];
            string damageResistance = table.Rows.First(row => "Resistance".Equals(row["attribute"]))["value"];
            _player.Race = race;
            _player.DamageResistance = int.Parse(damageResistance);

            //strongly typed
            //var attributes = table.CreateInstance<PlayerAttributes>();
            
            //dynamically typed
            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;
        }

        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetTo(CharacterClass characterClass) => _player.CharacterClass = characterClass; 

        [Given(@"I have the followingt magical items")]
        public void GivenIHaveTheFollowingtMagicalItems(Table table)
        {
            //weakly typed
            //foreach (var row in table.Rows)
            //{
            //    var name = row["name"];
            //    var power = row["power"];
            //    var value = row["value"];

            //    _player.MagicalItems.Add(new MagicalItem
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
            //    _player.MagicalItems.Add(magicalItem);
            //}

            //_player.MagicalItems.AddRange(table.CreateSet<MagicalItem>());

            dynamic magicalItems = table.CreateDynamicSet();
            foreach (var magicalItem in magicalItems)
            {
                _player.MagicalItems.Add(new MagicalItem()
                {
                    Name = magicalItem.name,
                    Power = magicalItem.power,
                    Value = magicalItem.value
                });
            }
        }

        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastSleepTime)=> _player.LastSleepTime = lastSleepTime;

        [When(@"I read a restore health scroll")]
        public void WhenIReadARestoreHealthScroll()=> _player.ReadHealthScroll();

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int expectedPower) => Assert.Equal(_player.MagicalPower, expectedPower);

        public void GivenMYCharacterClassIsSetTo(CharacterClass characterClass) => _player.CharacterClass = characterClass;

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell() => _player.CastHealingSpell();

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage) => _player.Hit(damage);

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth) => Assert.Equal(expectedHealth, _player.Health);

        [Then(@"I should be dead")]
        public void ThenIShouldBeDead() => Assert.True(_player.IsDead);
    }
}
