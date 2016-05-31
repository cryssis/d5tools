// <copyright file="CreatureBase.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A Base Creature
    /// </summary>
    public abstract class CreatureBase
    {
        /// <summary>
        /// Creatures name
        /// </summary>
        private int id;

        private string name;

        private string size;
        private string type;
        private string subtype;

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
        private List<Action> actions;
        private List<Action> reactions;

        private List<string> spells;

        private int initMod;
        private int passivePerception;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatureBase"/> class.
        /// </summary>
        public CreatureBase()
        {
            this.id = 0;
            this.name = string.Empty;
            this.size = string.Empty;
            this.type = string.Empty;
            this.subtype = string.Empty;
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
            this.actions = new List<Action>();
            this.reactions = new List<Action>();
            this.spells = new List<string>();
            this.initMod = this.abilities.Dex.Mod;
            this.passivePerception = 10 + this.abilities.Wis.Mod;
        }

        /// <summary>
        /// Gets or sets creature id
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets creature name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets creature size
        /// </summary>
        public string Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        /// <summary>
        /// Gets or sets creature type
        /// </summary>
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets creature subtype
        /// </summary>
        public string Subtype
        {
            get { return this.subtype; }
            set { this.subtype = value; }
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
        /// Gets or sets creature armor class
        /// </summary>
        public int ArmorClass
        {
            get { return this.ac; }
            set { this.ac = value; }
        }

        /// <summary>
        /// Gets or sets creature armor class type
        /// </summary>
        public string ArmorClassType
        {
            get { return this.acType; }
            set { this.acType = value; }
        }

        /// <summary>
        /// Gets or sets creature hit points
        /// </summary>
        public int HitPoints
        {
            get { return this.hp; }
            set { this.hp = value; }
        }

        /// <summary>
        /// Gets or sets creature hit dice
        /// </summary>
        public string HitDice
        {
            get { return this.hd; }
            set { this.hd = value; }
        }

        /// <summary>
        ///  Gets or sets creature speed
        /// </summary>
        public string Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        /// <summary>
        /// Gets or sets creature abilities
        /// </summary>
        public AbilitySet Abilities
        {
            get { return this.abilities; }
            set { this.abilities = value; }
        }

        /// <summary>
        /// Gets creature Strength
        /// </summary>
        [JsonIgnore]
        public Ability Str
        {
            get { return this.abilities.Str; }
        }

        /// <summary>
        /// Gets creature Dexterity
        /// </summary>
        [JsonIgnore]
        public Ability Dex
        {
            get { return this.abilities.Dex; }
        }

        /// <summary>
        /// Gets creature Constitution
        /// </summary>
        [JsonIgnore]
        public Ability Con
        {
            get { return this.abilities.Con; }
        }

        /// <summary>
        /// Gets creature Intelligence
        /// </summary>
        [JsonIgnore]
        public Ability Int
        {
            get { return this.abilities.Int; }
        }

        /// <summary>
        /// Gets creature Wisdom
        /// </summary>
        [JsonIgnore]
        public Ability Wis
        {
            get { return this.abilities.Wis; }
        }

        /// <summary>
        /// Gets creature Charisma
        /// </summary>
        [JsonIgnore]
        public Ability Cha
        {
            get { return this.abilities.Cha; }
        }

        /// <summary>
        /// Gets or sets creature saving throws
        /// </summary>
        public SavingThrowSet SavingThrows
        {
            get { return this.savingThrows; }
            set { this.savingThrows = value; }
        }

        /// <summary>
        /// Gets or sets creature skills
        /// </summary>
        public List<Skill> Skills
        {
            get { return this.skills; }
            set { this.skills = value; }
        }

        /// <summary>
        /// Gets or sets creature senses
        /// </summary>
        public string Senses
        {
            get { return this.senses; }
            set { this.senses = value; }
        }

        /// <summary>
        /// Gets or sets creature languages
        /// </summary>
        public string Languages
        {
            get { return this.languages; }
            set { this.languages = value; }
        }

        /// <summary>
        /// Gets or sets the creature traits
        /// </summary>
        public List<Trait> Traits
        {
            get { return this.traits; }
            set { this.traits = value; }
        }

        /// <summary>
        /// Gets or sets the creature actions
        /// </summary>
        public List<Action> Actions
        {
            get { return this.actions; }
            set { this.actions = value; }
        }

        /// <summary>
        /// Gets or sets the creature reactions
        /// </summary>
        public List<Action> Reactions
        {
            get { return this.reactions; }
            set { this.reactions = value; }
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
        /// Gets or sets the creature initiative modifier
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