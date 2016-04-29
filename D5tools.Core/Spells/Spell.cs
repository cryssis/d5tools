// <copyright file="Spell.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Spells
{
    using System.Collections.Generic;

    /// <summary>
    /// A Spell
    /// </summary>
    public class Spell
    {
        private string name;
        private string source;
        private int level;
        private string school;
        private string time;
        private string range;
        private string components;
        private string duration;
        private bool concentration;
        private bool ritual;
        private List<string> classes;
        private List<string> text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spell"/> class.
        /// </summary>
        public Spell()
        {
            this.name = string.Empty;
            this.source = string.Empty;
            this.level = 0;
            this.school = string.Empty;
            this.time = string.Empty;
            this.range = string.Empty;
            this.components = string.Empty;
            this.duration = string.Empty;
            this.concentration = false;
            this.ritual = false;
            this.classes = new List<string>();
            this.text = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Spell"/> class.
        /// </summary>
        /// <param name="name">the spell name</param>
        public Spell(string name)
            : this()
        {
            this.name = name;
        }

        /// <summary>
        /// Gets or sets the spell name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the spell source
        /// </summary>
        public string Source
        {
            get { return this.source; }
            set { this.source = value; }
        }

        /// <summary>
        /// Gets or sets the spell level
        /// </summary>
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        /// <summary>
        /// Gets or sets the spell magic school
        /// </summary>
        public string School
        {
            get { return this.school; }
            set { this.school = value; }
        }

        /// <summary>
        /// Gets or sets the spell casting time
        /// </summary>
        public string Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        /// <summary>
        /// Gets or sets the spell range
        /// </summary>
        public string Range
        {
            get { return this.range; }
            set { this.range = value; }
        }

        /// <summary>
        /// Gets or sets the spell components
        /// </summary>
        public string Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        /// <summary>
        /// Gets or sets the spell duration
        /// </summary>
        public string Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the spell is a concentration spell
        /// </summary>
        public bool IsConcentration
        {
            get { return this.concentration; }
            set { this.concentration = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the spell is a ritual spell
        /// </summary>
        public bool IsRitual
        {
            get { return this.ritual; }
            set { this.ritual = value; }
        }

        /// <summary>
        /// Gets or sets the classes this spell is on their spell list
        /// </summary>
        public List<string> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        /// <summary>
        /// Gets or sets the spell text
        /// </summary>
        public List<string> Text
        {
            get { return this.text; }
            set { this.text = value; }
        }
    }
}