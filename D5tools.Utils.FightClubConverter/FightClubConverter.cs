// <copyright file="FightClubConverter.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Utils.FightClubConverter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using D5tools.Core.Creatures;
    using D5tools.Core.Extensions;
    using D5tools.Core.Spells;

    /// <summary>
    /// Creature File Reader for Fight Club files
    /// </summary>
    public class FightClubConverter
    {
        private List<Creature> creatures;
        private List<Spell> spells;
        private char[] wordSeparator = new char[] { ' ' };
        private char[] listSeparator = new char[] { ',' };
        private char[] attackSeparator = new char[] { '|' };
        private char[] parenthesis = new char[] { ')', '(' };
        private char[] mods = new char[] { '+', '-' };

        /// <summary>
        /// Initializes a new instance of the <see cref="FightClubConverter"/> class.
        /// </summary>
        /// <param name="filename">Creature file in FC format</param>
        public FightClubConverter(string filename)
        {
            this.Filename = filename;
            this.creatures = new List<Creature>();
            this.spells = new List<Spell>();
        }

        /// <summary>
        /// Gets the creature list
        /// </summary>
        public List<Creature> Creatures
        {
            get { return this.creatures; }
        }

        /// <summary>
        /// Gets the spell list
        /// </summary>
        public List<Spell> Spells
        {
            get { return this.spells; }
        }

        /// <summary>
        /// Gets or sets the filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Load the creatures from file
        /// </summary>
        public void LoadCreatures()
        {
            XDocument doc = XDocument.Load(this.Filename);

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

                this.creatures.Add(c);
            }
        }

        /// <summary>
        /// Load the spells from file
        /// </summary>
        public void LoadSpells()
        {
            XDocument doc = XDocument.Load(this.Filename);

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

                this.spells.Add(s);
            }
        }

        private void ParseTypeTag(string tag, ref Creature c)
        {
            var parts = tag.Split(this.listSeparator);
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

            var list = tag.Split(this.listSeparator, StringSplitOptions.RemoveEmptyEntries);
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
            var list = tag.Split(this.listSeparator, StringSplitOptions.RemoveEmptyEntries);

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

        private string[] ParseList(string tag)
        {
            return tag.Split(this.listSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()).ToArray();
        }

        private string[] ParseNotes(string tag)
        {
            return tag.Split(this.parenthesis, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim().Trim(this.parenthesis)).ToArray();
        }

        private string[] ParseMods(string tag)
        {
            return tag.Split(this.mods, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim()).ToArray();
        }

        private string[] ParseAttack(string tag)
        {
            return tag.Split(this.attackSeparator, StringSplitOptions.None)
                .Select(p => p.Trim()).ToArray();
        }
    }
}