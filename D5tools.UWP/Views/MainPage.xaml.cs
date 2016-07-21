// <copyright file="MainPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.Views
{
    using ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// The MainPage View
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        /// <summary>
        /// Gets the strongly-type view model to enable x:bind.
        /// </summary>
        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;
    }
}