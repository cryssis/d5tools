// <copyright file="DetailPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.Views
{
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// The DetailPage View
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailPage"/> class.
        /// </summary>
        public DetailPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Disabled;
        }
    }
}