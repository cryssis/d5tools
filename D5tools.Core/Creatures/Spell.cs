// <copyright file="Spell.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// A Spell
    /// </summary>
    public class Spell
    {
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spell"/> class.
        /// </summary>
        /// <param name="name">the spell name</param>
        public Spell(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets or sets the spell name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}