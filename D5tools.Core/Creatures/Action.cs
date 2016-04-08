// <copyright file="Action.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System.Collections.Generic;

    /// <summary>
    /// Creature Action
    /// </summary>
    public class Action
    {
        private string name;
        private List<string> text;
        private List<Attack> attacks;

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="name">The action name</param>
        /// <param name="desc">The action description</param>
        public Action(string name, string desc)
            : this()
        {
            this.name = name;
            this.text.Add(desc);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        public Action()
        {
            this.text = new List<string>();
            this.attacks = new List<Attack>();
        }

        /// <summary>
        /// Gets or sets the Action name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the Action description
        /// </summary>
        public List<string> Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        /// <summary>
        /// Gets or sets the Attack for the action
        /// </summary>
        public List<Attack> Attacks
        {
            get { return this.attacks; }
            set { this.attacks = value; }
        }
    }
}