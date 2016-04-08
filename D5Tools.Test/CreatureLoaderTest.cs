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
        [InlineData("Files/mm.xml", false)]
        [InlineData("Files/full.xml", true)]
        public void CreatureLoading(string filename, bool shouldPass)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.Load();
            var full = loader.Creatures.Count(c => c.Name == "Zuggtmoy") == 1;
            Assert.True(full == shouldPass);
        }

        [Theory]
        [InlineData("Files/full.xml", "Crushing Wave")]
        [InlineData("Files/full.xml", "Priest")]
        [InlineData("Files/full.xml", "Giant")]
        public void CreatureOutput(string filename, string name)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.Load();
            loader.Creatures
                .Where(c => c.Name.Contains(name)).ToList()
                .ForEach(c => output.WriteLine("{0} ({1}) - {2}", c.Name, c.Type, c.Source));
            Assert.True(true);
        }
    }
}