// <copyright file="CreatureTextReader.cs" company="Roberto Sobreviela">
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
    using D5tools.Core.Creatures;
    using D5tools.Core.Extensions;
    using D5tools.Services.Storage;
    using Windows.Storage;

    /// <summary>
    /// A class to import creatures from a Fight Club text file
    /// </summary>
    public class CreatureTextReader : DataItemTextReader<Creature>
    {
        /// <inheritdoc/>
        public override async Task<List<Creature>> LoadFromFile(string filename, StorageFolder folder)
        {
            List<Creature> bestiary = new List<Creature>();

            try
            {
                var file = await folder.GetFileAsync(filename);
                var stream = await file.OpenStreamForReadAsync();
                bestiary = this.ParseContent(stream);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("LoadFromFile:FileNotFoundException");
                return null;
            }

            return bestiary;
        }

        /// <inheritdoc/>
        public override async Task<List<Creature>> LoadFromFile(string filename, StorageStrategies location = StorageStrategies.Local)
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
        protected override List<Creature> ParseContent(Stream stream)
        {
            List<Creature> bestiary = new List<Creature>();

            XDocument doc = XDocument.Load(stream);

            IEnumerable<XElement> library = doc.Descendants("monster");

            foreach (XElement m in library)
            {
                Creature c = new Creature();

                foreach (var tag in m.Elements())
                {
                    switch (tag.Name.ToString().ToLower())
                    {
                        case "name":
                            c.Name = tag.Value;
                            break;

                        case "size":
                            c.Size = this.ParseSizeTag(tag.Value);
                            break;

                        case "type": // type, subtype and source
                            this.ParseTypeTag(tag.Value, ref c);
                            break;

                        case "alignment":
                            c.Alignment = tag.Value;
                            break;

                        case "ac":
                            var acParts = this.ParseNotes(tag.Value);
                            c.ArmorClass = int.Parse(acParts[0]);
                            if (acParts.Count() > 1)
                            {
                                c.ArmorClassType = acParts[1];
                            }

                            break;

                        case "hp":
                            var hpParts = this.ParseNotes(tag.Value);
                            c.HitPoints = int.Parse(hpParts[0]);
                            if (hpParts.Count() > 1)
                            {
                                c.HitDice = hpParts[1];
                            }

                            break;

                        case "speed":
                            c.Speed = tag.Value;
                            break;

                        case "str":
                            c.Abilities.Str.Score = int.Parse(tag.Value);
                            break;

                        case "dex":
                            c.Abilities.Dex.Score = int.Parse(tag.Value);
                            break;

                        case "con":
                            c.Abilities.Con.Score = int.Parse(tag.Value);
                            break;

                        case "int":
                            c.Abilities.Int.Score = int.Parse(tag.Value);
                            break;

                        case "wis":
                            c.Abilities.Wis.Score = int.Parse(tag.Value);
                            break;

                        case "cha":
                            c.Abilities.Cha.Score = int.Parse(tag.Value);
                            break;

                        case "save":
                            c.SavingThrows = this.ParseSaves(tag.Value);
                            break;

                        case "skill":
                            c.Skills = this.ParseSkills(tag.Value);
                            break;

                        case "resist":
                            c.DamageResistances = tag.Value;
                            break;

                        case "vulnerable":
                            c.DamageVulnerabilities = tag.Value;
                            break;

                        case "immune":
                            c.DamageImmunities = tag.Value;
                            break;

                        case "conditionimmune":
                            c.ConditionImmunities = tag.Value;
                            break;

                        case "senses":
                            c.Senses = tag.Value;
                            break;

                        case "passive":
                            c.PassivePerception = int.Parse(tag.Value);
                            break;

                        case "languages":
                            c.Languages = tag.Value;
                            break;

                        case "cr":
                            c.ChallengeRating = tag.Value;
                            break;

                        case "trait":
                            c.Traits.Add(this.ParseTrait(tag));
                            break;

                        case "action":
                            c.Actions.Add(this.ParseAction(tag));
                            break;

                        case "reaction":
                            c.Reactions.Add(this.ParseAction(tag));
                            break;

                        case "legendary":
                            c.LegendaryActions.Add(this.ParseAction(tag));
                            break;

                        case "spells":
                            var spells = this.ParseList(tag.Value);
                            c.Spells = spells.ToList();
                            break;

                        case "description":
                            c.Description = tag.Value;
                            break;

                        default:
                            throw new FormatException(
                                string.Format(
                                    "The tag <{0}> is not allowed.\nMonster: {1}",
                                    tag.Name.ToString(),
                                    m.Descendants("name").First().Value));
                    }
                }

                bestiary.Add(c);
            }

            return bestiary;
        }

        private void ParseTypeTag(string tag, ref Creature c)
        {
            var parts = this.ParseList(tag);
            var typeParts = this.ParseNotes(parts[0]);
            if (typeParts.Count() > 1)
            {
                // Subtype
                c.Subtype = typeParts[1];
            }

            c.Type = typeParts[0].Trim();
            c.Source = parts[1].Trim().ToTitleCase();
        }

        private string ParseSizeTag(string size)
        {
            switch (size)
            {
                case "T": return "tiny";
                case "S": return "small";
                case "M": return "medium";
                case "L": return "large";
                case "H": return "huge";
                case "G": return "gargantuan";
                case "C": return "colossal";
                default: throw new ArgumentException(string.Format("The size {0} is not valid", size));
            }
        }

        private SavingThrowSet ParseSaves(string tag)
        {
            SavingThrowSet saves = new SavingThrowSet();

            var list = this.ParseList(tag);
            foreach (var t in list)
            {
                var parts = this.ParseMods(t);
                var st = parts[0].ToLower().ToUpperFirstLetter();
                var mod = int.Parse(parts[1]);
                switch (st)
                {
                    case "Str":
                        saves.Str.Mod = mod;
                        break;

                    case "Dex":
                        saves.Dex.Mod = mod;
                        break;

                    case "Con":
                        saves.Con.Mod = mod;
                        break;

                    case "Int":
                        saves.Int.Mod = mod;
                        break;

                    case "Wis":
                        saves.Wis.Mod = mod;
                        break;

                    case "Cha":
                        saves.Cha.Mod = mod;
                        break;
                }
            }

            return saves;
        }

        private List<Skill> ParseSkills(string tag)
        {
            List<Skill> skills = new List<Skill>();
            var list = this.ParseList(tag);

            foreach (var t in list)
            {
                var parts = this.ParseMods(t);
                var name = parts[0];
                var mod = int.Parse(parts[1]);
                Skill s = new Skill(name, mod);
                skills.Add(s);
            }

            return skills;
        }

        private Trait ParseTrait(XElement e)
        {
            Trait trait = new Trait();
            var name = e.Descendants("name").First().Value;

            foreach (var tag in e.Elements())
            {
                switch (tag.Name.ToString().ToLower())
                {
                    case "name":
                        trait.Name = tag.Value;
                        break;

                    case "text":
                        trait.Text.Add(tag.Value);
                        break;

                    case "attack":
                        // Ignore
                        break;

                    default:
                        throw new FormatException(string.Format("The trait subtag <{0}> is not valid.", tag.Name.ToString()));
                }
            }

            return trait;
        }

        private Core.Creatures.Action ParseAction(XElement e)
        {
            Core.Creatures.Action action = new Core.Creatures.Action();

            foreach (var tag in e.Elements())
            {
                switch (tag.Name.ToString().ToLower())
                {
                    case "name":
                        action.Name = tag.Value;
                        break;

                    case "text":
                        action.Text.Add(tag.Value);
                        break;

                    case "attack":
                        var parts = this.ParseAttack(tag.Value);
                        Attack attack = new Attack();
                        attack.Name = parts[0];
                        if (parts[1] != string.Empty)
                        {
                            attack.Bonus = int.Parse(parts[1]);
                        }

                        attack.Damage = new Damage(parts[2]);
                        action.Attacks.Add(attack);
                        break;

                    default:
                        throw new FormatException(string.Format("The action subtag <{0}> is not valid.", tag.Name.ToString()));
                }
            }

            return action;
        }
    }
}