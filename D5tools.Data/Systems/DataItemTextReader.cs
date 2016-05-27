// <copyright file="DataItemTextReader.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Data.Systems
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using D5tools.Services.Storage;
    using Windows.Storage;

    /// <summary>
    /// A reader to import data items from text files
    /// </summary>
    /// <typeparam name="DataItem">The data item to be imported</typeparam>
    public abstract class DataItemTextReader<DataItem> : IDataItemTextReader<DataItem>
    {
        private char[] wordSeparator = new char[] { ' ' };
        private char[] listSeparator = new char[] { ',' };
        private char[] attackSeparator = new char[] { '|' };
        private char[] parenthesis = new char[] { ')', '(' };
        private char[] mods = new char[] { '+', '-' };

        /// <inheritdoc/>
        public virtual Task<List<DataItem>> LoadFromFile(string filename, StorageStrategies location = StorageStrategies.Local)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual Task<List<DataItem>> LoadFromFile(string filename, StorageFolder folder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parses the content from the file
        /// </summary>
        /// <param name="stream">The stream with the content of the file</param>
        /// <returns>A List of DataItems</returns>
        protected virtual List<DataItem> ParseContent(Stream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parses a list separated by commas
        /// </summary>
        /// <param name="tag">The string to be parsed</param>
        /// <returns>an array of parsed strings</returns>
        protected string[] ParseList(string tag)
        {
            return tag.Split(this.listSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()).ToArray();
        }

        /// <summary>
        /// Parses a string with comments enclosed on parenthesis
        /// </summary>
        /// <param name="tag">the string to be parsed</param>
        /// <returns>an array of parsed strings</returns>
        protected string[] ParseNotes(string tag)
        {
            return tag.Split(this.parenthesis, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim().Trim(this.parenthesis)).ToArray();
        }

        /// <summary>
        /// Parses a string containing a number and a sign
        /// </summary>
        /// <param name="tag">the string to be parsed</param>
        /// <returns>an array of parsed strings</returns>
        protected string[] ParseMods(string tag)
        {
            return tag.Split(this.mods, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()).ToArray();
        }

        /// <summary>
        /// Parses a string containing an attack description
        /// </summary>
        /// <param name="tag">the string to be parsed</param>
        /// <returns>an array of parsed strings</returns>
        protected string[] ParseAttack(string tag)
        {
            return tag.Split(this.attackSeparator, StringSplitOptions.None)
                .Select(p => p.Trim()).ToArray();
        }
    }
}