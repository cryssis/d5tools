// <copyright file="App.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP
{
    using System.Threading.Tasks;
    using D5tools.UWP.Services.SettingsServices;
    using Template10.Controls;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    // Documentation on APIs used in this page:
    // https://github.com/Windows-XAML/Template10/wiki

    /// <summary>
    /// App Entry point
    /// </summary>
    [Bindable]
    public sealed partial class App : Template10.Common.BootStrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.SplashFactory = (e) => new Views.Splash(e);
            var settings = SettingsService.Instance;
            this.RequestedTheme = settings.AppTheme;
            this.CacheMaxDuration = settings.CacheMaxDuration;
            this.ShowShellBackButton = settings.UseShellBackButton;
        }

        /// <summary>
        /// Executed on app activation
        /// </summary>
        /// <param name="args">The arguments from the activation event</param>
        /// <returns>A Task for asyncronicity</returns>
        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            if (Window.Current.Content as ModalDialog == null)
            {
                // create a new frame
                var nav = this.NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);

                // create modal root
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = new Views.Shell(nav),
                    ModalContent = new Views.Busy(),
                };
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Executed on app resume except from resume from termination
        /// </summary>
        /// <param name="startKind">The type of start from resume state</param>
        /// <param name="args">The arguments from the activation event</param>
        /// <returns>A Task for asyncronicity</returns>
        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here
            await Task.Delay(1000);

            this.NavigationService.Navigate(typeof(Views.MainPage));
            await Task.CompletedTask;
        }
    }
}