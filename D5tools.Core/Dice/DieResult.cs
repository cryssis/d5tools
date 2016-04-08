// <copyright file="DieResult.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Dice
{
    using System.Runtime.Serialization;

    /// <summary>
    /// DieResult represents the result of rolling a die.
    /// </summary>
    [DataContract]
    public class DieResult
    {
        /// <summary>
        /// Gets or sets the number of sides of the die
        /// </summary>
        [DataMember]
        public int Sides { get; set; }

        /// <summary>
        /// Gets or sets the result of rolling the die
        /// </summary>
        [DataMember]
        public int Result { get; set; }
    }
}