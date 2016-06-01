// <copyright file="Skill.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// Creature skill
    /// </summary>
    public class Skill
    {
        private string name;
        private int mod;

        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        public Skill()
        {
            this.name = string.Empty;
            this.mod = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        /// <param name="name">The skill name</param>
        public Skill(string name)
        {
            this.name = name;
            this.mod = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        /// <param name="name">The skill name</param>
        /// <param name="mod">The skill modifier</param>
        public Skill(string name, int mod)
        {
            this.name = name;
            this.mod = mod;
        }

        /// <summary>
        /// Gets or sets the Skill Name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the Skill modifier
        /// </summary>
        public int Mod
        {
            get { return this.mod; }
            set { this.mod = value; }
        }
    }
}