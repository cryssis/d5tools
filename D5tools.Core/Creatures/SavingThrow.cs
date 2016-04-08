// <copyright file="SavingThrow.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// Creature saving throw
    /// </summary>
    public class SavingThrow
    {
        private string name;
        private int mod;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingThrow"/> class.
        /// </summary>
        /// <param name="name">The saving thow name</param>
        public SavingThrow(string name)
        {
            this.name = name;
            this.mod = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingThrow"/> class.
        /// </summary>
        /// <param name="name">The saving throw name</param>
        /// <param name="mod">The saving throw modifier</param>
        public SavingThrow(string name, int mod)
        {
            this.name = name;
            this.mod = mod;
        }

        /// <summary>
        /// Gets or sets the Saving Throw Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Saving Throw modifier
        /// </summary>
        public int Mod { get; set; }
    }
}