﻿// <copyright file="DamageType.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    /// <summary>
    /// Types of Damage
    /// </summary>
    public enum DamageType
    {
        /// <summary>
        /// The corrosive spray of a black dragon’s breath and the dissolving enzymes
        /// secreted by a black pudding deal acid damage.
        /// </summary>
        Acid,

        /// <summary>
        /// Blunt force attacks — hammers, falling, constriction, and the like —
        /// deal bludgeoning damage
        /// </summary>
        Bludgeoning,

        /// <summary>
        /// The infernal chill radiating from an ice devil’s spear and the frigid blast
        /// of a white dragon’s breath deal cold damage.
        /// </summary>
        Cold,

        /// <summary>
        /// Red dragons breathe fire, and many spells conjure flames to deal fire damage.
        /// </summary>
        Fire,

        /// <summary>
        /// Force is pure magical energy focused into a damaging form.
        /// Most effects that deal force damage are spells, including magic missile and
        /// spiritual weapon.
        /// </summary>
        Force,

        /// <summary>
        /// A lightning bolt spell and a blue dragon’s breath deal lightning damage.
        /// </summary>
        Lightning,

        /// <summary>
        /// Necrotic damage, dealt by certain undead and a spell such as chill touch,
        /// withers matter and even the soul.
        /// </summary>
        Necrotic,

        /// <summary>
        /// Puncturing and impaling attacks, including spears and monsters’ bites, deal
        /// piercing damage.
        /// </summary>
        Piercing,

        /// <summary>
        /// Venomous stings and the toxic gas of a green dragon’s breath deal poison damage.
        /// </summary>
        Poison,

        /// <summary>
        /// Mental abilities such as a mind flayer’s psionic blast deal psychic damage.
        /// </summary>
        Psychic,

        /// <summary>
        /// Radiant damage, dealt by a cleric’s flame strike spell or an angel’s smiting
        /// weapon, sears the flesh like fire and overloads the spirit with power.
        /// </summary>
        Radiant,

        /// <summary>
        /// Swords, axes, and monsters’ claws deal slashing damage.
        /// </summary>
        Slashing,

        /// <summary>
        /// A concussive burst of sound, such as the effect of the thunderwave spell, deals thunder damage.
        /// </summary>
        Thunder
    }
}