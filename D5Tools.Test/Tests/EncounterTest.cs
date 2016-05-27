// <copyright file="EncounterTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using D5tools.Core.Characters;
    using D5tools.Core.Encounters;
    using D5tools.Data.Systems.FightClub;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A test for Encounter
    /// </summary>
    public class EncounterTest
    {
        private const string MonsterFile = "creaturesFull.xml";
        private readonly ITestOutputHelper output;

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
        /// <param name="p">The party size</param>
        /// <returns>Nothing</returns>
        [Theory]
        [InlineData(PartySize.Small)]
        [InlineData(PartySize.Normal)]
        [InlineData(PartySize.Large)]
        public async Task EncounterCreate(PartySize p)
        {
            CreatureTextReader loader = new CreatureTextReader();
            var install = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var folder = await install.GetFolderAsync("data");
            var bestiary = await loader.LoadFromFile(MonsterFile, folder);

            var e1 = new Encounter();
            e1.Name = "Encounter test";
            e1.Code = "T01";
            e1.Adventure = "Test Adventure";
            e1.Tags.Add("test");

            var c1 = bestiary.Where(c => c.Name == "Bandit").FirstOrDefault();
            var c2 = bestiary.Where(c => c.Name == "Goblin").FirstOrDefault();
            var c3 = bestiary.Where(c => c.Name == "Wolf").FirstOrDefault();
            var c4 = bestiary.Where(c => c.Name == "Goblin").FirstOrDefault();

            e1.AddCreature(c1);
            e1.AddCreature(c2);
            e1.AddCreature(c2);
            e1.AddCreature(c2);
            e1.AddCreature(c3);
            e1.AddCreature(c3);
            e1.AddCreature(c4);

            this.ShowEncounter(e1, p);

            e1.RemoveCreature(c1);

            this.ShowEncounter(e1, p);

            e1.RemoveCreature(c2);

            this.ShowEncounter(e1, p);

            Assert.True(true);
        }

        private void ShowEncounter(Encounter e, PartySize p)
        {
            this.output.WriteLine("Name: {0} - {1}", e.Code, e.Name);
            this.output.WriteLine("Adventure: {0}", e.Adventure);
            this.output.WriteLine("Monsters:");

            foreach (var g in e.Groups)
            {
                this.output.WriteLine("- {0} [{4}] ({1}) x{2} = {3}", g.Creature.Name, g.Creature.XP, g.Number, g.XP, g.Creature.Subtype);
            }

            this.output.WriteLine("Total XP: {0}", e.XP);
            this.output.WriteLine("Adjusted XP: {0}", e.GetAdjustedXP(p));
            this.output.WriteLine(string.Empty);
        }
    }
}