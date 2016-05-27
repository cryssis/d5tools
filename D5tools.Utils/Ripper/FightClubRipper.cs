// <copyright file="FightClubRipper.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Utils.Ripper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using D5tools.Core.Creatures;
    using D5tools.Core.Spells;
    using D5tools.Data.Systems.FightClub;
    using D5tools.Services.Storage;

    /// <summary>
    /// A class which rips creature data from a FightClub XML format file
    /// </summary>
    public class FightClubRipper
    {
        private List<Creature> bestiary;
        private List<Spell> grimoire;
        private StorageService storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="FightClubRipper"/> class.
        /// </summary>
        public FightClubRipper()
        {
            this.bestiary = new List<Creature>();
            this.grimoire = new List<Spell>();
            this.storage = new StorageService();
        }

        /// <summary>
        /// Rips a Fight Club XML format file of creatures to D5tools json format file
        /// </summary>
        /// <param name="filename">The Fight Club XML Creature File</param>
        /// <returns>True if the file was converted</returns>
        public async Task<bool> RipCreaturesFromFile(string filename)
        {
            CreatureTextReader reader = new CreatureTextReader();
            this.bestiary = await reader.LoadFromFile(filename);

            // TODO: Create identifier
            return await this.storage.WriteFileAsync<List<Creature>>("bestiary.json", this.bestiary);
        }

        /// <summary>
        /// Rips a Fight Club XML format file of spells to D5tools json format file
        /// </summary>
        /// <param name="filename">The Fight Club XML Spells File</param>
        /// <returns>True if the file was converted</returns>
        public async Task<bool> RipSpellsFromFile(string filename)
        {
            SpellTextReader reader = new SpellTextReader();
            this.grimoire = await reader.LoadFromFile(filename);

            // TODO: Create identifier
            return await this.storage.WriteFileAsync<List<Spell>>("spells.json", this.grimoire);
        }
    }
}