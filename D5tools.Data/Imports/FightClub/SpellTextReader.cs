// <copyright file="SpellTextReader.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Data.Imports.FightClub
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using D5tools.Core.Extensions;
    using D5tools.Core.Spells;
    using D5tools.Services.Storage;
    using Windows.Storage;

    /// <summary>
    /// A class to import spells from a Fight Club text file
    /// </summary>
    public class SpellTextReader : DataItemTextReader<Spell>
    {
        /// <inheritdoc/>
        public override async Task<List<Spell>> LoadFromFile(string filename, StorageFolder folder)
        {
            List<Spell> grimoire = new List<Spell>();

            try
            {
                var file = await folder.GetFileAsync(filename);
                var stream = await file.OpenStreamForReadAsync();
                grimoire = this.ParseContent(stream);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("LoadFromFile:FileNotFoundException");
                return null;
            }

            return grimoire;
        }

        /// <inheritdoc/>
        public override async Task<List<Spell>> LoadFromFile(string filename, StorageStrategies location = StorageStrategies.Local)
        {
            StorageFolder folder;
            switch (location)
            {
                case StorageStrategies.Local:
                    folder = ApplicationData.Current.LocalFolder;
                    break;

                case StorageStrategies.Roaming:
                    folder = ApplicationData.Current.RoamingFolder;
                    break;

                case StorageStrategies.Temporary:
                    folder = ApplicationData.Current.TemporaryFolder;
                    break;

                default:
                    throw new NotSupportedException(location.ToString());
            }

            return await this.LoadFromFile(filename, folder);
        }

        /// <inheritdoc/>
        protected override List<Spell> ParseContent(Stream stream)
        {
            List<Spell> grimoire = new List<Spell>();

            XDocument doc = XDocument.Load(stream);

            IEnumerable<XElement> library = doc.Descendants("spell");

            foreach (XElement e in library)
            {
                Spell s = new Spell();

                foreach (var tag in e.Elements())
                {
                    switch (tag.Name.ToString().ToLower())
                    {
                        case "name":
                            var nameParts = this.ParseNotes(tag.Value);
                            s.Name = nameParts[0];
                            if (nameParts.Count() > 1)
                            {
                                s.Source = this.ParseSource(nameParts[1]);
                            }
                            else
                            {
                                s.Source = this.ParseSource("PHB");
                            }

                            break;

                        case "level":
                            s.Level = int.Parse(tag.Value);
                            break;

                        case "school":
                            s.School = this.ParseSchool(tag.Value);
                            break;

                        case "ritual":
                            s.IsRitual = true;
                            break;

                        case "time":
                            s.Time = tag.Value;
                            break;

                        case "range":
                            s.Range = tag.Value;
                            break;

                        case "components":
                            s.Components = tag.Value;
                            break;

                        case "duration":
                            s.Duration = tag.Value;
                            s.IsConcentration = s.Duration.ToLower().Contains("concentration");
                            break;

                        case "classes":
                            s.Classes = this.ParseList(tag.Value).ToList();
                            break;

                        case "text":
                            s.Text.Add(tag.Value);
                            break;

                        case "roll":
                            // Ignore
                            break;

                        default:
                            throw new FormatException(
                                string.Format(
                                    "The tag <{0}> is not allowed.\nSpell: {1}",
                                    tag.Name.ToString(),
                                    e.Descendants("name").First().Value));
                    }
                }

                grimoire.Add(s);
            }

            return grimoire;
        }

        private string ParseSource(string source)
        {
            switch (source)
            {
                case "PHB": return "Player's Handbook";
                case "MM": return "Monster Manual";
                case "DMG": return "Dungeon Master Guide";
                case "HotDQ": return "Hoard of the Dragon Queen";
                case "RoT": return "Raise of Tiamat";
                case "ToD": return "Tiranny of Dragons";
                case "EE": return "Elemental Evil";
                case "PotA": return "Princes of the Apocalypse";
                case "RoD": return "Rage of Demons";
                case "OotA": return "Out of the Abyss";
                case "SCAG": return "Sword Coast Adventurer's Guide";
                case "CoS": return "Curse of Strahd";
                default: throw new ArgumentException(string.Format("The souce {0} is not valid", source));
            }
        }

        private string ParseSchool(string school)
        {
            switch (school)
            {
                case "A": return "abjuration";
                case "C": return "conjuration";
                case "D": return "divination";
                case "EN": return "enchantment";
                case "EV": return "evocation";
                case "I": return "illusion";
                case "N": return "necromancy";
                case "T": return "transmutation";
                default: throw new ArgumentException(string.Format("The school {0} is not valid", school));
            }
        }
    }
}