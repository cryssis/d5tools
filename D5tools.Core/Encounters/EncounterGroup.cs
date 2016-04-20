// <copyright file="EncounterGroup.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Encounters
{
    using D5tools.Core.Creatures;

    /// <summary>
    /// A groups of creatures in an encounter
    /// </summary>
    public class EncounterGroup
    {
        private Creature creature;
        private int number;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncounterGroup"/> class.
        /// </summary>
        /// <param name="c">The creature in the group</param>
        public EncounterGroup(Creature c)
        {
            this.creature = c;
            this.number = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncounterGroup"/> class.
        /// </summary>
        /// <param name="c">The creature in the group</param>
        /// <param name="number">the number of creatures in the group</param>
        public EncounterGroup(Creature c, int number)
        {
            this.creature = c;
            this.number = number;
        }

        /// <summary>
        /// Gets or sets the creature in the group
        /// </summary>
        public Creature Creature
        {
            get { return this.creature; }
            set { this.creature = value; }
        }

        /// <summary>
        /// Gets or sets the number of creatures for the group
        /// </summary>
        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        /// <summary>
        /// Gets the group XP
        /// </summary>
        public int XP
        {
            get { return this.creature.XP * this.number; }
        }
    }
}