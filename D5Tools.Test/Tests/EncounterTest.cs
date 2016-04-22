namespace D5tools.Test.Tests
{
    using System.Diagnostics;
    using System.Linq;
    using Core.Encounters;
    using D5tools.Core.Creatures;
    using D5tools.Utils.FightClubConverter;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A test for Encounter
    /// </summary>
    public class EncounterTest
    {
        private readonly ITestOutputHelper output;
        private const string monsterFile = "Files/creaturesFull.xml";

        /// <summary>
        /// Initializes a new instance of the <see cref="EncounterTest"/> class.
        /// </summary>
        /// <param name="output">The output for the test</param>
        public EncounterTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Create an encounter
        /// </summary>
        [Fact]
        public void EncounterCreate()
        {
            FightClubConverter bestiary = new FightClubConverter(monsterFile);
            bestiary.LoadCreatures();

            var e1 = new Encounter();
            e1.Name = "Encounter test";
            e1.Code = "T01";
            e1.Adventure = "Test Adventure";
            e1.Tags.Add("test");

            var c1 = bestiary.Creatures.Where(c => c.Name == "Bandit").FirstOrDefault();
            var c2 = bestiary.Creatures.Where(c => c.Name == "Goblin").FirstOrDefault();
            var c3 = bestiary.Creatures.Where(c => c.Name == "Wolf").FirstOrDefault();
            var c4 = bestiary.Creatures.Where(c => c.Name == "Goblin").FirstOrDefault();

            e1.AddCreature(c1);
            e1.AddCreature(c2);
            e1.AddCreature(c2);
            e1.AddCreature(c2);
            e1.AddCreature(c3);
            e1.AddCreature(c3);
            e1.AddCreature(c4);

            ShowEncounter(e1);

            e1.RemoveCreature(c1);

            ShowEncounter(e1);

            e1.RemoveCreature(c2);

            ShowEncounter(e1);

            Assert.True(true);
        }

        private void ShowEncounter(Encounter e)
        {
            this.output.WriteLine("Name: {0} - {1}", e.Code, e.Name);
            this.output.WriteLine("Adventure: {0}", e.Adventure);
            this.output.WriteLine("Monsters:");
            foreach (var g in e.Groups)
            {
                this.output.WriteLine("- {0} [{4}] ({1}) x{2} = {3}", g.Creature.Name, g.Creature.XP, g.Number, g.XP, g.Creature.Subtype);
            }
            this.output.WriteLine("Total XP: {0}", e.XP);
            this.output.WriteLine("");
        }
    }
}