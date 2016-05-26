// <copyright file="SQLiteDatabaseService.cs" company="Roberto Sobreviela">
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
    using D5tools.Services.Storage;
    using SQLite.Net;

    /// <summary>
    /// A database service implementation with SQLite
    /// </summary>
    public class SQLiteDatabaseService : IDatabaseService
    {
        private const string DbName = "db.sqlite";
        private IStorageService storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteDatabaseService"/> class.
        /// </summary>
        /// <param name="storage">The storage service where the database is located.</param>
        public SQLiteDatabaseService(IStorageService storage)
        {
            this.storage = storage;
        }

        private SQLiteConnection DbConnection
        {
            get
            {
                return new SQLiteConnection(
                    new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                    this.storage.GetFilePath(DbName, StorageStrategies.Local));
            }
        }

        /// <inheritdoc/>
        public void CreateDatabaseIfNotExists()
        {
            if (!this.storage.FileExistsAsync(DbName).Result)
            {
                this.CreateDatabase();
            }
        }

        /// <inheritdoc/>
        public void CreateDatabase()
        {
            using (var db = this.DbConnection)
            {
                db.CreateTable<Creature>();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Creature> LoadAllCreatures()
        {
            List<Creature> creatures;
            using (var db = this.DbConnection)
            {
                creatures = db.Table<Creature>().ToList();
            }

            return creatures.OrderBy(c => c.Name);
        }

        /// <inheritdoc/>
        public void SaveAllCreatures(IEnumerable<Creature> creatures)
        {
            int retries = 0;
            while (retries < 15)
            {
                try
                {
                    using (var db = this.DbConnection)
                    {
                        db.DeleteAll<Creature>();
                        db.InsertAll(creatures);
                    }

                    break;
                }
                catch (Exception)
                {
                }

                Task.Delay(110).Wait();
                retries++;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Creature> SearchForCreature(string queryString)
        {
            IEnumerable<Creature> results;
            using (var db = this.DbConnection)
            {
                results = db.Table<Creature>().Where(creature => creature.Name.Contains(queryString)).ToList();
            }

            return results;
        }

        /// <inheritdoc/>
        public Creature LoadCreature(int creatureId)
        {
            Creature creature = new Creature();
            using (var db = this.DbConnection)
            {
                creature = db.Find<Creature>(c => c.Id == creatureId);
            }

            return creature ?? new Creature();
        }

        /// <inheritdoc/>
        public void SaveCreature(Creature creature)
        {
            using (var db = this.DbConnection)
            {
                db.Delete(creature);
                db.Insert(creature);
            }
        }

        /// <inheritdoc/>
        public void RemoveCreature(Creature creature)
        {
            using (var db = this.DbConnection)
            {
                db.Delete(creature);
            }
        }
    }
}