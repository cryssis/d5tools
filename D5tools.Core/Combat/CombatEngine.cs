// <copyright file="CombatEngine.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Combat
{
    using System.Collections.Generic;
    using System.Linq;
    using D5tools.Core.Characters;
    using D5tools.Core.Encounters;

    /// <summary>
    /// The Combat engine
    /// </summary>
    public class CombatEngine
    {
        private List<Combatant> combatants;
        private Party party;
        private Encounter encounter;
        private bool running;
        private Combatant active;
        private int round;

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
            this.active = null;
        }

        /// <summary>
        /// Gets the combatants in the combat
        /// </summary>
        public List<Combatant> Combatants
        {
            get { return this.combatants; }
        }

        /// <summary>
        /// Gets a value indicating whether the combat engine is running;
        /// </summary>
        public bool IsRunning
        {
            get { return this.running; }
        }

        /// <summary>
        /// Gets the combat round
        /// </summary>
        public int Round
        {
            get { return this.round; }
        }

        /// <summary>
        /// Gets the active combatant
        /// </summary>
        public Combatant Active
        {
            get { return this.active; }
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
                var first = combatants.First();
                if (!first.IsPlayer && grouped)
                {
                    first.RollInitiative();
                    foreach (var cb in combatants.Skip(1))
                    {
                        cb.InitiativeResult = first.InitiativeResult;
                        cb.InitiativeRoll = first.InitiativeRoll;
                        cb.InitiativeScore = first.InitiativeScore;
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

        /// <summary>
        /// Starts the engine
        /// </summary>
        public void Start()
        {
            this.SortByInitiative();
            this.round = 1;
            this.active = this.combatants.First();
            this.running = true;
        }

        /// <summary>
        /// Ends the engine
        /// </summary>
        public void End()
        {
            this.running = false;
            this.active = null;
        }

        /// <summary>
        /// Moves to Next Turn
        /// </summary>
        public void Next()
        {
            var next = this.combatants.IndexOf(this.active) + 1;
            if (next >= this.combatants.Count)
            {
                next = 0;
                this.round++;
            }

            this.active = this.combatants[next];
        }

        /// <summary>
        /// Moves to Previous Turn
        /// </summary>
        public void Previous()
        {
            var prev = this.combatants.IndexOf(this.active) - 1;
            if (prev < 0)
            {
                if (this.round > 1)
                {
                    prev = this.combatants.Count - 1;
                    this.round--;
                }
                else
                {
                    return;
                }
            }

            this.active = this.combatants[prev];
        }

        /// <summary>
        /// Sorts the combatants by Inititative order
        /// </summary>
        public void SortByInitiative()
        {
            this.combatants.Sort();
        }
    }
}