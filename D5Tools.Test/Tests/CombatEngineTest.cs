// <copyright file="CombatEngineTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test.Tests
{
    using System.Linq;
    using Core.Characters;
    using Core.Combat;
    using Core.Creatures;
    using Core.Encounters;
    using Utils.FightClubConverter;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A test for CombatEngine
    /// </summary>
    public class CombatEngineTest
    {
        private const string MonsterFile = "Files/creaturesFull.xml";
        private readonly ITestOutputHelper output;
        private FightClubConverter bestiary;

        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEngineTest"/> class.
        /// </summary>
        /// <param name="output">The output for the test</param>
        public CombatEngineTest(ITestOutputHelper output)
        {
            this.output = output;
            this.bestiary = new FightClubConverter(MonsterFile);
            this.bestiary.LoadCreatures();
        }

        /// <summary>
        /// Create an encounter
        /// </summary>
        [Fact]
        public void CombatCreate()
        {
            var encounter = this.BuildEncounter();
            this.ShowEncounter(encounter);

            var party = this.BuildParty();
            this.ShowParty(party);

            var combat = new CombatEngine(encounter, party);
            this.ShowCombat(combat);

            this.output.WriteLine("Roll initiative!!!");
            combat.RollInitiative();
            this.ShowCombat(combat);

            this.output.WriteLine("Roll initiative!!!");
            combat.RollInitiative(false);
            this.ShowCombat(combat);

            Assert.True(true);
        }

        private Encounter BuildEncounter()
        {
            var encounter = new Encounter();
            encounter.Name = "Encounter test";
            encounter.Code = "T01";
            encounter.Adventure = "Test Adventure";
            encounter.Tags.Add("test");

            var c1 = this.bestiary.Creatures.Where(c => c.Name == "Bandit").FirstOrDefault();
            var c2 = this.bestiary.Creatures.Where(c => c.Name == "Goblin").FirstOrDefault();
            var c3 = this.bestiary.Creatures.Where(c => c.Name == "Wolf").FirstOrDefault();
            var c4 = this.bestiary.Creatures.Where(c => c.Name == "Goblin").FirstOrDefault();

            encounter.AddCreature(c1);
            encounter.AddCreature(c2);
            encounter.AddCreature(c2);
            encounter.AddCreature(c2);
            encounter.AddCreature(c3);
            encounter.AddCreature(c3);
            encounter.AddCreature(c4);
            return encounter;
        }

        private Party BuildParty()
        {
            var party = new Party();
            for (var i = 1; i < 6; i++)
            {
                var character = new Character();
                character.Name = string.Format("Player {0}", i);
                character.CharacterLevel = 4;
                character.Abilities = new AbilitySet(15, 14, 8, 12, 14, 13);
                party.Characters.Add(character);
            }

            return party;
        }

        private void ShowEncounter(Encounter e)
        {
            this.output.WriteLine("Name: {0} - {1}", e.Code, e.Name);
            this.output.WriteLine("Adventure: {0}", e.Adventure);
            this.output.WriteLine("Monsters:");

            foreach (var g in e.Groups)
            {
                this.output.WriteLine("- {0} [{4} - {5}] ({1}) x{2} = {3}", g.Creature.Name, g.Creature.XP, g.Number, g.XP, g.Creature.Type, g.Creature.Subtype);
            }

            this.output.WriteLine("Total XP: {0}", e.XP);
            this.output.WriteLine(string.Empty);
        }

        private void ShowParty(Party p)
        {
            this.output.WriteLine("Characters:");

            foreach (var c in p.Characters)
            {
                this.output.WriteLine(" - {0} ({1})", c.Name, c.CharacterLevel);
            }

            this.output.WriteLine(string.Empty);
        }

        private void ShowCombat(CombatEngine combat)
        {
            this.output.WriteLine("Combat:");
            foreach (var c in combat.Combatants)
            {
                this.output.WriteLine(" - {0} -> {1}", c.DisplayName, c.InitiativeScore);
            }

            this.output.WriteLine(string.Empty);
        }
    }
}