// <copyright file="Creature.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System.Collections.Generic;
    using D5tools.Core.Rules;

    /// <summary>
    /// A Creature StatBlock
    /// </summary>
    public class Creature
    {
        private string name;
        private string size;
        private string type;
        private string subtype;
        private string source;
        private int page;
        private string alignment;
        private int ac;
        private string acType;
        private int hp;
        private string hd;
        private string speed;
        private AbilitySet abilities;
        private SavingThrowSet savingThrows;
        private List<Skill> skills;
        private string damageVulnerabilities;
        private string damageResistances;
        private string damageImmunities;
        private string conditionImmunities;
        private string senses;
        private string languages;
        private string cr;
        private List<Trait> traits;
        private List<Action> actions;
        private List<Action> reactions;
        private List<Action> legendaryActions;
        private List<Spell> spells;
        private string description;
        private int initMod;
        private int passivePerception;
        private int proficiency;

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        public Creature()
        {
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
            this.damageVulnerabilities = string.Empty;
            this.damageResistances = string.Empty;
            this.damageImmunities = string.Empty;
            this.conditionImmunities = string.Empty;
            this.senses = string.Empty;
            this.languages = string.Empty;
            this.cr = string.Empty;
            this.traits = new List<Trait>();
            this.actions = new List<Action>();
            this.reactions = new List<Action>();
            this.legendaryActions = new List<Action>();
            this.InitiativeMod = this.Dex.Mod;
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
        /// Gets or sets creature source book
        /// </summary>
        public string Source
        {
            get { return this.source; }
            set { this.source = value; }
        }

        /// <summary>
        /// Gets or sets creature source page
        /// </summary>
        public int Page
        {
            get { return this.page; }
            set { this.page = value; }
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
        public Ability Str
        {
            get { return this.abilities.Str; }
        }

        /// <summary>
        /// Gets creature Dexterity
        /// </summary>
        public Ability Dex
        {
            get { return this.abilities.Dex; }
        }

        /// <summary>
        /// Gets creature Constitution
        /// </summary>
        public Ability Con
        {
            get { return this.abilities.Con; }
        }

        /// <summary>
        /// Gets creature Intelligence
        /// </summary>
        public Ability Int
        {
            get { return this.abilities.Int; }
        }

        /// <summary>
        /// Gets creature Wisdom
        /// </summary>
        public Ability Wis
        {
            get { return this.abilities.Wis; }
        }

        /// <summary>
        /// Gets creature Charisma
        /// </summary>
        public Ability Cha
        {
            get { return this.abilities.Cha; }
        }

        /// <summary>
        /// Gets creature Proficiency
        /// </summary>
        public int Proficiency
        {
            get { return this.proficiency; }
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
        /// Gets or sets creature damage vulnerabilities;
        /// </summary>
        public string DamageVulnerabilities
        {
            get { return this.damageVulnerabilities; }
            set { this.damageVulnerabilities = value; }
        }

        /// <summary>
        /// Gets or sets creature damage resistances
        /// </summary>
        public string DamageResistances
        {
            get { return this.damageResistances; }
            set { this.damageResistances = value; }
        }

        /// <summary>
        /// Gets or sets creature damage immunities
        /// </summary>
        public string DamageImmunities
        {
            get { return this.damageImmunities; }
            set { this.damageImmunities = value; }
        }

        /// <summary>
        /// Gets or sets creature condition immunities
        /// </summary>
        public string ConditionImmunities
        {
            get { return this.conditionImmunities; }
            set { this.conditionImmunities = value; }
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
        /// Gets or sets creature challenge rating
        /// </summary>
        public string ChallengeRating
        {
            get
            {
                return this.cr;
            }

            set
            {
                this.cr = value;
                this.proficiency = CRTable.ProfbyCR(this.cr);
            }
        }

        /// <summary>
        /// Gets creature experience points
        /// </summary>
        public long XP
        {
            get { return CRTable.XPbyCR(this.cr); }
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
        /// Gets or sets the creature legendary actions
        /// </summary>
        public List<Action> LegendaryActions
        {
            get { return this.legendaryActions; }
            set { this.legendaryActions = value; }
        }

        /// <summary>
        /// Gets or sets the creature spells
        /// </summary>
        public List<Spell> Spells
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

        /// <summary>
        /// Gets or sets the creature description
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}