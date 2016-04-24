// <copyright file="DifficultyLevel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// Creature Difficulty levels
    /// </summary>
    public enum DifficultyLevel
    {
        /// <summary>
        /// Eight or more of this creatures is a medium challenge
        /// </summary>
        Trivial,

        /// <summary>
        /// Four of these is a medium challenge
        /// </summary>
        Group,

        /// <summary>
        /// Two of these is a medium challenge
        /// </summary>
        Pair,

        /// <summary>
        /// One of these is an easy challenge
        /// </summary>
        Easy,

        /// <summary>
        /// One of these is a medium challenge
        /// </summary>
        Medium,

        /// <summary>
        /// One of these is a hard challenge
        /// </summary>
        Hard,

        /// <summary>
        /// One of these is a deadly challenge
        /// </summary>
        Deadly
    }
}
