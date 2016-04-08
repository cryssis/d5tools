// <copyright file="Trait.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System.Collections.Generic;

    /// <summary>
    /// Creature trait
    /// </summary>
    public class Trait
    {
        private string name;
        private List<string> text;
        private Attack attack;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trait"/> class.
        /// </summary>
        /// <param name="name">The trait name</param>
        /// <param name="desc">The trait description</param>
        public Trait(string name, string desc)
            : this()
        {
            this.name = name;
            this.text.Add(desc);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trait"/> class.
        /// </summary>
        public Trait()
        {
            this.text = new List<string>();
        }

        /// <summary>
        /// Gets or sets the Trait name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the Trait description
        /// </summary>
        public List<string> Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        /// <summary>
        /// Gets or sets the attack for the action
        /// </summary>
        public Attack Attack
        {
            get { return this.attack; }
            set { this.attack = value; }
        }
    }
}