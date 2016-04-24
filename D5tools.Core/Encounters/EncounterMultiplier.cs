// <copyright file="EncounterMultiplier.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Encounters
{
    using System.Collections.Generic;
    using System.Linq;
    using D5tools.Core.Characters;

    /// <summary>
    /// Encounter Multiplier table
    /// </summary>
    public static class EncounterMultiplier
    {
        private static Dictionary<int, EncounterMultiplierInfo> multi;

        /// <summary>
        /// Initializes static members of the <see cref="EncounterMultiplier"/> class.
        /// </summary>
        static EncounterMultiplier()
        {
            multi = new Dictionary<int, EncounterMultiplierInfo>();
            multi.Add(1, new EncounterMultiplierInfo { Small = 1.5, Normal = 1, Large = 0.5 });
            multi.Add(2, new EncounterMultiplierInfo { Small = 2, Normal = 1.5, Large = 1 });
            multi.Add(3, new EncounterMultiplierInfo { Small = 2.5, Normal = 2, Large = 1.5 });
            multi.Add(7, new EncounterMultiplierInfo { Small = 3, Normal = 2.5, Large = 2 });
            multi.Add(11, new EncounterMultiplierInfo { Small = 4, Normal = 3, Large = 2.5 });
            multi.Add(15, new EncounterMultiplierInfo { Small = 5, Normal = 4, Large = 3 });
        }

        /// <summary>
        /// Gets the Encounter Multiplier based on the number of monsters and party size
        /// </summary>
        /// <param name="m">Number of monster in the encounter</param>
        /// <param name="p">Size of the party</param>
        /// <returns>The Encounter Multiplier</returns>
        public static double GetMultiplier(int m, PartySize p)
        {
            var row = multi.Where(em => em.Key <= m).Last();
            switch (p)
            {
                case PartySize.Small: return row.Value.Small;
                case PartySize.Normal: return row.Value.Normal;
                case PartySize.Large: return row.Value.Large;
                default: return 0;
            }
        }

        /// <summary>
        /// Encounter Multiplier y Party Size
        /// </summary>
        internal struct EncounterMultiplierInfo
        {
            /// <summary>
            /// Multiplier for Small size party (1-2 characters)
            /// </summary>
            public double Small;

            /// <summary>
            /// Multiplier for Normal size party (3-5 characters)
            /// </summary>
            public double Normal;

            /// <summary>
            /// Multiplier for Large size party (6+ characters)
            /// </summary>
            public double Large;
        }
    }
}
