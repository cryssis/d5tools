// <copyright file="SkillSet.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Creature skill set
    /// </summary>
    public class SkillSet
    {
        private Dictionary<Skills, int> skills;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillSet"/> class.
        /// </summary>
        public SkillSet()
        {
            this.skills = new Dictionary<Skills, int>();
        }

        /// <summary>
        /// Gets or sets the saving throw modifiers
        /// </summary>
        public Dictionary<Skills, int> Skills
        {
            get { return this.skills; }
            set { this.skills = value; }
        }

        /// <summary>
        /// Gets the skill by name
        /// </summary>
        /// <param name="name">the string describing the skill</param>
        /// <returns>The skill</returns>
        public Skills ByName(string name)
        {
            switch (name.ToLower())
            {
                case "acrobatics": return Creatures.Skills.Acrobatics;
                case "animalhandling": return Creatures.Skills.AnimalHandling;
                case "arcana": return Creatures.Skills.Arcana;
                case "athletics": return Creatures.Skills.Athletics;
                case "deception": return Creatures.Skills.Deception;
                case "history": return Creatures.Skills.History;
                case "insight": return Creatures.Skills.Insight;
                case "intimidation": return Creatures.Skills.Intimidation;
                case "investigation": return Creatures.Skills.Investigation;
                case "medicine": return Creatures.Skills.Medicine;
                case "nature": return Creatures.Skills.Nature;
                case "perception": return Creatures.Skills.Perception;
                case "performance": return Creatures.Skills.Performance;
                case "persuasion": return Creatures.Skills.Persuasion;
                case "religion": return Creatures.Skills.Religion;
                case "sleightofhand": return Creatures.Skills.SleightOfHand;
                case "stealth": return Creatures.Skills.Stealth;
                case "survival": return Creatures.Skills.Survival;
            }

            return Creatures.Skills.None;
        }
    }
}