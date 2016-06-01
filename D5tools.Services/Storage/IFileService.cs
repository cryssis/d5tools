// <copyright file="IFileService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Storage
{
    using System.Threading.Tasks;
    using Windows.Storage;

    /// <summary>
    /// Defines a File Service Interface
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Returns if a file is found in the specified storage strategy
        /// </summary>
        /// <param name="key">Path of the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Boolean: true if found, false if not found</returns>
        Task<bool> FileExistsAsync(string key, StorageStrategies location = StorageStrategies.Local);

        /// <summary>
        /// Return if a file is found in the specified folder
        /// </summary>
        /// <param name="key">Name of the file in the folder</param>
        /// <param name="folder">The storage folder</param>
        /// <returns>Boolean: true if found, false if not found</returns>
        Task<bool> FileExistsAsync(string key, StorageFolder folder);

        /// <summary>
        /// Deletes a file in the specified storage strategy
        /// </summary>
        /// <param name="key">Path of the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Boolean: true if the file was deleted, false if not was deleted</returns>
        Task<bool> DeleteFileAsync(string key, StorageStrategies location = StorageStrategies.Local);

        /// <summary>
        /// Reads a file from specified storage strategy
        /// </summary>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>The text content of the file</returns>
        Task<string> ReadFileAsync(string key, StorageStrategies location = StorageStrategies.Local);

        /// <summary>
        /// Write to file in specified storage strategy
        /// </summary>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="content">Text content to be written</param>
        /// <param name="location">Location storage strategy</param>
        /// <param name="option">File Collision option</param>
        /// <returns>Boolean: true if the file was written, false if not was written</returns>
        Task<bool> WriteFileAsync(string key, string content, StorageStrategies location = StorageStrategies.Local, CreationCollisionOption option = CreationCollisionOption.OpenIfExists);
    }
}