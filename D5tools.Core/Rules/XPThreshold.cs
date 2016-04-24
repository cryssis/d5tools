// <copyright file="XPThreshold.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Rules
{
    /// <summary>
    /// XP Threshold levels by Character Level
    /// </summary>
    public class XPThreshold
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XPThreshold"/> class.
        /// </summary>
        public XPThreshold()
            : this(0, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XPThreshold"/> class.
        /// </summary>
        /// <param name="e">Easy value</param>
        /// <param name="m">Medium value</param>
        /// <param name="h">Hard value</param>
        /// <param name="d">Deadly value</param>
        public XPThreshold(int e, int m, int h, int d)
        {
            this.EasyXP = e;
            this.MediumXP = m;
            this.HardXP = h;
            this.DeadlyXP = d;
        }

        /// <summary>
        /// Gets or sets XP Threshold for Easy Encounter
        /// </summary>
        public int EasyXP { get; set; }

        /// <summary>
        /// Gets or sets XP Threshold for Medium Encounter
        /// </summary>
        public int MediumXP { get; set; }

        /// <summary>
        /// Gets or sets XP Threshold for Hard Encounter
        /// </summary>
        public int HardXP { get; set; }

        /// <summary>
        /// Gets or sets XP Threshold for Deadly Encounter
        /// </summary>
        public int DeadlyXP { get; set; }
    }
}
