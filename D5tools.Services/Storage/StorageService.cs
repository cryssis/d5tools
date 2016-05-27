// <copyright file="StorageService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// A class for storing objects in json format.
    /// </summary>
    public class StorageService : FileService
    {
        /// <summary>
        /// Serializes an object and write to file in specified strategy
        /// </summary>
        /// <typeparam name="DataItem">Specified type of object to serialize</typeparam>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="value">Instance of object to be serialized and written</param>
        /// <param name="location">Location storage strategy</param>
        /// <param name="option">Collision option</param>
        /// <returns>True if the file was created</returns>
        public async Task<bool> WriteFileAsync<DataItem>(
            string key,
            DataItem value,
            StorageStrategies location = StorageStrategies.Local,
            Windows.Storage.CreationCollisionOption option = Windows.Storage.CreationCollisionOption.ReplaceExisting)
        {
            var serializedValue = this.Serialize(value);
            return await this.WriteFileAsync(key, serializedValue, location);
        }

        /// <summary>
        /// Reads and deserializes a file into specified type DataItem
        /// </summary>
        /// <typeparam name="DataItem">Specified type into which to deserialize file content</typeparam>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Specified type DataItem</returns>
        public async Task<DataItem> ReadFileAsync<DataItem>(string key, StorageStrategies location = StorageStrategies.Local)
        {
            try
            {
                var content = await this.ReadFileAsync(key, location);
                if (content == null)
                {
                    return default(DataItem);
                }

                var data = this.Deserialize<DataItem>(content);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string Serialize<DataItem>(DataItem item) =>
            JsonConvert.SerializeObject(
                item,
                Formatting.None,
                new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects, TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple });

        private DataItem Deserialize<DataItem>(string json) =>
            JsonConvert.DeserializeObject<DataItem>(json);
    }
}