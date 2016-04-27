// <copyright file="CombatEngine.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Combat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Characters;
    using Encounters;

    /// <summary>
    /// The Combat engine
    /// </summary>
    public class CombatEngine
    {
        private List<Combatant> combatants;
        private Party party;
        private Encounter encounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEngine"/> class.
        /// </summary>
        /// <param name="e">The encounter to be played</param>
        /// <param name="p">The Character Party</param>
        public CombatEngine(Encounter e, Party p)
            : this()
        {
            this.encounter = e;
            this.party = p;

            foreach (var c in this.party.Characters)
            {
                var cb = new Combatant(c);
                this.AddCombatant(cb);
            }

            foreach (var g in this.encounter.Groups)
            {
                for (var i = 1; i <= g.Number; i++)
                {
                    var cb = new Combatant(g.Creature);
                    this.AddCombatant(cb);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEngine"/> class.
        /// </summary>
        private CombatEngine()
        {
            this.combatants = new List<Combatant>();
            this.party = new Party();
            this.encounter = new Encounter();
        }

        /// <summary>
        /// Gets the combatants in the combat
        /// </summary>
        public List<Combatant> Combatants
        {
            get { return this.combatants; }
        }

        /// <summary>
        /// Adds a Combatant to the combat
        /// </summary>
        /// <param name="c">The combatant</param>
        public void AddCombatant(Combatant c)
        {
            c.IndexLabel = this.combatants.Where(cb => cb.Group == c.Group).Count() + 1;
            this.combatants.Add(c);
        }

        /// <summary>
        /// Clears the Initiative Score for all combatants
        /// </summary>
        public void ClearInitiative()
        {
            this.combatants.ForEach(cb => cb.InitiativeScore = 0);
        }

        /// <summary>
        /// Rolls initiative for the combat
        /// </summary>
        /// <param name="grouped">Roll same initiative for creature groups. Default true.</param>
        public void RollInitiative(bool grouped = true)
        {
            this.ClearInitiative();
            var groups = this.combatants.Select(cb => cb.Group).Distinct();
            foreach (var group in groups)
            {
                var combatants = this.combatants.Where(cb => cb.Group == group);
                if (!combatants.First().IsPlayer && grouped)
                {
                    combatants.First().RollInitiative();
                    var initScore = combatants.First().InitiativeScore;
                    foreach (var cb in combatants.Skip(1))
                    {
                        cb.InitiativeScore = initScore;
                    }
                }
                else
                {
                    foreach (var cb in combatants)
                    {
                        cb.RollInitiative();
                    }
                }
            }
        }
    }
}