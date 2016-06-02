// <copyright file="AbilitySet.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Creature Ability Set
    /// </summary>
    public class AbilitySet
    {
        private Dictionary<Stats, Ability> abilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbilitySet"/> class.
        /// </summary>
        public AbilitySet()
        {
            this.abilities = new Dictionary<Stats, Ability>();
            foreach (Stats s in Enum.GetValues(typeof(Stats)))
            {
                this.abilities.Add(s, new Ability(10));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbilitySet"/> class.
        /// </summary>
        /// <param name="s">strength score</param>
        /// <param name="d">dexterity score</param>
        /// <param name="c">constitution score</param>
        /// <param name="i">intelligence score</param>
        /// <param name="w">wisdom score</param>
        /// <param name="ch">charisma score</param>
        public AbilitySet(int s, int d, int c, int i, int w, int ch)
        {
            this.abilities = new Dictionary<Stats, Ability>();
            this.abilities.Add(Stats.Strength, new Ability(s));
            this.abilities.Add(Stats.Dexterity, new Ability(d));
            this.abilities.Add(Stats.Constitution, new Ability(c));
            this.abilities.Add(Stats.Intelligence, new Ability(i));
            this.abilities.Add(Stats.Wisdom, new Ability(w));
            this.abilities.Add(Stats.Charisma, new Ability(ch));
        }

        /// <summary>
        /// Gets or sets strength score
        /// </summary>
        public Ability Str
        {
            get { return this.abilities[Stats.Strength]; }
            set { this.abilities[Stats.Strength] = value; }
        }

        /// <summary>
        /// Gets or sets dexterity score
        /// </summary>
        public Ability Dex
        {
            get { return this.abilities[Stats.Dexterity]; }
            set { this.abilities[Stats.Dexterity] = value; }
        }

        /// <summary>
        /// Gets or sets Constitution score
        /// </summary>
        public Ability Con
        {
            get { return this.abilities[Stats.Constitution]; }
            set { this.abilities[Stats.Constitution] = value; }
        }

        /// <summary>
        /// Gets or sets intelligence score
        /// </summary>
        public Ability Int
        {
            get { return this.abilities[Stats.Intelligence]; }
            set { this.abilities[Stats.Intelligence] = value; }
        }

        /// <summary>
        /// Gets or sets wisdom score
        /// </summary>
        public Ability Wis
        {
            get { return this.abilities[Stats.Wisdom]; }
            set { this.abilities[Stats.Wisdom] = value; }
        }

        /// <summary>
        /// Gets or sets charisma score
        /// </summary>
        public Ability Cha
        {
            get { return this.abilities[Stats.Charisma]; }
            set { this.abilities[Stats.Charisma] = value; }
        }
    }
}