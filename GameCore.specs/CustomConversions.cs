using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GameCore.Specs
{
    [Binding]
    class CustomConversions
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgoTransformation(int daysAgo) => DateTime.Now.Subtract(TimeSpan.FromDays(daysAgo));

        [StepArgumentTransformation]
        public IEnumerable<Weapon> WeaponsTransformation(Table table) => table.CreateSet<Weapon>();
    }
}
