// <copyright file="SpellLoaderTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
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
        /// <returns>Nothing</returns>
        [Theory]
        [InlineData("spellsPHB.xml", false)]
        [InlineData("spellsFull.xml", true)]
        public async Task SpellLoading(string filename, bool shouldPass)
        {
            SpellTextReader loader = new SpellTextReader();
            var install = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var folder = await install.GetFolderAsync("data");
            var grimoire = await loader.LoadFromFile(filename, folder);
            var full = grimoire.Count(s => s.Name == "Absorb Elements") == 1;
            Assert.True(full == shouldPass);
        }

        /// <summary>
        /// Load a spell library from a test file and search by name likeness
        /// </summary>
        /// <param name="filename">the spell file</param>
        /// <param name="name">the string to search in the spell name</param>
        /// <returns>Nothing</returns>
        [Theory]
        [InlineData("spellsFull.xml", "Protection")]
        [InlineData("spellsFull.xml", "bolt")]
        [InlineData("spellsFull.xml", "wall")]
        [InlineData("spellsFull.xml", "blade")]
        public async Task SpellOutput(string filename, string name)
        {
            SpellTextReader loader = new SpellTextReader();
            var install = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var folder = await install.GetFolderAsync("data");
            var grimoire = await loader.LoadFromFile(filename, folder);
            grimoire
                .Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList()
                .ForEach(s => this.output.WriteLine("{0} ({1}) {2} - {3}", s.Name, s.Level, s.School, s.Source));
            Assert.True(true);
        }
    }
}