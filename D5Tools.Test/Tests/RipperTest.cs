// <copyright file="RipperTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using D5tools.Utils.Ripper;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A test for Ripper
    /// </summary>
    public class RipperTest
    {
        private const string MonsterFile = "creaturesFull.xml";
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="RipperTest"/> class.
        /// </summary>
        /// <param name="output">The output for the test</param>
        public RipperTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Rip the files
        /// </summary>
        /// <returns>Nothing</returns>
        [Fact]
        public async Task FightClubRip()
        {
            FightClubRipper ripper = new FightClubRipper();
            var install = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var folder = await install.GetFolderAsync("data");
            var filename = Path.Combine(folder.Path, "creaturesFull.xml");
            this.output.WriteLine("1: {0}", filename);
            var result = await ripper.RipCreaturesFromFile(filename);
            Assert.True(result);
            filename = Path.Combine(folder.Path, "spellsFull.xml");
            this.output.WriteLine("1: {0}", filename);
            result = await ripper.RipSpellsFromFile(filename);
            Assert.True(result);
        }
    }
}