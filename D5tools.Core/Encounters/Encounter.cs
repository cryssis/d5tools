// <copyright file="Encounter.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Encounters
{
    using System.Collections.Generic;
    using System.Linq;
    using D5tools.Core.Characters;
    using D5tools.Core.Creatures;

    /// <summary>
    /// An adventure encounter
    /// </summary>
    public class Encounter
    {
        private List<EncounterGroup> groups;
        private string name;
        private string code;
        private string adventure;
        private List<string> tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="Encounter"/> class.
        /// </summary>
        public Encounter()
        {
            this.groups = new List<EncounterGroup>();
            this.name = string.Empty;
            this.code = string.Empty;
            this.adventure = string.Empty;
            this.tags = new List<string>();
        }

        /// <summary>
        /// Gets or sets encounter name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets encounter code
        /// </summary>
        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        /// <summary>
        /// Gets or sets encounter adventure
        /// </summary>
        public string Adventure
        {
            get { return this.adventure; }
            set { this.adventure = value; }
        }

        /// <summary>
        /// Gets or sets encounter tags
        /// </summary>
        public List<string> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        /// <summary>
        /// Gets or sets the encounter groups
        /// </summary>
        public List<EncounterGroup> Groups
        {
            get { return this.groups; }
            set { this.groups = value; }
        }

        /// <summary>
        /// Gets the encounter Creatures
        /// </summary>
        public List<Creature> Creatures
        {
            get { return this.groups.Select(g => g.Creature).ToList(); }
        }

        /// <summary>
        /// Gets the encounter XP value
        /// </summary>
        public int XP
        {
            get { return this.groups.Sum(g => g.XP); }
        }

        /// <summary>
        /// Gets the encounter adjusted XP value
        /// </summary>
        /// <param name="p">The character party size facing the encounter</param>
        /// <returns>The Adjusted XP value for the encounter</returns>
        public int GetAdjustedXP(PartySize p)
        {
            var m = this.Groups.Sum(g => g.Number);
            var multiplier = EncounterMultiplier.GetMultiplier(m, p);
            var xp = this.XP;
            var adjustedXP = xp * multiplier;
            return (int)adjustedXP;
        }

        /// <summary>
        /// Gets the encounter difficulty
        /// </summary>
        /// <param name="p">The character party facinf the encounter</param>
        /// <returns>The difficulty level for the enconter for the party</returns>
        public DifficultyLevel GetDifficulty(Party p)
        {
            var adjustedXP = this.GetAdjustedXP(p.Size);
            var thresholds = p.XPThreshold;
            if (adjustedXP < thresholds.EasyXP)
            {
                return DifficultyLevel.Trivial;
            }

            if (adjustedXP < thresholds.MediumXP)
            {
                return DifficultyLevel.Easy;
            }

            if (adjustedXP < thresholds.HardXP)
            {
                return DifficultyLevel.Hard;
            }

            return DifficultyLevel.Deadly;
        }

        /// <summary>
        /// Adds a Creature to the encounter
        /// </summary>
        /// <param name="c">The creature to add</param>
        public void AddCreature(Creature c)
        {
            var group = this.groups.Find(g => g.Creature.Name == c.Name);
            if (group == null)
            {
                this.Groups.Add(new EncounterGroup(c));
            }
            else
            {
                group.Number += 1;
            }
        }

        /// <summary>
        /// Removes a Creature from the encounter
        /// </summary>
        /// <param name="c">The creature to remove</param>
        public void RemoveCreature(Creature c)
        {
            var group = this.groups.Find(g => g.Creature.Name == c.Name);
            if ((group != null) && (group.Number == 1))
            {
                this.Groups.Remove(group);
            }
            else
            {
                group.Number -= 1;
            }
        }
    }
}