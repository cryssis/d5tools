// <copyright file="IDataService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Data
{
    using System.Collections.Generic;
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
        /// Gets or sets the bestiary of creatures;
        /// </summary>
        List<Creature> Bestiary { get; set; }

        /// <summary>
        /// Gets or sets the grimoire of spells
        /// </summary>
        List<Spell> Grimoire { get; set; }

        /// <summary>
        /// Gets or sets the character list.
        /// </summary>
        List<Character> Characters { get; set; }

        /// <summary>
        /// Gets or sets the encounters list
        /// </summary>
        List<Encounter> Encounters { get; set; }
    }
}