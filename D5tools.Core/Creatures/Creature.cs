// <copyright file="Creature.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System.Collections.Generic;
    using Rules;

    /// <summary>
    /// A Creature StatBlock
    /// </summary>
    public class Creature : CreatureBase
    {
        private string source;
        private int page;

        private string damageVulnerabilities;
        private string damageResistances;
        private string damageImmunities;
        private string conditionImmunities;

        private string cr;
        private int proficiency;

        private List<Action> legendaryActions;
        private List<Action> lairActions;

        private string description;

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        public Creature()
            : base()
        {
            this.damageVulnerabilities = string.Empty;
            this.damageResistances = string.Empty;
            this.damageImmunities = string.Empty;
            this.conditionImmunities = string.Empty;
            this.cr = string.Empty;
            this.legendaryActions = new List<Action>();
            this.lairActions = new List<Action>();
            this.InitiativeMod = this.Dex.Mod;
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
        /// Gets creature Proficiency
        /// </summary>
        public int Proficiency
        {
            get { return this.proficiency; }
        }

        /// <summary>
        /// Gets creature experience points
        /// </summary>
        public int XP
        {
            get { return CRTable.XPbyCR(this.cr); }
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
        /// Gets or sets the creature legendary actions
        /// </summary>
        public List<Action> LairActions
        {
            get { return this.lairActions; }
            set { this.lairActions = value; }
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