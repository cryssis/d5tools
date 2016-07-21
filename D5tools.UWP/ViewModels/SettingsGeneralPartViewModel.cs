// <copyright file="SettingsGeneralPartViewModel.cs" company="Roberto Sobreviela">
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
    public class SettingsGeneralPartViewModel : ViewModelBase
    {
        private Services.SettingsServices.SettingsService settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsGeneralPartViewModel"/> class.
        /// </summary>
        public SettingsGeneralPartViewModel()
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
    }
}