// <copyright file="CRTable.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Rules
{
    using System.Collections.Generic;

    /// <summary>
    /// A utility class for XP calculations
    /// </summary>
    public static class CRTable
    {
        private static Dictionary<string, ChallengeRatingInfo> crTable;

        /// <summary>
        /// Initializes static members of the <see cref="Rules.CRTable"/> class.
        /// </summary>
        static CRTable()
        {
            crTable = new Dictionary<string, ChallengeRatingInfo>();
            crTable.Add("0", new ChallengeRatingInfo { Proficiency = 2, XP = 10 });
            crTable.Add("1/8", new ChallengeRatingInfo { Proficiency = 2, XP = 25 });
            crTable.Add("1/4", new ChallengeRatingInfo { Proficiency = 2, XP = 50 });
            crTable.Add("1/2", new ChallengeRatingInfo { Proficiency = 2, XP = 100 });
            crTable.Add("1", new ChallengeRatingInfo { Proficiency = 2, XP = 200 });
            crTable.Add("2", new ChallengeRatingInfo { Proficiency = 2, XP = 450 });
            crTable.Add("3", new ChallengeRatingInfo { Proficiency = 2, XP = 700 });
            crTable.Add("4", new ChallengeRatingInfo { Proficiency = 2, XP = 1100 });
            crTable.Add("5", new ChallengeRatingInfo { Proficiency = 3, XP = 1800 });
            crTable.Add("6", new ChallengeRatingInfo { Proficiency = 3, XP = 2300 });
            crTable.Add("7", new ChallengeRatingInfo { Proficiency = 3, XP = 2900 });
            crTable.Add("8", new ChallengeRatingInfo { Proficiency = 3, XP = 3900 });
            crTable.Add("9", new ChallengeRatingInfo { Proficiency = 4, XP = 5000 });
            crTable.Add("10", new ChallengeRatingInfo { Proficiency = 4, XP = 5900 });
            crTable.Add("11", new ChallengeRatingInfo { Proficiency = 4, XP = 7200 });
            crTable.Add("12", new ChallengeRatingInfo { Proficiency = 4, XP = 8400 });
            crTable.Add("13", new ChallengeRatingInfo { Proficiency = 5, XP = 10000 });
            crTable.Add("14", new ChallengeRatingInfo { Proficiency = 5, XP = 11500 });
            crTable.Add("15", new ChallengeRatingInfo { Proficiency = 5, XP = 13000 });
            crTable.Add("16", new ChallengeRatingInfo { Proficiency = 5, XP = 15000 });
            crTable.Add("17", new ChallengeRatingInfo { Proficiency = 6, XP = 18000 });
            crTable.Add("18", new ChallengeRatingInfo { Proficiency = 6, XP = 20000 });
            crTable.Add("19", new ChallengeRatingInfo { Proficiency = 6, XP = 22000 });
            crTable.Add("20", new ChallengeRatingInfo { Proficiency = 6, XP = 25000 });
            crTable.Add("21", new ChallengeRatingInfo { Proficiency = 7, XP = 33000 });
            crTable.Add("22", new ChallengeRatingInfo { Proficiency = 7, XP = 41000 });
            crTable.Add("23", new ChallengeRatingInfo { Proficiency = 7, XP = 50000 });
            crTable.Add("24", new ChallengeRatingInfo { Proficiency = 7, XP = 62000 });
            crTable.Add("25", new ChallengeRatingInfo { Proficiency = 8, XP = 75000 });
            crTable.Add("26", new ChallengeRatingInfo { Proficiency = 8, XP = 90000 });
            crTable.Add("27", new ChallengeRatingInfo { Proficiency = 8, XP = 105000 });
            crTable.Add("28", new ChallengeRatingInfo { Proficiency = 8, XP = 120000 });
            crTable.Add("29", new ChallengeRatingInfo { Proficiency = 9, XP = 135000 });
            crTable.Add("30", new ChallengeRatingInfo { Proficiency = 9, XP = 155000 });
        }

        /// <summary>
        /// Returns the XP Value by Challenge Rating
        /// </summary>
        /// <param name="crText">The Challenge Rating</param>
        /// <returns>The XP Value for the Challenge Rating</returns>
        public static int XPbyCR(string crText)
        {
            try
            {
                int xpVal = 0;
                if (crTable.ContainsKey(crText))
                {
                    xpVal = crTable[crText].XP;
                }

                return xpVal;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the Proficiency bonus by Challenge Rating
        /// </summary>
        /// <param name="crText">The challenge Rating</param>
        /// <returns>The proficiency bonus for the Challenge Rating</returns>
        public static int ProfbyCR(string crText)
        {
            try
            {
                int prof = 0;
                if (crTable.ContainsKey(crText))
                {
                    prof = crTable[crText].Proficiency;
                }

                return prof;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Challenge Rating related information
        /// </summary>
        internal struct ChallengeRatingInfo
        {
            /// <summary>
            /// Experience by Challenge Rating
            /// </summary>
            public int XP;

            /// <summary>
            /// Proficiency by Challenge Rating
            /// </summary>
            public int Proficiency;
        }
    }
}