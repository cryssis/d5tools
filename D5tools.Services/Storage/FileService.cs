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
    public class FileService : IFileService
    {
        /// <inheritdoc/>
        public async Task<bool> FileExistsAsync(string key, StorageStrategies location = StorageStrategies.Local) =>
            (await this.GetIfFileExistsAsync(key, location)) != null;

        /// <inheritdoc/>
        public async Task<bool> FileExistsAsync(string key, StorageFolder folder) =>
            (await this.GetIfFileExistsAsync(key, folder)) != null;

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
            StorageFolder folder;
            switch (location)
            {
                case StorageStrategies.Local:
                    folder = ApplicationData.Current.LocalFolder;
                    break;

                case StorageStrategies.Roaming:
                    folder = ApplicationData.Current.RoamingFolder;
                    break;

                case StorageStrategies.Temporary:
                    folder = ApplicationData.Current.TemporaryFolder;
                    break;

                case StorageStrategies.Package:
                    folder = Package.Current.InstalledLocation;
                    break;

                default:
                    throw new NotSupportedException(location.ToString());
            }

            return await folder.CreateFileAsync(key, option);
        }

        private async Task<StorageFile> GetIfFileExistsAsync(string key, StorageStrategies location = StorageStrategies.Local, CreationCollisionOption option = CreationCollisionOption.FailIfExists)
        {
            StorageFile result;

            try
            {
                StorageFolder folder;
                switch (location)
                {
                    case StorageStrategies.Local:
                        folder = ApplicationData.Current.LocalFolder;
                        break;

                    case StorageStrategies.Roaming:
                        folder = ApplicationData.Current.RoamingFolder;
                        break;

                    case StorageStrategies.Temporary:
                        folder = ApplicationData.Current.TemporaryFolder;
                        break;

                    case StorageStrategies.Package:
                        folder = Package.Current.InstalledLocation;
                        break;

                    default:
                        throw new NotSupportedException(location.ToString());
                }

                result = await this.GetIfFileExistsAsync(key, folder, option);
            }
            catch (Exception)
            {
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