// <copyright file="SpellLoaderTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test
{
    using System.Linq;
    using D5tools.Data.Systems.FightClub;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A test for Creature Loading from file
    /// </summary>
    public class SpellLoaderTest
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellLoaderTest"/> class.
        /// </summary>
        /// <param name="output">The output for the test</param>
        public SpellLoaderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Load a spell library from a test file
        /// </summary>
        /// <param name="filename">The spell file</param>
        /// <param name="shouldPass">Whether the test should pass</param>
        [Theory]
        [InlineData("data/spellsPHB.xml", false)]
        [InlineData("data/spellsFull.xml", true)]
        public void SpellLoading(string filename, bool shouldPass)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.LoadSpells();
            var full = loader.Spells.Count(s => s.Name == "Absorb Elements") == 1;
            Assert.True(full == shouldPass);
        }

        /// <summary>
        /// Load a spell library from a test file and search by name likeness
        /// </summary>
        /// <param name="filename">the spell file</param>
        /// <param name="name">the string to search in the spell name</param>
        [Theory]
        [InlineData("data/spellsFull.xml", "Protection")]
        [InlineData("data/spellsFull.xml", "bolt")]
        [InlineData("data/spellsFull.xml", "wall")]
        [InlineData("data/spellsFull.xml", "blade")]
        public void SpellOutput(string filename, string name)
        {
            FightClubConverter loader = new FightClubConverter(filename);
            loader.LoadSpells();
            loader.Spells
                .Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList()
                .ForEach(s => this.output.WriteLine("{0} ({1}) {2} - {3}", s.Name, s.Level, s.School, s.Source));
            Assert.True(true);
        }
    }
}