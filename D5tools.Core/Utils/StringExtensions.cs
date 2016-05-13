// <copyright file="StringExtensions.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Utils
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Static string extension methods for formatting.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Format a integer on a string with sign and space.
        /// </summary>
        /// <param name="number">The integer number to format.</param>
        /// <returns>The string that contains the integer with its sign and a space.</returns>
        public static string PlusFormatSpaceNumber(int number)
        {
            if (number >= 0)
            {
                return "+ " + number.ToString();
            }
            else
            {
                return "- " + Math.Abs(number).ToString();
            }
        }

        /// <summary>
        /// Format a integer on a string with sign.
        /// </summary>
        /// <param name="number">The integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormatNumber(int number)
        {
            if (number >= 0)
            {
                return "+" + number.ToString();
            }
            else
            {
                return number.ToString();
            }
        }

        /// <summary>
        /// Format a nullable integer on a string with sign.
        /// </summary>
        /// <param name="number">The nullable integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormatNumber(int? number)
        {
            if (number == null)
            {
                return "-";
            }
            else
            {
                return ((int)number).PlusFormat();
            }
        }

        /// <summary>
        /// Static Integer Method to format a integer on a string with sign.
        /// </summary>
        /// <param name="number">The integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormat(this int number)
        {
            return PlusFormatNumber(number);
        }

        /// <summary>
        /// Static Nullable Integer Method to format a nullable integer on a string with sign.
        /// </summary>
        /// <param name="number">The nullable integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormat(this int? number)
        {
            return PlusFormatNumber(number);
        }

        /// <summary>
        /// Converts to Upper the first letter of a string
        /// </summary>
        /// <param name="source">the source string</param>
        /// <returns>the source string with first letter Uppercase</returns>
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            char[] letters = source.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }

        /// <summary>
        /// Convert to Upper the first letter of each word in the string
        /// </summary>
        /// <param name="source">the source string</param>
        /// <returns>the source string with every word First Upper Case letter</returns>
        public static string ToTitleCase(this string source)
        {
            return Regex.Replace(
                source,
                @"\b\w",
                (Match match) => match.ToString().ToUpper());
        }
    }
}