// <copyright file="StorageTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using D5tools.Core.Creatures;
    using D5tools.Core.Spells;
    using D5tools.Services.Storage;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A class for testing storage service
    /// </summary>
    public class StorageTest
    {
        private readonly ITestOutputHelper output;
        private StorageService storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageTest"/> class.
        /// </summary>
        /// <param name="output">The output for the test</param>
        public StorageTest(ITestOutputHelper output)
        {
            this.output = output;
            this.storage = new StorageService();
        }

        /// <summary>
        /// Load a creature library from a test json file
        /// </summary>
        /// <param name="filename">The creature file</param>
        /// <param name="query">The creature name to search for</param>
        /// <param name="shouldPass">Whether the test should pass</param>
        /// <returns>Nothing</returns>
        [Theory]
        [InlineData("data\\bestiary.json", "Zuggtmoy", true)]
        [InlineData("data\\bestiary.json", "Zuggt", false)]
        public async Task CreatureLoad(string filename, string query, bool shouldPass)
        {
            var bestiary = await this.storage.LoadFileAsync<List<Creature>>(filename, StorageStrategies.Package);
            var check = bestiary.Count(c => c.Name == query) == 1;
            Assert.True(check == shouldPass);
        }

        /// <summary>
        /// Load a creature library from a test json file and search by name likeness
        /// </summary>
        /// <param name="filename">the spell file</param>
        /// <param name="query">the string to search in the creature name</param>
        /// <returns>Nothing</returns>
        [Theory]
        [InlineData("data\\bestiary.json", "Crushing Wave")]
        [InlineData("data\\bestiary.json", "Priest")]
        [InlineData("data\\bestiary.json", "Giant")]
        public async Task CreatureOutput(string filename, string query)
        {
            var bestiary = await this.storage.LoadFileAsync<List<Creature>>(filename, StorageStrategies.Package);

            bestiary
                .Where(c => c.Name.ToLower().Contains(query.ToLower())).ToList()
                .ForEach(c => this.output.WriteLine("{0} ({1}) - {2}", c.Name, c.Type, c.Source));
            Assert.True(true);
        }

        /// <summary>
        /// Load a spell library from a test json file
        /// </summary>
        /// <param name="filename">The spell file</param>
        /// <param name="query">The spell name to search for</param>
        /// <param name="shouldPass">Whether the test should pass</param>
        /// <returns>Nothing</returns>
        [Theory]
        [InlineData("data\\grimoire.json", "Absorb Elements", true)]
        [InlineData("data\\grimoire.json", "Abolution", false)]
        public async Task SpellLoad(string filename, string query, bool shouldPass)
        {
            var grimoire = await this.storage.LoadFileAsync<List<Spell>>(filename, StorageStrategies.Package);
            var full = grimoire.Count(s => s.Name == query) == 1;
            Assert.True(full == shouldPass);
        }

        /// <summary>
        /// Load a spell library from a test json file and search by name likeness
        /// </summary>
        /// <param name="filename">the spell file</param>
        /// <param name="query">the string to search in the spell name</param>
        /// <returns>Nothing</returns>
        [Theory]
        [InlineData("data\\grimoire.json", "Protection")]
        [InlineData("data\\grimoire.json", "bolt")]
        [InlineData("data\\grimoire.json", "wall")]
        [InlineData("data\\grimoire.json", "blade")]
        public async Task SpellOutput(string filename, string query)
        {
            var grimoire = await this.storage.LoadFileAsync<List<Spell>>(filename, StorageStrategies.Package);
            grimoire
                .Where(s => s.Name.ToLower().Contains(query.ToLower())).ToList()
                .ForEach(s => this.output.WriteLine("{0} ({1}) {2} - {3}", s.Name, s.Level, s.School, s.Source));
            Assert.True(true);
        }
    }
}