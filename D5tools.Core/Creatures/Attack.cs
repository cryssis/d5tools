// <copyright file="Attack.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// An attack
    /// </summary>
    public class Attack
    {
        private string name;
        private AttackType type;
        private int bonus;
        private int reach;
        private int minRange;
        private int maxRange;
        private int targets;
        private Damage damage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        public Attack()
        {
        }

        /// <summary>
        /// Gets or sets the Attack name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the AttackType
        /// </summary>
        public AttackType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets the attack bonus
        /// </summary>
        public int Bonus
        {
            get { return this.bonus; }
            set { this.bonus = value; }
        }

        /// <summary>
        /// Gets or sets the attack reach
        /// </summary>
        public int Reach
        {
            get { return this.reach; }
            set { this.reach = value; }
        }

        /// <summary>
        /// Gets or sets the attack minimun range
        /// </summary>
        public int MinRange
        {
            get { return this.minRange; }
            set { this.minRange = value; }
        }

        /// <summary>
        /// Gets or sets the attack maximum range
        /// </summary>
        public int MaxRange
        {
            get { return this.maxRange; }
            set { this.maxRange = value; }
        }

        /// <summary>
        /// Gets or sets the attack targets
        /// </summary>
        public int Targets
        {
            get { return this.targets; }
            set { this.targets = value; }
        }

        /// <summary>
        /// Gets or sets the attack damage
        /// </summary>
        public Damage Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }
    }
}