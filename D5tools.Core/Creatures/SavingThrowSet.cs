// <copyright file="SavingThrowSet.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Creature Saving Throws Set
    /// </summary>
    public class SavingThrowSet
    {
        private Dictionary<Stats, int> savings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingThrowSet"/> class.
        /// </summary>
        public SavingThrowSet()
        {
            this.savings = new Dictionary<Stats, int>();
            foreach (Stats s in Enum.GetValues(typeof(Stats)))
            {
                this.savings.Add(s, 0);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingThrowSet"/> class.
        /// </summary>
        /// <param name="s">Strength save modifier.</param>
        /// <param name="d">Dexterity save modifier.</param>
        /// <param name="c">Constitution save modifier.</param>
        /// <param name="i">Intelligence save modifier.</param>
        /// <param name="w">Wisdom save modifier.</param>
        /// <param name="ch">Charisma save modifier.</param>
        public SavingThrowSet(int s, int d, int c, int i, int w, int ch)
        {
            this.savings = new Dictionary<Stats, int>();
            this.savings.Add(Stats.Strength, s);
            this.savings.Add(Stats.Dexterity, d);
            this.savings.Add(Stats.Constitution, c);
            this.savings.Add(Stats.Intelligence, i);
            this.savings.Add(Stats.Wisdom, w);
            this.savings.Add(Stats.Charisma, ch);
        }

        /// <summary>
        /// Gets or sets the saving throw modifiers
        /// </summary>
        public Dictionary<Stats, int> Savings
        {
            get { return this.savings; }
            set { this.savings = value; }
        }
    }
}