// <copyright file="RollResult.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Dice
{
    using System.Collections.Generic;
    using D5tools.Core.Extensions;

    /// <summary>
    /// RollResult represents the result of rolling some dice.
    /// </summary>
    public class RollResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RollResult"/> class.
        /// </summary>
        public RollResult()
        {
            this.Rolls = new List<DieResult>();
        }

        /// <summary>
        /// Gets or sets the modifier to be added to the result of the dice rolls.
        /// </summary>
        public int Mod { get; set; }

        /// <summary>
        /// Gets or sets the list of results of several dice rolls.
        /// </summary>
        public List<DieResult> Rolls { get; set; }

        /// <summary>
        /// Gets or sets the total of the dice rolls included the modifier.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets the result in text format
        /// </summary>
        public string Text
        {
            get
            {
                string text = string.Empty;
                foreach (var r in this.Rolls)
                {
                    if (text == string.Empty)
                    {
                        text = string.Format("{0}", r.Result);
                    }
                    else
                    {
                        text += string.Format(",{0}", r.Result);
                    }
                }

                if (text != string.Empty)
                {
                    text = string.Format("({0})", text);
                }

                if (this.Mod != 0)
                {
                    text += this.Mod.PlusFormat();
                }

                if (this.Rolls.Count != 0 || this.Mod != 0)
                {
                    text += string.Format(" = ");
                }

                text += this.Total;

                return text;
            }
        }

        /// <summary>
        /// The + operator for adding RollResult.
        /// </summary>
        /// <param name="x">The first RollResult.</param>
        /// <param name="y">The second RollResult.</param>
        /// <returns>The resulting RollResult adding both rolls</returns>
        public static RollResult operator +(RollResult x, RollResult y)
        {
            RollResult result = new RollResult();
            result.Total = x.Total + y.Total;
            result.Mod = x.Mod + y.Mod;
            result.Rolls.AddRange(x.Rolls);
            result.Rolls.AddRange(y.Rolls);

            return result;
        }
    }
}