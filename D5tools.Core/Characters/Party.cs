// <copyright file="Party.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Rules;

    /// <summary>
    /// Sizes of Character Parties
    /// </summary>
    public enum PartySize
    {
        /// <summary>
        /// Party has no characters
        /// </summary>
        None,

        /// <summary>
        /// Party size of 1 or 2 characters
        /// </summary>
        Small,

        /// <summary>
        /// Party size of 3 to 5 characters
        /// </summary>
        Normal,

        /// <summary>
        /// Party size of 6+ characters
        /// </summary>
        Large
    }

    /// <summary>
    /// A Character Party
    /// </summary>
    public class Party
    {
        private List<Character> characters;

        /// <summary>
        /// Initializes a new instance of the <see cref="Party"/> class.
        /// </summary>
        public Party()
        {
            this.characters = new List<Character>();
        }

        /// <summary>
        /// Gets or sets the characters list in the party
        /// </summary>
        public List<Character> Characters
        {
            get { return this.characters; }
            set { this.characters = value; }
        }

        /// <summary>
        /// Gets the number of characters in the party
        /// </summary>
        public int Count
        {
            get { return this.characters.Count; }
        }

        /// <summary>
        /// Gets Party's XP Threshold
        /// </summary>
        public XPThreshold XPThreshold
        {
            get
            {
                var th = new XPThreshold();
                foreach (var c in this.characters)
                {
                    var cth = CATable.XPThresholdByLevel(c.CharacterLevel);
                    th.EasyXP += cth.EasyXP;
                    th.MediumXP += cth.MediumXP;
                    th.HardXP += cth.HardXP;
                    th.DeadlyXP += cth.DeadlyXP;
                }

                return th;
            }
        }

        /// <summary>
        /// Gets the party size
        /// </summary>
        public PartySize Size
        {
            get
            {
                switch (this.Count)
                {
                    case 0: return PartySize.None;
                    case 1:
                    case 2: return PartySize.Small;
                    case 3:
                    case 4:
                    case 5: return PartySize.Normal;
                    default: return PartySize.Large;
                }
            }
        }
    }
}