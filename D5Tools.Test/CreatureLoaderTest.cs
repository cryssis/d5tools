// <copyright file="CreatureLoaderTest.cs" company="Roberto Sobreviela">
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
        [InlineData("data/creaturesMM.xml", false)]
        [InlineData("data/creaturesFull.xml", true)]
        public async void CreatureLoading(string filename, bool shouldPass)
        {
            CreatureTextReader loader = new CreatureTextReader();
            var bestiary = await loader.LoadFromFile(filename);
            var full = bestiary.Count(c => c.Name == "Zuggtmoy") == 1;
            Assert.True(full == shouldPass);
        }

        /// <summary>
        /// Load a creature library from a test file and search by name likeness
        /// </summary>
        /// <param name="filename">the spell file</param>
        /// <param name="name">the string to search in the creature name</param>
        [Theory]
        [InlineData("data/creaturesFull.xml", "Crushing Wave")]
        [InlineData("data/creaturesFull.xml", "Priest")]
        [InlineData("data/creaturesFull.xml", "Giant")]
        public async void CreatureOutput(string filename, string name)
        {
            CreatureTextReader loader = new CreatureTextReader();
            var bestiary = await loader.LoadFromFile(filename);
            bestiary
                .Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList()
                .ForEach(c => this.output.WriteLine("{0} ({1}) - {2}", c.Name, c.Type, c.Source));
            Assert.True(true);
        }
    }
}