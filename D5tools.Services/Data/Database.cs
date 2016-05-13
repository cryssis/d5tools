// <copyright file="Database.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Data
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using D5tools.Core.Characters;
    using D5tools.Core.Creatures;
    using D5tools.Core.Encounters;
    using D5tools.Core.Spells;

    /// <summary>
    /// A Database class for holding all system information
    /// </summary>
    [DataContract]
    public class Database
    {
        private List<Creature> bestiary;
        private List<Spell> grimoire;
        private List<Character> characters;
        private List<Encounter> encounters;

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            this.bestiary = new List<Creature>();
            this.grimoire = new List<Spell>();
        }

        /// <summary>
        /// Gets or sets the bestiary of creatures
        /// </summary>
        [DataMember]
        public List<Creature> Bestiary
        {
            get { return this.bestiary; }
            set { this.bestiary = value; }
        }

        /// <summary>
        /// Gets or sets the grimoire of spells
        /// </summary>
        [DataMember]
        public List<Spell> Grimoire
        {
            get { return this.grimoire; }
            set { this.grimoire = value; }
        }

        /// <summary>
        /// Gets or sets the characters list
        /// </summary>
        [DataMember]
        public List<Character> Characters
        {
            get { return this.characters; }
            set { this.characters = value; }
        }

        /// <summary>
        /// Gets or sets the encounters list
        /// </summary>
        [DataMember]
        public List<Encounter> Encounters
        {
            get { return this.encounters; }
            set { this.encounters = value; }
        }
    }
}