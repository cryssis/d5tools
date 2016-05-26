// <copyright file="IDatabaseService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using D5tools.Core.Creatures;

    /// <summary>
    /// A Database interface
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Creates a Database if not exists
        /// </summary>
        void CreateDatabaseIfNotExists();

        /// <summary>
        /// Creates a Database
        /// </summary>
        void CreateDatabase();

        /// <summary>
        /// Loads all creatures from the database
        /// </summary>
        /// <returns>A collection of creatures</returns>
        IEnumerable<Creature> LoadAllCreatures();

        /// <summary>
        /// Stores a collection of creatures in the database
        /// </summary>
        /// <param name="creatures">The collection of creatures to be stored</param>
        void SaveAllCreatures(IEnumerable<Creature> creatures);

        /// <summary>
        /// Retrieves a creature from the database
        /// </summary>
        /// <param name="creatureId">The creature Id</param>
        /// <returns>The Creature with the specified Id</returns>
        Creature LoadCreature(int creatureId);

        /// <summary>
        /// Saves a creature in the database
        /// </summary>
        /// <param name="creature">The creature to be saved</param>
        void SaveCreature(Creature creature);

        /// <summary>
        /// Removes a creature from the database
        /// </summary>
        /// <param name="creature">The creature to be removed</param>
        void RemoveCreature(Creature creature);

        /// <summary>
        /// Search for a subset of creatures in the database by name
        /// </summary>
        /// <param name="queryString">the query string</param>
        /// <returns>A collection of creatures that cointains queryString in the name</returns>
        IEnumerable<Creature> SearchForCreature(string queryString);
    }
}