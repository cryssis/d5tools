// <copyright file="Damage.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System;
    using System.Collections.Generic;
    using D5tools.Core.Dice;

    /// <summary>
    /// Damage of an attack
    /// </summary>
    public class Damage
    {
        private string damageRoll;
        private DieRoll roll;
        private List<DamageType> damageTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class.
        /// </summary>
        public Damage()
        {
            this.damageTypes = new List<DamageType>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class.
        /// </summary>
        /// <param name="roll">The dice roll</param>
        /// <param name="type">The damage types for the roll</param>
        public Damage(DieRoll roll, List<DamageType> type)
        {
            if (roll.AllRolls.Count != type.Count)
            {
                throw new ArgumentException("The number of rolls and damage types doesn't match.");
            }

            this.roll = roll;
            this.damageRoll = roll.ToString();
            this.damageTypes = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class.
        /// </summary>
        /// <param name="roll">The string for dice roll</param>
        /// <param name="type">The damage types for the roll</param>
        public Damage(string roll, List<DamageType> type)
        {
            var dieRoll = DieRoll.FromString(roll);

            if (dieRoll.AllRolls.Count != type.Count)
            {
                throw new ArgumentException("The number of rolls and damage types doesn't match.");
            }

            this.roll = dieRoll;
            this.damageRoll = roll;
            this.damageTypes = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class.
        /// </summary>
        /// <param name="roll">The string for dice roll</param>
        public Damage(string roll)
        {
            var dieRoll = DieRoll.FromString(roll);

            this.roll = dieRoll;
            this.damageRoll = roll;
        }

        /// <summary>
        /// Gets the damage roll
        /// </summary>
        public DieRoll Roll
        {
            get { return this.roll; }
        }

        /// <summary>
        /// Gets the damage types
        /// </summary>
        public List<DamageType> Type
        {
            get { return this.damageTypes; }
        }
    }
}