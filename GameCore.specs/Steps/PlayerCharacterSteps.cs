using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;

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
            //var attributes = table.CreateInstance<PlayerAttributes>();
            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;
        }

        [Given(@"MY character class is set to (.*)")]
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
