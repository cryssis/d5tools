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

        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEngine"/> class.
        /// </summary>
        public CombatEngine()
        {
            this.combatants = new List<Combatant>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombatEngine"/> class.
        /// </summary>
        /// <param name="e">The encounter to be played</param>
        /// <param name="p">The Character Party</param>
        public CombatEngine(Encounter e, Party p)
        {
            foreach (var c in p.Characters)
            {
                var cb = new Combatant(c);
                this.combatants.Add(cb);
            }

            foreach (var g in e.Groups)
            {
                for (var i = 1; i <= g.Number; i++)
                {
                    var cb = new Combatant(g.Creature);
                    this.combatants.Add(cb);
                }
            }
        }

        /// <summary>
        /// Gets or sets the combatants in the combat
        /// </summary>
        public List<Combatant> Combatants
        {
            get { return this.combatants; }
            set { this.combatants = value; }
        }
    }
}
