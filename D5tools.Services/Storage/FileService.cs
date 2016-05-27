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
    using Windows.ApplicationModel;
    using Windows.Storage;

    /// <summary>
    /// A class for app file storage
    /// </summary>
    public class FileService : IStorageService
    {
        /// <inheritdoc/>
        public async Task<bool> FileExistsAsync(string key, StorageStrategies location = StorageStrategies.Local) =>
            (await this.GetIfFileExistsAsync(key, location)) != null;

        /// <inheritdoc/>
        public async Task<bool> FileExistsAsync(string key, StorageFolder folder) =>
            (await this.GetIfFileExistsAsync(key, folder)) != null;

        /// <inheritdoc/>
        public string GetFilePath(string key, StorageStrategies location = StorageStrategies.Local)
        {
            switch (location)
            {
                case StorageStrategies.Local:
                    return Path.Combine(ApplicationData.Current.LocalFolder.Path, key);

                case StorageStrategies.Roaming:
                    return Path.Combine(ApplicationData.Current.RoamingFolder.Path, key);

                case StorageStrategies.Temporary:
                    return Path.Combine(ApplicationData.Current.TemporaryFolder.Path, key);

                case StorageStrategies.Package:
                    return Path.Combine(Package.Current.InstalledLocation.Path, key);

                default:
                    throw new NotSupportedException(location.ToString());
            }
        }

        /// <inheritdoc/>
        public string GetFilePath(string key, StorageFolder folder)
        {
            return Path.Combine(folder.Path, key);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteFileAsync(string key, StorageStrategies location = StorageStrategies.Local)
        {
            var file = await this.GetIfFileExistsAsync(key, location);
            if (file != null)
            {
                await file.DeleteAsync();
            }

            return !(await this.FileExistsAsync(key, location));
        }

        /// <inheritdoc/>
        public async Task<string> ReadFileAsync(string key, StorageStrategies location = StorageStrategies.Local)
        {
            try
            {
                var file = await this.GetIfFileExistsAsync(key, location);
                if (file == null)
                {
                    return default(string);
                }

                var content = await FileIO.ReadTextAsync(file);
                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> WriteFileAsync(string key, string content, StorageStrategies location = StorageStrategies.Local, CreationCollisionOption option = CreationCollisionOption.OpenIfExists)
        {
            var file = await this.CreateFileAsync(key, location, CreationCollisionOption.ReplaceExisting);
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

                case StorageStrategies.Package:
                    return await Package.Current.InstalledLocation.CreateFileAsync(key, option);

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

                    case StorageStrategies.Package:
                        result = await Package.Current.InstalledLocation.GetFileAsync(key);
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
    }
}