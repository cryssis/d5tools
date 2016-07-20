// <copyright file="StorageService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Storage
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// A class for storing objects in json format.
    /// </summary>
    public class StorageService : IStorageService
    {
        private IFileService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageService"/> class.
        /// </summary>
        public StorageService()
        {
            this.service = new FileService();
        }

        /// <inheritdoc/>
        public async Task<bool> SaveFileAsync<DataItem>(
            string key,
            DataItem value,
            StorageStrategies location = StorageStrategies.Local,
            Windows.Storage.CreationCollisionOption option = Windows.Storage.CreationCollisionOption.ReplaceExisting)
        {
            var serializedValue = this.Serialize(value);
            return await this.service.WriteFileAsync(key, serializedValue, location);
        }

        /// <inheritdoc/>
        public async Task<DataItem> LoadFileAsync<DataItem>(string key, StorageStrategies location = StorageStrategies.Local)
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

        private string Serialize<DataItem>(DataItem item) =>
            JsonConvert.SerializeObject(
                item,
                Formatting.Indented,
                new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.None, TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple });

        private DataItem Deserialize<DataItem>(string json) =>
            JsonConvert.DeserializeObject<DataItem>(json);
    }
}