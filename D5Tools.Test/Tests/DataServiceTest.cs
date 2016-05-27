// <copyright file="CreatureLoaderTest.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.Test.Tests
{
    using System.Diagnostics;
    using System.Linq;
    using Data;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// A test for DataService
    /// </summary>
    public class DataServiceTest
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataServiceTest"/> class.
        /// </summary>
        /// <param name="output">The output for the test</param>
        public DataServiceTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Gets the creatures from data service
        /// </summary>
        /// <param name="name">The name of the creature</param>
        /// <param name="shouldPass">The test should pass</param>
        [Theory]
        [InlineData("Zuggtmoy", true)]
        [InlineData("Corcho", false)]
        public async void CreatureLoading(string name, bool shouldPass)
        {
            IDataService service = new LocalDataService();
            var bestiary = await service.GetCreaturesAsync();
            var full = bestiary.Count(c => c.Name == name) == 1;
            Assert.True(full == shouldPass);
        }

        /// <summary>
        /// gets the creatures from data service and search by name likeness
        /// </summary>
        /// <param name="query">the string to search in the creature name</param>
        [Theory]
        [InlineData("Crushing Wave")]
        [InlineData("Priest")]
        [InlineData("Giant")]
        public async void CreatureOutput(string query)
        {
            IDataService service = new LocalDataService();
            var bestiary = await service.GetCreaturesAsync();
            bestiary
                .Where(c => c.Name.ToLower().Contains(query.ToLower())).ToList()
                .ForEach(c => this.output.WriteLine("{0} ({1}) - {2}", c.Name, c.Type, c.Source));
            Assert.True(true);
        }
    }
}