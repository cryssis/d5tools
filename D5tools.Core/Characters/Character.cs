// <copyright file="Character.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Characters
{
    using System.Collections.Generic;
    using Creatures;
    using Rules;

    /// <summary>
    /// A character.
    /// </summary>
    public class Character
    {
        private string name;
        private string playerName;
        private string race;
        private string subrace;
        private string classes;
        private int characterLevel;
        private int xp;
        private string alignment;
        private int ac;
        private string acType;
        private int hp;
        private string hd;
        private string speed;
        private AbilitySet abilities;
        private SavingThrowSet savingThrows;
        private List<Skill> skills;
        private string senses;
        private string languages;
        private List<Trait> traits;
        private List<string> spells;
        private int initMod;
        private int passivePerception;
        private int proficiency;

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        public Character()
        {
            this.name = string.Empty;
            this.playerName = string.Empty;
            this.race = string.Empty;
            this.subrace = string.Empty;
            this.classes = string.Empty;
            this.characterLevel = 1;
            this.xp = 0;
            this.alignment = string.Empty;
            this.ac = 10;
            this.acType = string.Empty;
            this.hp = 1;
            this.hd = string.Empty;
            this.speed = string.Empty;
            this.abilities = new AbilitySet();
            this.savingThrows = new SavingThrowSet();
            this.skills = new List<Skill>();
            this.senses = string.Empty;
            this.languages = string.Empty;
            this.traits = new List<Trait>();
            this.spells = new List<string>();
            this.initMod = this.Dex.Mod;
            this.proficiency = CATable.ProfbyLevel(this.characterLevel);
        }

        /// <summary>
        /// Gets or sets character name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets character player
        /// </summary>
        public string Player
        {
            get { return this.playerName; }
            set { this.playerName = value; }
        }

        /// <summary>
        /// Gets or sets character race
        /// </summary>
        public string Race
        {
            get { return this.race; }
            set { this.race = value; }
        }

        /// <summary>
        /// Gets or sets character subrace
        /// </summary>
        public string Subrace
        {
            get { return this.subrace; }
            set { this.subrace = value; }
        }

        /// <summary>
        /// Gets or sets character hit dice
        /// </summary>
        public string Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        /// <summary>
        /// Gets or sets character level
        /// </summary>
        public int CharacterLevel
        {
            get
            {
                return this.characterLevel;
            }

            set
            {
                this.characterLevel = value;
                this.proficiency = CATable.ProfbyLevel(value);
            }
        }

        /// <summary>
        /// Gets or sets character xp
        /// </summary>
        public int XP
        {
            get { return this.xp; }
            set { this.xp = value; }
        }

        /// <summary>
        /// Gets or sets creature aligment
        /// </summary>
        public string Alignment
        {
            get { return this.alignment; }
            set { this.alignment = value; }
        }

        /// <summary>
        /// Gets or sets character armor class
        /// </summary>
        public int ArmorClass
        {
            get { return this.ac; }
            set { this.ac = value; }
        }

        /// <summary>
        /// Gets or sets character armor class type
        /// </summary>
        public string ArmorClassType
        {
            get { return this.acType; }
            set { this.acType = value; }
        }

        /// <summary>
        /// Gets or sets character hit points
        /// </summary>
        public int HitPoints
        {
            get { return this.hp; }
            set { this.hp = value; }
        }

        /// <summary>
        /// Gets or sets character hit dice
        /// </summary>
        public string HitDice
        {
            get { return this.hd; }
            set { this.hd = value; }
        }

        /// <summary>
        ///  Gets or sets character speed
        /// </summary>
        public string Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        /// <summary>
        /// Gets or sets character abilities
        /// </summary>
        public AbilitySet Abilities
        {
            get { return this.abilities; }
            set { this.abilities = value; }
        }

        /// <summary>
        /// Gets character strength ability
        /// </summary>
        public Ability Str
        {
            get { return this.abilities.Str; }
        }

        /// <summary>
        /// Gets character dexterity ability
        /// </summary>
        public Ability Dex
        {
            get { return this.abilities.Dex; }
        }

        /// <summary>
        /// Gets character constitution ability
        /// </summary>
        public Ability Con
        {
            get { return this.abilities.Con; }
        }

        /// <summary>
        /// Gets character intelligence ability
        /// </summary>
        public Ability Int
        {
            get { return this.abilities.Int; }
        }

        /// <summary>
        /// Gets character wisdom ability
        /// </summary>
        public Ability Wis
        {
            get { return this.abilities.Wis; }
        }

        /// <summary>
        /// Gets character charisma ability
        /// </summary>
        public Ability Cha
        {
            get { return this.abilities.Cha; }
        }

        /// <summary>
        /// Gets character Proficiency
        /// </summary>
        public int Proficiency
        {
            get { return this.proficiency; }
        }

        /// <summary>
        /// Gets or sets character saving throws
        /// </summary>
        public SavingThrowSet SavingThrows
        {
            get { return this.savingThrows; }
            set { this.savingThrows = value; }
        }

        /// <summary>
        /// Gets or sets character skills
        /// </summary>
        public List<Skill> Skills
        {
            get { return this.skills; }
            set { this.skills = value; }
        }

        /// <summary>
        /// Gets or sets character senses
        /// </summary>
        public string Senses
        {
            get { return this.senses; }
            set { this.senses = value; }
        }

        /// <summary>
        /// Gets or sets character languages
        /// </summary>
        public string Languages
        {
            get { return this.languages; }
            set { this.languages = value; }
        }

        /// <summary>
        /// Gets or sets the character traits
        /// </summary>
        public List<Trait> Traits
        {
            get { return this.traits; }
            set { this.traits = value; }
        }

        /// <summary>
        /// Gets or sets the creature spells
        /// </summary>
        public List<string> Spells
        {
            get { return this.spells; }
            set { this.spells = value; }
        }

        /// <summary>
        /// Gets or sets the character initiative modifier
        /// </summary>
        public int InitiativeMod
        {
            get { return this.initMod; }
            set { this.initMod = value; }
        }

        /// <summary>
        /// Gets or sets the creature passive perception value
        /// </summary>
        public int PassivePerception
        {
            get { return this.passivePerception; }
            set { this.passivePerception = value; }
        }
    }
}