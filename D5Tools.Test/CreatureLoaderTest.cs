using System.Diagnostics;
using System.Linq;
using D5tools.Core.Creatures;
using D5tools.Utils.FightClubConverter;
using Xunit;
using Xunit.Abstractions;

namespace D5Tools.Test
{
    public class CreatureLoaderTest
    {
        private readonly ITestOutputHelper output;

        public CreatureLoaderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("Files/creaturesMM.xml", false)]
        [InlineData("Files/creaturesFull.xml", true)]
        public void CreatureLoading(string filename, bool shouldPass)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.LoadCreatures();
            var full = loader.Creatures.Count(c => c.Name == "Zuggtmoy") == 1;
            Assert.True(full == shouldPass);
        }

        [Theory]
        [InlineData("Files/creaturesFull.xml", "Crushing Wave")]
        [InlineData("Files/creaturesFull.xml", "Priest")]
        [InlineData("Files/creaturesFull.xml", "Giant")]
        public void CreatureOutput(string filename, string name)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.LoadCreatures();
            loader.Creatures
                .Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList()
                .ForEach(c => output.WriteLine("{0} ({1}) - {2}", c.Name, c.Type, c.Source));
            Assert.True(true);
        }

        [Theory]
        [InlineData("Files/spellsPHB.xml", false)]
        [InlineData("Files/spellsFull.xml", true)]
        public void SpellLoading(string filename, bool shouldPass)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.LoadSpells();
            var full = loader.Spells.Count(s => s.Name == "Absorb Elements") == 1;
            Assert.True(full == shouldPass);
        }

        [Theory]
        [InlineData("Files/spellsFull.xml", "Protection")]
        [InlineData("Files/spellsFull.xml", "bolt")]
        [InlineData("Files/spellsFull.xml", "wall")]
        [InlineData("Files/spellsFull.xml", "blade")]
        public void SpellOutput(string filename, string name)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.LoadSpells();
            loader.Spells
                .Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList()
                .ForEach(s => output.WriteLine("{0} ({1}) {2} - {3}", s.Name, s.Level, s.School, s.Source));
            Assert.True(true);
        }
    }
}