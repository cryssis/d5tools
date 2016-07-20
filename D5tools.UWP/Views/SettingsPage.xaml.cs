// <copyright file="SettingsPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.Views
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// The SettingsPage View
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private Template10.Services.SerializationService.ISerializationService serializationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPage"/> class.
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();
            this.serializationService = Template10.Services.SerializationService.SerializationService.Json;
        }

        /// <inheritdoc/>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(this.serializationService.Deserialize(e.Parameter?.ToString()).ToString());
            this.MyPivot.SelectedIndex = index;
        }
    }
}