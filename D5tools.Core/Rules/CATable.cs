// <copyright file="CATable.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Rules
{
    using System.Collections.Generic;

    /// <summary>
    /// A utility class for Character Advancement
    /// </summary>
    public static class CATable
    {
        private static Dictionary<int, CharacterAdvancementInfo> caTable;

        /// <summary>
        /// Initializes static members of the <see cref="CATable"/> class.
        /// </summary>
        static CATable()
        {
            caTable = new Dictionary<int, CharacterAdvancementInfo>();
            caTable.Add(1, new CharacterAdvancementInfo { Proficiency = 2, XP = 0 });
            caTable.Add(2, new CharacterAdvancementInfo { Proficiency = 2, XP = 300 });
            caTable.Add(3, new CharacterAdvancementInfo { Proficiency = 2, XP = 900 });
            caTable.Add(4, new CharacterAdvancementInfo { Proficiency = 2, XP = 2700 });
            caTable.Add(5, new CharacterAdvancementInfo { Proficiency = 3, XP = 6500 });
            caTable.Add(6, new CharacterAdvancementInfo { Proficiency = 3, XP = 14000 });
            caTable.Add(7, new CharacterAdvancementInfo { Proficiency = 3, XP = 23000 });
            caTable.Add(8, new CharacterAdvancementInfo { Proficiency = 3, XP = 34000 });
            caTable.Add(9, new CharacterAdvancementInfo { Proficiency = 4, XP = 48000 });
            caTable.Add(10, new CharacterAdvancementInfo { Proficiency = 4, XP = 64000 });
            caTable.Add(11, new CharacterAdvancementInfo { Proficiency = 4, XP = 85000 });
            caTable.Add(12, new CharacterAdvancementInfo { Proficiency = 4, XP = 100000 });
            caTable.Add(13, new CharacterAdvancementInfo { Proficiency = 5, XP = 120000 });
            caTable.Add(14, new CharacterAdvancementInfo { Proficiency = 5, XP = 140000 });
            caTable.Add(15, new CharacterAdvancementInfo { Proficiency = 5, XP = 165000 });
            caTable.Add(16, new CharacterAdvancementInfo { Proficiency = 5, XP = 195000 });
            caTable.Add(17, new CharacterAdvancementInfo { Proficiency = 6, XP = 225000 });
            caTable.Add(18, new CharacterAdvancementInfo { Proficiency = 6, XP = 265000 });
            caTable.Add(19, new CharacterAdvancementInfo { Proficiency = 6, XP = 305000 });
            caTable.Add(20, new CharacterAdvancementInfo { Proficiency = 6, XP = 355000 });
        }

        /// <summary>
        /// Returns the XP Value needed by level
        /// </summary>
        /// <param name="level">The Character Level</param>
        /// <returns>The XP Value needed for the level</returns>
        public static int XPbyLevel(int level)
        {
            try
            {
                int xpVal = 0;
                if (caTable.ContainsKey(level))
                {
                    xpVal = caTable[level].XP;
                }

                return xpVal;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the Proficiency bonus by level
        /// </summary>
        /// <param name="level">The character level</param>
        /// <returns>The proficiency bonus for the level</returns>
        public static int ProfbyLevel(int level)
        {
            try
            {
                int prof = 0;
                if (caTable.ContainsKey(level))
                {
                    prof = caTable[level].Proficiency;
                }

                return prof;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Character Advancement related information
        /// </summary>
        internal struct CharacterAdvancementInfo
        {
            /// <summary>
            /// Experience needed by level
            /// </summary>
            public int XP;

            /// <summary>
            /// Proficiency by level
            /// </summary>
            public int Proficiency;
        }
    }
}