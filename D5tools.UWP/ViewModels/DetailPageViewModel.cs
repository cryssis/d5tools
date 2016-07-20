// <copyright file="DetailPageViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Template10.Services.NavigationService;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A ViewModel for DetailPage View
    /// </summary>
    public class DetailPageViewModel : ViewModelBase
    {
        private string value = "Default";

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailPageViewModel"/> class.
        /// </summary>
        public DetailPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                this.Value = "Designtime value";
            }
        }

        /// <summary>
        /// Gets or sets the Value to be shown
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.Set(ref this.value, value); }
        }

        /// <inheritdoc/>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            this.Value = suspensionState.ContainsKey(nameof(this.Value)) ? suspensionState[nameof(this.Value)]?.ToString() : parameter?.ToString();
            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(this.Value)] = this.Value;
            }

            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }
}