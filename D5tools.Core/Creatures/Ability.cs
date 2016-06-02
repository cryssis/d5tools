// <copyright file="Ability.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using Newtonsoft.Json;

    /// <summary>
    /// Creature ability score
    /// </summary>
    public class Ability
    {
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class.
        /// </summary>
        public Ability()
        {
            this.score = 10;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ability"/> class.
        /// </summary>
        /// <param name="score">The ability score</param>
        public Ability(int score)
        {
            this.score = score;
        }

        /// <summary>
        /// Gets or sets the Ability score
        /// </summary>
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        /// <summary>
        /// Gets the Ability modifier
        /// </summary>
        [JsonIgnore]
        public int Mod
        {
            get
            {
                return (int)System.Math.Floor((decimal)((this.score - 10) / 2));
            }
        }
    }
}