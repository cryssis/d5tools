// <copyright file="Shell.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.Views
{
    using Template10.Controls;
    using Template10.Services.NavigationService;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// The Shell wrapping the Navigation Frame
    /// </summary>
    public sealed partial class Shell : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        public Shell()
        {
            Instance = this;
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service to be injected on the shell</param>
        public Shell(INavigationService navigationService)
            : this()
        {
            this.SetNavigationService(navigationService);
        }

        /// <summary>
        /// Gets or sets gets the Shell Instance (Singleton)
        /// </summary>
        public static Shell Instance { get; set; }

        /// <summary>
        /// Gets the HamburguerMenu UserControl of the Shell
        /// </summary>
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;

        /// <summary>
        /// Sets the Navigation service of the shell
        /// </summary>
        /// <param name="navigationService">The Navigation Service</param>
        public void SetNavigationService(INavigationService navigationService)
        {
            this.MyHamburgerMenu.NavigationService = navigationService;
        }
    }
}