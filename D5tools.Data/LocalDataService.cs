// <copyright file="LocalDataService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using D5tools.Core.Creatures;
    using D5tools.Services.Storage;

    /// <summary>
    /// A local data service based on local data for caching
    /// </summary>
    public class LocalDataService : IDataService
    {
        private const string MonsterFile = "data/bestiary.json";
        private StorageService storage;
        private List<Creature> bestiary;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalDataService"/> class.
        /// </summary>
        public LocalDataService()
        {
            this.storage = new StorageService();
        }

        /// <inheritdoc/>
        public async Task<ObservableCollection<Creature>> GetCreaturesAsync()
        {
            if (this.bestiary == null)
            {
                // TODO: Progress start
                this.bestiary = await this.storage.ReadFileAsync<List<Creature>>(MonsterFile);

                // TODO: Progress end
            }

            return new ObservableCollection<Creature>(this.bestiary);
        }
    }
}