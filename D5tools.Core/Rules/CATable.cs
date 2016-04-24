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
            caTable.Add(1, new CharacterAdvancementInfo { Proficiency = 2, XP = 0, XPThreshold = new XPThreshold { EasyXP = 25, MediumXP = 50, HardXP = 75, DeadlyXP = 100 } });
            caTable.Add(2, new CharacterAdvancementInfo { Proficiency = 2, XP = 300, XPThreshold = new XPThreshold { EasyXP = 50, MediumXP = 100, HardXP = 150, DeadlyXP = 200 } });
            caTable.Add(3, new CharacterAdvancementInfo { Proficiency = 2, XP = 900, XPThreshold = new XPThreshold { EasyXP = 75, MediumXP = 150, HardXP = 225, DeadlyXP = 400 } });
            caTable.Add(4, new CharacterAdvancementInfo { Proficiency = 2, XP = 2700, XPThreshold = new XPThreshold { EasyXP = 125, MediumXP = 250, HardXP = 375, DeadlyXP = 500 } });
            caTable.Add(5, new CharacterAdvancementInfo { Proficiency = 3, XP = 6500, XPThreshold = new XPThreshold { EasyXP = 250, MediumXP = 500, HardXP = 750, DeadlyXP = 1100 } });
            caTable.Add(6, new CharacterAdvancementInfo { Proficiency = 3, XP = 14000, XPThreshold = new XPThreshold { EasyXP = 300, MediumXP = 600, HardXP = 900, DeadlyXP = 1400 } });
            caTable.Add(7, new CharacterAdvancementInfo { Proficiency = 3, XP = 23000, XPThreshold = new XPThreshold { EasyXP = 350, MediumXP = 750, HardXP = 1100, DeadlyXP = 1700 } });
            caTable.Add(8, new CharacterAdvancementInfo { Proficiency = 3, XP = 34000, XPThreshold = new XPThreshold { EasyXP = 450, MediumXP = 900, HardXP = 1400, DeadlyXP = 2100 } });
            caTable.Add(9, new CharacterAdvancementInfo { Proficiency = 4, XP = 48000, XPThreshold = new XPThreshold { EasyXP = 550, MediumXP = 1100, HardXP = 1600, DeadlyXP = 2400 } });
            caTable.Add(10, new CharacterAdvancementInfo { Proficiency = 4, XP = 64000, XPThreshold = new XPThreshold { EasyXP = 600, MediumXP = 1200, HardXP = 1900, DeadlyXP = 2800 } });
            caTable.Add(11, new CharacterAdvancementInfo { Proficiency = 4, XP = 85000, XPThreshold = new XPThreshold { EasyXP = 800, MediumXP = 1600, HardXP = 2400, DeadlyXP = 3600 } });
            caTable.Add(12, new CharacterAdvancementInfo { Proficiency = 4, XP = 100000, XPThreshold = new XPThreshold { EasyXP = 1000, MediumXP = 2000, HardXP = 3000, DeadlyXP = 4500 } });
            caTable.Add(13, new CharacterAdvancementInfo { Proficiency = 5, XP = 120000, XPThreshold = new XPThreshold { EasyXP = 1100, MediumXP = 2200, HardXP = 3400, DeadlyXP = 5100 } });
            caTable.Add(14, new CharacterAdvancementInfo { Proficiency = 5, XP = 140000, XPThreshold = new XPThreshold { EasyXP = 1250, MediumXP = 2500, HardXP = 3800, DeadlyXP = 5700 } });
            caTable.Add(15, new CharacterAdvancementInfo { Proficiency = 5, XP = 165000, XPThreshold = new XPThreshold { EasyXP = 1400, MediumXP = 2800, HardXP = 4300, DeadlyXP = 6400 } });
            caTable.Add(16, new CharacterAdvancementInfo { Proficiency = 5, XP = 195000, XPThreshold = new XPThreshold { EasyXP = 1600, MediumXP = 3200, HardXP = 4800, DeadlyXP = 7200 } });
            caTable.Add(17, new CharacterAdvancementInfo { Proficiency = 6, XP = 225000, XPThreshold = new XPThreshold { EasyXP = 2000, MediumXP = 3900, HardXP = 5900, DeadlyXP = 8800 } });
            caTable.Add(18, new CharacterAdvancementInfo { Proficiency = 6, XP = 265000, XPThreshold = new XPThreshold { EasyXP = 2100, MediumXP = 4200, HardXP = 6300, DeadlyXP = 9500 } });
            caTable.Add(19, new CharacterAdvancementInfo { Proficiency = 6, XP = 305000, XPThreshold = new XPThreshold { EasyXP = 2400, MediumXP = 4900, HardXP = 7300, DeadlyXP = 10900 } });
            caTable.Add(20, new CharacterAdvancementInfo { Proficiency = 6, XP = 355000, XPThreshold = new XPThreshold { EasyXP = 2800, MediumXP = 5700, HardXP = 8500, DeadlyXP = 12700 } });
        }

        /// <summary>
        /// Returns the XP Value needed by level
        /// </summary>
        /// <param name="level">The Character Level</param>
        /// <returns>The XP Value needed for the level</returns>
        public static int XPByLevel(int level)
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
        public static int ProfByLevel(int level)
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
        /// Returns the XP Thresholds by level
        /// </summary>
        /// <param name="level">The character level</param>
        /// <returns>The XP Threshold for the level</returns>
        public static XPThreshold XPThresholdByLevel(int level)
        {
            try
            {
                var th = new XPThreshold { EasyXP = 0, MediumXP = 0, HardXP = 0, DeadlyXP = 0 };
                if (caTable.ContainsKey(level))
                {
                    th = caTable[level].XPThreshold;
                }

                return th;
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

            /// <summary>
            /// XP Threshold by level
            /// </summary>
            public XPThreshold XPThreshold;
        }
    }
}