// <copyright file="SettingsPartViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.ViewModels
{
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Windows.UI.Xaml;

    /// <summary>
    /// A ViewModel for SettingsPart of SettingsPage View
    /// </summary>
    public class SettingsPartViewModel : ViewModelBase
    {
        private Services.SettingsServices.SettingsService settings;
        private string busyText = "Please wait...";
        private DelegateCommand showBusyCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPartViewModel"/> class.
        /// </summary>
        public SettingsPartViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                this.settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the UseShellBackButton Setting
        /// </summary>
        public bool UseShellBackButton
        {
            get
            {
                return this.settings.UseShellBackButton;
            }

            set
            {
                this.settings.UseShellBackButton = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the UseLightThemeButton Setting
        /// </summary>
        public bool UseLightThemeButton
        {
            get
            {
                return this.settings.AppTheme.Equals(ApplicationTheme.Light);
            }

            set
            {
                this.settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the text to be shown on the BusyPage View
        /// </summary>
        public string BusyText
        {
            get
            {
                return this.busyText;
            }

            set
            {
                this.Set(ref this.busyText, value);
                this.showBusyCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets the ShowBusyCommand
        /// </summary>
        public DelegateCommand ShowBusyCommand
            => this.showBusyCommand ?? (this.showBusyCommand = new DelegateCommand(
                async () =>
            {
                Views.Busy.SetBusy(true, this.busyText);
                await Task.Delay(5000);
                Views.Busy.SetBusy(false);
            }, () => !string.IsNullOrEmpty(this.BusyText)));
    }
}