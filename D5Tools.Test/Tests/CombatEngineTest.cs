// <copyright file="CombatEngineTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test.Tests
{
    using System.Collections;
    using System.Collections.Generic;
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
            this.ShowCombatInitiative(combat);

            this.output.WriteLine("Roll initiative!!!");
            combat.RollInitiative();
            this.ShowCombatInitiative(combat);
            combat.SortByInitiative();
            this.ShowCombatInitiative(combat);

            this.output.WriteLine("Roll initiative!!!");
            combat.RollInitiative(false);
            this.ShowCombatInitiative(combat);
            combat.SortByInitiative();
            this.ShowCombatInitiative(combat);

            Assert.True(true);
        }

        /// <summary>
        /// Sort by Initiative
        /// </summary>
        /// <param name="grouped">The creaters are grouped</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SortInititative(bool grouped)
        {
            var encounter = this.BuildEncounter();
            var party = this.BuildParty();
            var combat = new CombatEngine(encounter, party);
            int p = 0, c = 0;

            int[] initPlayer = new int[] { 7, 12, 13, 4, 4 };
            int[] initCreature = new int[] { 2, 11, 16, 14, 4, 7, 9 };

            foreach (var cb in combat.Combatants)
            {
                if (cb.IsPlayer)
                {
                    cb.InitiativeScore = initPlayer[p];
                    p++;
                }
                else
                {
                    if (grouped)
                    {
                        if (cb.InitiativeScore == 0)
                        {
                            var combatants = combat.Combatants.Where(creatures => creatures.Group == cb.Group);
                            foreach (var cr in combatants)
                            {
                                cr.InitiativeScore = initCreature[c];
                            }

                            c++;
                        }
                    }
                    else
                    {
                        cb.InitiativeScore = initCreature[c];
                        c++;
                    }
                }
            }

            this.ShowCombatInitiative(combat);

            combat.SortByInitiative();
            this.ShowCombatInitiative(combat);

            Assert.True(true);
        }

        /// <summary>
        /// Turn and Round Movement
        /// </summary>
        [Fact]
        public void CombatMoveTest()
        {
            var encounter = this.BuildEncounter();
            var party = this.BuildParty();
            var combat = new CombatEngine(encounter, party);

            this.output.WriteLine("Roll initiative!!!");
            combat.RollInitiative();
            this.ShowCombatInitiative(combat);

            combat.Start();
            this.ShowCombat(combat);
            this.output.WriteLine("Next!");
            combat.Next();
            this.ShowCombat(combat);
            this.output.WriteLine("Back!");
            combat.Previous();
            this.ShowCombat(combat);
            this.output.WriteLine("Oops!");
            combat.Previous();
            this.ShowCombat(combat);
            for (var i = 1; i <= 20; i++)
            {
                this.output.WriteLine("Next!");
                combat.Next();
                this.ShowCombat(combat);
            }

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
                character.Player = string.Format("Jugador {0}", i);
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
                this.output.WriteLine("- {0} [{4} - {5}] ({1}xp) x{2} = {3}xp", g.Creature.Name, g.Creature.XP, g.Number, g.XP, g.Creature.Type, g.Creature.Subtype);
            }

            this.output.WriteLine("Total XP: {0}xp", e.XP);
            this.output.WriteLine(string.Empty);
        }

        private void ShowParty(Party p)
        {
            this.output.WriteLine("Characters:");

            foreach (var c in p.Characters)
            {
                this.output.WriteLine(" - {0} (Level {1})", c.Name, c.CharacterLevel);
            }

            this.output.WriteLine(string.Empty);
        }

        private void ShowCombatInitiative(CombatEngine combat)
        {
            this.output.WriteLine("Initiative:");
            foreach (var c in combat.Combatants)
            {
                this.output.WriteLine(" - {0} {1} -> [{2}]->[{3}] {4}", c.DisplayName, c.DisplayHP, c.InitiativeRoll?.Text ?? string.Empty, c.InitiativeResult?.Text ?? string.Empty, c.InitiativeScore);
            }

            this.output.WriteLine(string.Empty);
        }

        private void ShowCombat(CombatEngine combat)
        {
            this.output.WriteLine("Combat: Round {0}, Initiative count: {1}", combat.Round, combat.Active.InitiativeScore);
            foreach (var c in combat.Combatants)
            {
                this.output.WriteLine(" {0} [{1}]: {2} {3}", c == combat.Active ? ">" : "-", c.InitiativeScore, c.DisplayName, c.DisplayHP);
            }

            this.output.WriteLine(string.Empty);
        }
    }
}