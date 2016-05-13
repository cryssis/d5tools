// <copyright file="FileService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Storage
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Windows.Storage;

    /// <summary>
    /// Types of storage strategies
    /// </summary>
    public enum StorageStrategies
    {
        /// <summary>
        /// Local storage
        /// </summary>
        Local,

        /// <summary>
        /// Roaming App storage
        /// </summary>
        Roaming,

        /// <summary>
        /// Temporary storage
        /// </summary>
        Temporary
    }

    /// <summary>
    /// A class for app file storage
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// Returns if a file is found in the specified storage strategy
        /// </summary>
        /// <param name="key">Path of the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Boolean: true if found, false if not found</returns>
        public async Task<bool> FileExistsAsync(string key, StorageStrategies location = StorageStrategies.Local) =>
            (await this.GetIfFileExistsAsync(key, location)) != null;

        /// <summary>
        /// Return if a file is found in the specified folder
        /// </summary>
        /// <param name="key">Name of the file in the folder</param>
        /// <param name="folder">Path of the folder</param>
        /// <returns>Boolean: true if found, false if not found</returns>
        public async Task<bool> FileExistsAsync(string key, StorageFolder folder) =>
            (await this.GetIfFileExistsAsync(key, folder)) != null;

        /// <summary>
        /// Deletes a file in the specified storage strategy
        /// </summary>
        /// <param name="key">Path of the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Boolean: true if the file was deleted, false if not was deleted</returns>
        public async Task<bool> DeleteFileAsync(string key, StorageStrategies location = StorageStrategies.Local)
        {
            var file = await this.GetIfFileExistsAsync(key, location);
            if (file != null)
            {
                await file.DeleteAsync();
            }

            return !(await this.FileExistsAsync(key, location));
        }

        /// <summary>
        /// Reads and deserializes a file into specified type T
        /// </summary>
        /// <typeparam name="T">Specified type into which to deserialize file content</typeparam>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Specified type T</returns>
        public async Task<T> ReadFileAsync<T>(string key, StorageStrategies location = StorageStrategies.Local)
        {
            try
            {
                var file = await this.GetIfFileExistsAsync(key, location);
                if (file == null)
                {
                    return default(T);
                }

                var content = await FileIO.ReadTextAsync(file);
                var result = this.Deserialize<T>(content);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Serializes an object and write to file in specified storage strategy
        /// </summary>
        /// <typeparam name="T">Specified type of object to serialize</typeparam>
        /// <param name="key">Path to the file in storage</param>
        /// <param name="value">Instance of object to be serialized and written</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>Boolean: true if the file was written, false if not was written</returns>
        public async Task<bool> WriteFileAsync<T>(string key, T value, StorageStrategies location = StorageStrategies.Local)
        {
            var file = await this.CreateFileAsync(key, location, CreationCollisionOption.ReplaceExisting);
            var content = this.Serialize<T>(value);
            await FileIO.WriteTextAsync(file, content);
            return await this.FileExistsAsync(key, location);
        }

        private async Task<StorageFile> CreateFileAsync(string key, StorageStrategies location = StorageStrategies.Local, CreationCollisionOption option = CreationCollisionOption.OpenIfExists)
        {
            switch (location)
            {
                case StorageStrategies.Local:
                    return await ApplicationData.Current.LocalFolder.CreateFileAsync(key, option);

                case StorageStrategies.Roaming:
                    return await ApplicationData.Current.RoamingFolder.CreateFileAsync(key, option);

                case StorageStrategies.Temporary:
                    return await ApplicationData.Current.TemporaryFolder.CreateFileAsync(key, option);

                default:
                    throw new NotSupportedException(location.ToString());
            }
        }

        private async Task<StorageFile> GetIfFileExistsAsync(string key, StorageStrategies location = StorageStrategies.Local, CreationCollisionOption option = CreationCollisionOption.FailIfExists)
        {
            StorageFile result;
            try
            {
                switch (location)
                {
                    case StorageStrategies.Local:
                        result = await ApplicationData.Current.LocalFolder.GetFileAsync(key);
                        break;

                    case StorageStrategies.Roaming:
                        result = await ApplicationData.Current.RoamingFolder.GetFileAsync(key);
                        break;

                    case StorageStrategies.Temporary:
                        result = await ApplicationData.Current.TemporaryFolder.GetFileAsync(key);
                        break;

                    default:
                        throw new NotSupportedException(location.ToString());
                }
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("GetIfFileExistsAsync:FileNotFoundException");
                return null;
            }

            return result;
        }

        private async Task<StorageFile> GetIfFileExistsAsync(string key, StorageFolder folder, CreationCollisionOption option = CreationCollisionOption.FailIfExists)
        {
            StorageFile result;
            try
            {
                result = await folder.GetFileAsync(key);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("GetIfFileExistsAsync:FileNotFoundException");
                return null;
            }

            return result;
        }

        private string Serialize<T>(T item) =>
            JsonConvert.SerializeObject(
                item,
                Formatting.None,
                new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects, TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple });

        private T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}