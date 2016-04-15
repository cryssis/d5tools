// <copyright file="Encounter.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Encounters
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An adventure encounter
    /// </summary>
    public class Encounter
    {
        private List<Combatant> combatants;
        private string name;
        private string code;
        private string adventure;
        private List<string> tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="Encounter"/> class.
        /// </summary>
        public Encounter()
        {
            this.combatants = new List<Combatant>();
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
        /// Gets or sets encounter combatants
        /// </summary>
        public List<Combatant> Combatants
        {
            get { return this.combatants; }
            set { this.combatants = value; }
        }

        /// <summary>
        /// Gets the encounter groups
        /// </summary>
        public List<string> Groups
        {
            get { return this.combatants.Select(c => c.Group).Distinct().ToList(); }
        }
    }
}