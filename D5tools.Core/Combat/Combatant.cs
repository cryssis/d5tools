// <copyright file="Combatant.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Combat
{
    using System;
    using System.Collections.Generic;
    using Characters;
    using Creatures;
    using Dice;
    using Windows.UI;

    /// <summary>
    /// A combatant in an encounter
    /// </summary>
    public class Combatant
    {
        private string alias;
        private string name;
        private int indexLabel;
        private int maxHP;
        private int currentHP;
        private int tempHP;
        private int ac;
        private AbilitySet abilities;
        private List<string> tags;
        private int initMod;
        private int initScore;

        private Creature creature;
        private Character character;

        private bool isHidden;
        private bool isPlayer;
        private string group;

        /// <summary>
        /// Initializes a new instance of the <see cref="Combatant"/> class.
        /// </summary>
        public Combatant()
            : this(new Creature())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Combatant"/> class from a <see cref="Creature"/>
        /// </summary>
        /// <param name="creature">A creature.</param>
        public Combatant(Creature creature)
        {
            this.creature = creature;
            this.alias = this.creature.Name;
            this.name = this.creature.Name;
            this.indexLabel = 0;
            this.maxHP = this.creature.HitPoints;
            this.currentHP = this.creature.HitPoints;
            this.tempHP = 0;
            this.ac = this.creature.ArmorClass;
            this.abilities = this.creature.Abilities;
            this.tags = new List<string>();
            this.initMod = this.creature.InitiativeMod;
            this.initScore = 0;
            this.isHidden = false;
            this.isPlayer = false;
            this.group = this.alias;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Combatant"/> class from a <see cref="Character"/>
        /// </summary>
        /// <param name="character">A Character.</param>
        public Combatant(Character character)
        {
            this.character = character;
            this.alias = this.character.Player;
            this.name = this.character.Name;
            this.indexLabel = 0;
            this.maxHP = this.character.HitPoints;
            this.currentHP = this.character.HitPoints;
            this.tempHP = 0;
            this.ac = this.character.ArmorClass;
            this.abilities = this.character.Abilities;
            this.tags = new List<string>();
            this.initMod = this.character.InitiativeMod;
            this.initScore = 0;
            this.isHidden = false;
            this.isPlayer = true;
            this.group = this.name;
        }

        /// <summary>
        /// Gets or sets combatant alias
        /// </summary>
        public string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }

        /// <summary>
        /// Gets or sets combatant index label for creatures on the same group
        /// </summary>
        public int IndexLabel
        {
            get { return this.indexLabel; }
            set { this.indexLabel = value; }
        }

        /// <summary>
        /// Gets combatant maximun hit points
        /// </summary>
        public int MaxHP
        {
            get { return this.maxHP; }
        }

        /// <summary>
        /// Gets or sets combatant current hit points
        /// </summary>
        public int CurrentHP
        {
            get { return this.currentHP; }
            set { this.currentHP = value; }
        }

        /// <summary>
        /// Gets or sets combatant temporary hit points
        /// </summary>
        public int TempHP
        {
            get { return this.tempHP; }
            set { this.tempHP = value; }
        }

        /// <summary>
        /// Gets or sets combatant armor class
        /// </summary>
        public int ArmorClass
        {
            get { return this.ac; }
            set { this.ac = value; }
        }

        /// <summary>
        /// Gets or sets combatant abilities
        /// </summary>
        public AbilitySet Abilities
        {
            get { return this.abilities; }
            set { this.abilities = value; }
        }

        /// <summary>
        /// Gets combatant strength ability
        /// </summary>
        public Ability Str
        {
            get { return this.abilities.Str; }
        }

        /// <summary>
        /// Gets combatant dexterity ability
        /// </summary>
        public Ability Dex
        {
            get { return this.abilities.Dex; }
        }

        /// <summary>
        /// Gets combatant constitution ability
        /// </summary>
        public Ability Con
        {
            get { return this.abilities.Con; }
        }

        /// <summary>
        /// Gets combatant intelligence ability
        /// </summary>
        public Ability Int
        {
            get { return this.abilities.Int; }
        }

        /// <summary>
        /// Gets combatant wisdom ability
        /// </summary>
        public Ability Wis
        {
            get { return this.abilities.Wis; }
        }

        /// <summary>
        /// Gets combatant charisma ability
        /// </summary>
        public Ability Cha
        {
            get { return this.abilities.Cha; }
        }

        /// <summary>
        /// Gets or sets combatant tags for condition tracking
        /// </summary>
        public List<string> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        /// <summary>
        /// Gets or sets combatant initiative modifier
        /// </summary>
        public int InitiativeMod
        {
            get { return this.initMod; }
            set { this.initMod = value; }
        }

        /// <summary>
        /// Gets or sets combatant initiative score
        /// </summary>
        public int InitiativeScore
        {
            get { return this.initScore; }
            set { this.initScore = value; }
        }

        /// <summary>
        /// Gets or sets Combatant stat block
        /// </summary>
        public Creature Creature
        {
            get { return this.creature; }
            set { this.creature = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether combatant is hidden
        /// </summary>
        public bool IsHidden
        {
            get { return this.isHidden; }
            set { this.isHidden = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether combatant is a player
        /// </summary>
        public bool IsPlayer
        {
            get { return this.isPlayer; }
            set { this.isPlayer = value; }
        }

        /// <summary>
        /// Gets or sets combatant group
        /// </summary>
        public string Group
        {
            get { return this.group; }
            set { this.group = value; }
        }

        /// <summary>
        /// Gets the combatant hit point display string
        /// </summary>
        public string DisplayHP
        {
            get
            {
                if (this.TempHP != 0)
                {
                    return string.Format("{0}+{1}/{2}", this.CurrentHP, this.TempHP, this.MaxHP);
                }
                else
                {
                    return string.Format("{0}/{1}", this.CurrentHP, this.MaxHP);
                }
            }
        }

        /// <summary>
        /// Gets the combatant Hit Point Bar Color
        /// </summary>
        public Color HitPointBarColor
        {
            get
            {
                byte green = (byte)Math.Floor((decimal)(this.CurrentHP / this.MaxHP) * 170);
                byte red = (byte)Math.Floor((decimal)(this.MaxHP - this.CurrentHP) / this.MaxHP * 170);
                return Color.FromArgb(0, red, green, 0);
            }
        }

        /// <summary>
        /// Gets the combatant display name
        /// </summary>
        public string DisplayName
        {
            get
            {
                var name = this.name;

                if (this.isPlayer)
                {
                    return string.Format("{0} ({1})", name, this.alias);
                }
                else if (this.alias != string.Empty && this.alias != name)
                {
                    return this.alias;
                }
                else
                {
                    if (this.group != string.Empty)
                    {
                        return string.Format("{0} {1}", name, this.indexLabel);
                    }
                    else
                    {
                        return name;
                    }
                }
            }
        }

        /// <summary>
        /// Rolls initiative for this combatant
        /// </summary>
        public void RollInitiative()
        {
            DieRoll initRoll = new DieRoll(1, 20, this.initMod);
            this.initScore = initRoll.Roll().Total;
            if (this.initScore < 0)
            {
                this.initScore = 0;
            }
        }

        /// <summary>
        /// Applies damage to the combatant.
        /// </summary>
        /// <remarks>Use negative damage for healing.</remarks>
        /// <param name="damage">the damage amount</param>
        public void ApplyDamage(int damage)
        {
            int healing = -damage;
            int cHP = this.currentHP;
            int tHP = this.tempHP;

            if (damage == 0)
            {
                return;
            }

            if (damage > 0)
            {
                // Damage
                tHP -= damage;
                if (tHP < 0)
                {
                    cHP += tHP;
                    tHP = 0;
                }
            }
            else
            {
                // Healing
                cHP += healing;
                if (cHP > this.maxHP)
                {
                    cHP = this.maxHP;
                }
            }

            this.CurrentHP = cHP;
            this.TempHP = tHP;
        }

        /// <summary>
        /// Applies temporary hit points to the combatant.
        /// </summary>
        /// <param name="thp">amount of temporary hit points to be applied</param>
        public void ApplyTemporaryHP(int thp)
        {
            int cthp = this.tempHP;

            if (thp > cthp)
            {
                cthp = thp;
            }

            this.TempHP = cthp;
        }
    }
}