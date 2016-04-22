// <copyright file="Character.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Characters
{
    using System.Collections.Generic;
    using Creatures;
    using Rules;

    /// <summary>
    /// A character.
    /// </summary>
    public class Character : CreatureBase
    {
        private string playerName;

        private string race;
        private string subrace;
        private string classes;

        private int characterLevel;
        private int xp;
        private int proficiency;

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        public Character()
            : base()
        {
            this.playerName = string.Empty;
            this.race = string.Empty;
            this.subrace = string.Empty;
            this.classes = string.Empty;
            this.characterLevel = 1;
            this.xp = 0;
            this.proficiency = CATable.ProfbyLevel(this.characterLevel);
        }

        /// <summary>
        /// Gets or sets character player
        /// </summary>
        public string Player
        {
            get { return this.playerName; }
            set { this.playerName = value; }
        }

        /// <summary>
        /// Gets or sets character race
        /// </summary>
        public string Race
        {
            get { return this.race; }
            set { this.race = value; }
        }

        /// <summary>
        /// Gets or sets character subrace
        /// </summary>
        public string Subrace
        {
            get { return this.subrace; }
            set { this.subrace = value; }
        }

        /// <summary>
        /// Gets or sets character hit dice
        /// </summary>
        public string Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        /// <summary>
        /// Gets or sets character level
        /// </summary>
        public int CharacterLevel
        {
            get
            {
                return this.characterLevel;
            }

            set
            {
                this.characterLevel = value;
                this.proficiency = CATable.ProfbyLevel(value);
            }
        }

        /// <summary>
        /// Gets or sets character xp
        /// </summary>
        public int XP
        {
            get { return this.xp; }
            set { this.xp = value; }
        }

        /// <summary>
        /// Gets character Proficiency
        /// </summary>
        public int Proficiency
        {
            get { return this.proficiency; }
        }
    }
}