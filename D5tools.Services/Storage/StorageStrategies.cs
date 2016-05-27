// <copyright file="StorageStrategies.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Services.Storage
{
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
        Temporary,

        /// <summary>
        /// Shipped with the package
        /// </summary>
        Package
    }
}