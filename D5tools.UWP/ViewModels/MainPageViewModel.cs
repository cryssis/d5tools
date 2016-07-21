// <copyright file="MainPageViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Template10.Services.NavigationService;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A ViewModel for MainPage View
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
        }

        /// <inheritdoc/>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                // Recovery from suspensionState
                // this.Value = suspensionState[nameof(this.Value)]?.ToString();
            }

            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                // Saving for suspension
                // suspensionState[nameof(this.Value)] = this.Value;
            }

            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        /// <summary>
        /// Navigate to the SettingsPart of Settings Page
        /// </summary>
        public void GotoSettings() =>
            this.NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        /// <summary>
        /// Navigate to the AboutPart of Settings Page
        /// </summary>
        public void GotoAbout() =>
            this.NavigationService.Navigate(typeof(Views.SettingsPage), 1);
    }
}