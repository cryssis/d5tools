// <copyright file="IDataService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using D5tools.Core.Characters;
    using D5tools.Core.Creatures;
    using D5tools.Core.Encounters;
    using D5tools.Core.Spells;

    /// <summary>
    /// A data service interface
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Gets a collection of creatures
        /// </summary>
        /// <returns>A collection of creatures</returns>
        Task<ObservableCollection<Creature>> GetCreaturesAsync();
    }
}