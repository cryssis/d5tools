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
    using Windows.Storage;

    /// <summary>
    /// A class for storing objects in json format.
    /// </summary>
    public class StorageService : IStorageService
    {
        private IStorageService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageService"/> class.
        /// </summary>
        public StorageService()
        {
            this.service = new FileService();
        }

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
            return await this.service.WriteFileAsync(key, serializedValue, location);
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
                var content = await this.service.ReadFileAsync(key, location);
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

        /// <inheritdoc/>
        public async Task<bool> FileExistsAsync(string key, StorageStrategies location = StorageStrategies.Local)
        {
            return await this.service.FileExistsAsync(key, location);
        }

        /// <inheritdoc/>
        public async Task<bool> FileExistsAsync(string key, StorageFolder folder)
        {
            return await this.service.FileExistsAsync(key, folder);
        }

        /// <inheritdoc/>
        public string GetFilePath(string key, StorageStrategies location = StorageStrategies.Local)
        {
            return this.service.GetFilePath(key, location);
        }

        /// <inheritdoc/>
        public string GetFilePath(string key, StorageFolder folder)
        {
            return this.service.GetFilePath(key, folder);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteFileAsync(string key, StorageStrategies location = StorageStrategies.Local)
        {
            return await this.service.DeleteFileAsync(key, location);
        }

        /// <inheritdoc/>
        public async Task<string> ReadFileAsync(string key, StorageStrategies location = StorageStrategies.Local)
        {
            return await this.service.ReadFileAsync(key, location);
        }

        /// <inheritdoc/>
        public async Task<bool> WriteFileAsync(string key, string content, StorageStrategies location = StorageStrategies.Local, CreationCollisionOption option = CreationCollisionOption.OpenIfExists)
        {
            return await this.service.WriteFileAsync(key, content, location, option);
        }

        private string Serialize<DataItem>(DataItem item) =>
            JsonConvert.SerializeObject(
                item,
                Formatting.Indented,
                new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.None, TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple });

        private DataItem Deserialize<DataItem>(string json) =>
            JsonConvert.DeserializeObject<DataItem>(json);
    }
}