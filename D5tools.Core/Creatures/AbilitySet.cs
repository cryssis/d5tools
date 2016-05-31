// <copyright file="AbilitySet.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// Creature Ability Set
    /// </summary>
    public class AbilitySet
    {
        private Ability strength;
        private Ability dexterity;
        private Ability constitution;
        private Ability intelligence;
        private Ability wisdom;
        private Ability charisma;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbilitySet"/> class.
        /// </summary>
        public AbilitySet()
        {
            this.strength = new Ability("STR");
            this.dexterity = new Ability("DEX");
            this.constitution = new Ability("CON");
            this.intelligence = new Ability("INT");
            this.wisdom = new Ability("WIS");
            this.charisma = new Ability("CHA");
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
            this.strength = new Ability("STR", s);
            this.dexterity = new Ability("DEX", d);
            this.constitution = new Ability("CON", c);
            this.intelligence = new Ability("INT", i);
            this.wisdom = new Ability("WIS", w);
            this.charisma = new Ability("CHA", ch);
        }

        /// <summary>
        /// Gets or sets strength score
        /// </summary>
        public Ability Str
        {
            get { return this.strength; }
            set { this.strength = value; }
        }

        /// <summary>
        /// Gets or sets dexterity score
        /// </summary>
        public Ability Dex
        {
            get { return this.dexterity; }
            set { this.dexterity = value; }
        }

        /// <summary>
        /// Gets or sets Constitution score
        /// </summary>
        public Ability Con
        {
            get { return this.constitution; }
            set { this.constitution = value; }
        }

        /// <summary>
        /// Gets or sets intelligence score
        /// </summary>
        public Ability Int
        {
            get { return this.intelligence; }
            set { this.intelligence = value; }
        }

        /// <summary>
        /// Gets or sets wisdom score
        /// </summary>
        public Ability Wis
        {
            get { return this.wisdom; }
            set { this.wisdom = value; }
        }

        /// <summary>
        /// Gets or sets charisma score
        /// </summary>
        public Ability Cha
        {
            get { return this.charisma; }
            set { this.charisma = value; }
        }
    }
}