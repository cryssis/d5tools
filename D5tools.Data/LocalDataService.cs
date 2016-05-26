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
    /// A local data service based on local database for caching
    /// </summary>
    public class LocalDataService : IDataService
    {
        /// <inheritdoc/>
        public async Task<ObservableCollection<Creature>> GetCreaturesAsync()
        {
            ObservableCollection<Creature> bestiary = new ObservableCollection<Creature>();

            // TODO: Progress
            return bestiary;
        }
    }
}