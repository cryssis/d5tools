// <copyright file="AttackType.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// The types of attacks
    /// </summary>
    public enum AttackType
    {
        /// <summary>
        /// Melee Weapon Attack
        /// </summary>
        MeleeWeapon,

        /// <summary>
        /// Ranged Weapon Attack
        /// </summary>
        RangedWeapon,

        /// <summary>
        /// Melee or Ranged Weapon Attack
        /// </summary>
        MeleeOrRangedWeapon,

        /// <summary>
        /// Ranged Spell Attack
        /// </summary>
        RangedSpell
    }
}