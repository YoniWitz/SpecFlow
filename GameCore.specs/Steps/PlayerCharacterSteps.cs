using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace GameCore.Specs.Features
{
    [Binding]
    public class PlayerCharacterSteps
    {

        private PlayerCharacter _player;


        [Given(@"I'm a new player")]
        public void GivenIMANewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [Given(@"I have the following")]
        public void GivenIHaveTheFollowing(Table table)
        {
            string race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            string damageResistance = table.Rows.First(row => row["attribute"] == "DamageResistance")["value"];

            _player.Race = race;
            _player.DamageResistance = int.Parse(damageResistance);
        }


        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage);
        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth)
        {
            Assert.Equal(expectedHealth, _player.Health);
        }

        [Then(@"I should be dead")]
        public void ThenIShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }

    }
}
