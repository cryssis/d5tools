// <copyright file="IDataItemTextReader.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Data.Systems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using D5tools.Core.Creatures;
    using D5tools.Services.Storage;
    using Windows.Storage;

    /// <summary>
    /// A Text file reader for a colletion of data items
    /// </summary>
    /// <typeparam name="DataItem">The data item type</typeparam>
    public interface IDataItemTextReader<DataItem>
    {
        /// <summary>
        /// Gets a colletion of data items stored on a file.
        /// </summary>
        /// <param name="filename">the file name</param>
        /// <param name="folder">the storage folder</param>
        /// <returns>A list of data items</returns>
        Task<List<DataItem>> LoadFromFile(string filename, StorageFolder folder);

        /// <summary>
        /// Gets a colletion of data items stored on a file.
        /// </summary>
        /// <param name="filename">the file name</param>
        /// <param name="location">Location storage strategy</param>
        /// <returns>A list of data items</returns>
        Task<List<DataItem>> LoadFromFile(string filename, StorageStrategies location = StorageStrategies.Local);
    }
}