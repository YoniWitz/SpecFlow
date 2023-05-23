using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    public class Hooks : TechTalk.SpecFlow.Steps
    {
        [BeforeScenario("elf", Order = 100)]
        public void BeforeScenario()
        {

        }
        [BeforeScenario("elf", Order = 200)]
        public void BeforeScenario2()
        {

        }

        [AfterScenario()]
        public void AfterElfScenario()
        {

        }
    }
}
