// <copyright file="CreatureLoaderTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5Tools.Test
{
    using System.Diagnostics;
    using System.Linq;
    using D5tools.Core.Creatures;
    using D5tools.Utils.FightClubConverter;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A test for Creature Loading from file
    /// </summary>
    public class CreatureLoaderTest
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatureLoaderTest"/> class.
        /// </summary>
        /// <param name="output">The output for the test</param>
        public CreatureLoaderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Load a creature library from a test file
        /// </summary>
        /// <param name="filename">The creature file</param>
        /// <param name="shouldPass">Whether the test should pass</param>
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

        /// <summary>
        /// Load a creature library from a test file and search by name likeness
        /// </summary>
        /// <param name="filename">the spell file</param>
        /// <param name="name">the string to search in the creature name</param>
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
                .ForEach(c => this.output.WriteLine("{0} ({1}) - {2}", c.Name, c.Type, c.Source));
            Assert.True(true);
        }
    }
}