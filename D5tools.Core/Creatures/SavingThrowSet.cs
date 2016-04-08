// <copyright file="SavingThrowSet.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// Creature Saving Throws Set
    /// </summary>
    public class SavingThrowSet
    {
        private SavingThrow strength;
        private SavingThrow dexterity;
        private SavingThrow constitution;
        private SavingThrow intelligence;
        private SavingThrow wisdom;
        private SavingThrow charisma;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingThrowSet"/> class.
        /// </summary>
        public SavingThrowSet()
        {
            this.strength = new SavingThrow("STR");
            this.dexterity = new SavingThrow("DEX");
            this.constitution = new SavingThrow("CON");
            this.intelligence = new SavingThrow("INT");
            this.wisdom = new SavingThrow("WIS");
            this.charisma = new SavingThrow("CHA");
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
            this.strength = new SavingThrow("STR save", s);
            this.dexterity = new SavingThrow("DEX save", d);
            this.constitution = new SavingThrow("CON save", c);
            this.intelligence = new SavingThrow("INT save", i);
            this.wisdom = new SavingThrow("WIS save", w);
            this.charisma = new SavingThrow("CHA save", ch);
        }

        /// <summary>
        /// Gets or sets strength saving throw modifier
        /// </summary>
        public SavingThrow Str
        {
            get
            {
                return this.strength;
            }

            set
            {
                this.strength = value;
            }
        }

        /// <summary>
        /// Gets or sets dexterity saving throw modifier
        /// </summary>
        public SavingThrow Dex
        {
            get
            {
                return this.dexterity;
            }

            set
            {
                this.dexterity = value;
            }
        }

        /// <summary>
        /// Gets or sets Constitution saving throw modifier
        /// </summary>
        public SavingThrow Con
        {
            get
            {
                return this.constitution;
            }

            set
            {
                this.constitution = value;
            }
        }

        /// <summary>
        /// Gets or sets intelligence saving throw modifier
        /// </summary>
        public SavingThrow Int
        {
            get
            {
                return this.intelligence;
            }

            set
            {
                this.intelligence = value;
            }
        }

        /// <summary>
        /// Gets or sets wisdom saving throw modifier
        /// </summary>
        public SavingThrow Wis
        {
            get
            {
                return this.wisdom;
            }

            set
            {
                this.wisdom = value;
            }
        }

        /// <summary>
        /// Gets or sets charisma saving throw Modifier
        /// </summary>
        public SavingThrow Cha
        {
            get
            {
                return this.charisma;
            }

            set
            {
                this.charisma = value;
            }
        }
    }
}