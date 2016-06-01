// <copyright file="IStorageService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Storage
{
    using System.Threading.Tasks;
    using Windows.Storage;

    /// <summary>
    /// A Storage service interface
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Reads and deserializes a file into specified type DataItem
        /// </summary>
        /// <typeparam name="DataItem">Specified type into which to deserialize file content</typeparam>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Specified type DataItem</returns>
        Task<DataItem> LoadFileAsync<DataItem>(string key, StorageStrategies location = StorageStrategies.Local);

        /// <summary>
        /// Serializes an object and write to file in specified strategy
        /// </summary>
        /// <typeparam name="DataItem">Specified type of object to serialize</typeparam>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="value">Instance of object to be serialized and written</param>
        /// <param name="location">Location storage strategy</param>
        /// <param name="option">Collision option</param>
        /// <returns>True if the file was created</returns>
        Task<bool> SaveFileAsync<DataItem>(string key, DataItem value, StorageStrategies location = StorageStrategies.Local, CreationCollisionOption option = CreationCollisionOption.ReplaceExisting);
    }
}