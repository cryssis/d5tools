// <copyright file="DataService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Data
{
    using System.Collections.Generic;
    using Core.Characters;
    using Core.Encounters;
    using D5tools.Core.Creatures;
    using D5tools.Core.Spells;

    /// <summary>
    /// A Data Service for loading and saving data
    /// </summary>
    public class DataService : IDataService
    {
        private Database data;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        public DataService()
        {
            this.data = new Database();
        }

        /// <summary>
        /// Gets or sets the bestiary of creatures
        /// </summary>
        public List<Creature> Bestiary
        {
            get { return this.data.Bestiary; }
            set { this.data.Bestiary = value; }
        }

        /// <summary>
        /// Gets or sets the characters list
        /// </summary>
        public List<Character> Characters
        {
            get { return this.data.Characters; }
            set { this.data.Characters = value; }
        }

        /// <summary>
        /// Gets or sets the encounters list
        /// </summary>
        public List<Encounter> Encounters
        {
            get { return this.data.Encounters; }
            set { this.data.Encounters = value; }
        }

        /// <summary>
        /// Gets or sets the grimoire of spells
        /// </summary>
        public List<Spell> Grimoire
        {
            get { return this.data.Grimoire; }
            set { this.data.Grimoire = value; }
        }
    }
}