﻿using TechTalk.SpecFlow;

namespace GameCore.Specs.Steps
{
    [Binding]
    class CommonPlayerCharacterSteps
    {
        private readonly PlayerCharacterStepsContext _context;

        public CommonPlayerCharacterSteps(PlayerCharacterStepsContext context)
        {
            _context = context;
        }

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer() => _context.Player = new PlayerCharacter();
    }
}
 