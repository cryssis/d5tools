// <copyright file="RollElement.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Core.Dice
{
    /// <summary>
    /// Represents an element on a complex roll involving several dice
    /// </summary>
    public class RollElement
    {
        private int count = default(int);
        private int sides = default(int);

        /// <summary>
        /// Initializes a new instance of the <see cref="RollElement"/> class.
        /// </summary>
        public RollElement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RollElement"/> class.
        /// </summary>
        /// <param name="count">The number of dice to be thrown.</param>
        /// <param name="sides">The number of sides of the dice.</param>
        public RollElement(int count, int sides)
        {
            this.Count = count;
            this.Sides = sides;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RollElement"/> class.
        /// </summary>
        /// <param name="roll">A Multiple Dice Roll</param>
        public RollElement(DieRoll roll)
        {
            this.Count = roll.Count;
            this.Sides = roll.Sides;
        }

        /// <summary>
        /// Gets or sets the number of Dice to be thrown.
        /// </summary>
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        /// <summary>
        /// Gets or sets the number of sides of the dice.
        /// </summary>
        public int Sides
        {
            get { return this.sides; }
            set { this.sides = value; }
        }

        /// <summary>
        /// Gets the string representation of RollElement.
        /// </summary>
        public string Text
        {
            get
            {
                return this.Count + "d" + this.Sides;
            }
        }

        /// <summary>
        /// Compares for Equal two RollElements.
        /// </summary>
        /// <param name="x">The First RollElement.</param>
        /// <param name="y">The Second RollElement.</param>
        /// <returns>True if both RollElements are the same.</returns>
        public static bool operator ==(RollElement x, RollElement y)
        {
            if (((object)x) == null ^ ((object)y) == null)
            {
                return false;
            }

            if (((object)x) == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        /// <summary>
        /// Comperes for Not Equal two RollElements.
        /// </summary>
        /// <param name="x">The First RollElement.</param>
        /// <param name="y">The Second RollElement.</param>
        /// <returns>True if both RollElements are not the same.</returns>
        public static bool operator !=(RollElement x, RollElement y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Converts the RollElement to string.
        /// </summary>
        /// <returns>The RollElement converted to string.</returns>
        public override string ToString()
        {
            return this.Text;
        }

        /// <summary>
        /// Compares one object with the RollElement.
        /// </summary>
        /// <param name="obj">The object to be compared.</param>
        /// <returns>The object is the same that the RollElement.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(RollElement))
            {
                return false;
            }

            RollElement element = (RollElement)obj;

            return this.Count == element.Count && this.Sides == element.Sides;
        }

        /// <summary>
        /// Returns a HashCode for the RollElement.
        /// </summary>
        /// <returns>The HashCode for the RollElement.</returns>
        public override int GetHashCode()
        {
            return (this.Count << 8) | this.Sides;
        }

        /// <summary>
        /// Roll this RollElement
        /// </summary>
        /// <returns>The result of the roll.</returns>
        public int Roll()
        {
            int result = 0;

            if (this.Sides == 1)
            {
                result = this.Sides * this.Count;
            }
            else if (this.Sides > 1)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    result += DieRoll.Random.Next(1, this.Sides + 1);
                }
            }

            return result;
        }
    }
}