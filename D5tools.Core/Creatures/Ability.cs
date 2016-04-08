// <copyright file="Ability.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// Creature ability score
    /// </summary>
    public class Ability
    {
        private string name;
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class.
        /// </summary>
        /// <param name="name">The ability name</param>
        public Ability(string name)
        {
            this.name = name;
            this.score = 10;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class.
        /// </summary>
        /// <param name="name">The ability name</param>
        /// <param name="score">The ability score</param>
        public Ability(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        /// <summary>
        /// Gets or sets the Ability Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Ability score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets the Ability modifier
        /// </summary>
        public int Mod
        {
            get
            {
                return (int)System.Math.Floor((decimal)((this.score - 10) / 2));
            }
        }
    }
}