// <copyright file="SettingsService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.Services.SettingsServices
{
    using System;
    using Template10.Common;
    using Template10.Utils;
    using Windows.UI.Xaml;

    /// <summary>
    /// An App Settings Service
    /// </summary>
    public class SettingsService
    {
        private Template10.Services.SettingsService.ISettingsHelper helper;

        private SettingsService()
        {
            this.helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        /// <summary>
        /// Gets the Service Instance (Singleton)
        /// </summary>
        public static SettingsService Instance { get; } = new SettingsService();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the UseShellBackButton Setting
        /// </summary>
        public bool UseShellBackButton
        {
            get
            {
                return this.helper.Read<bool>(nameof(this.UseShellBackButton), true);
            }

            set
            {
                this.helper.Write(nameof(this.UseShellBackButton), value);
                BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
                {
                    BootStrapper.Current.ShowShellBackButton = value;
                    BootStrapper.Current.UpdateShellBackButton();
                    BootStrapper.Current.NavigationService.Refresh();
                });
            }
        }

        /// <summary>
        /// Gets or sets the AppTheme Setting
        /// </summary>
        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Light;
                var value = this.helper.Read<string>(nameof(this.AppTheme), theme.ToString());
                return Enum.TryParse<ApplicationTheme>(value, out theme) ? theme : ApplicationTheme.Dark;
            }

            set
            {
                this.helper.Write(nameof(this.AppTheme), value.ToString());
                (Window.Current.Content as FrameworkElement).RequestedTheme = value.ToElementTheme();
                Views.Shell.HamburgerMenu.RefreshStyles(value);
            }
        }

        /// <summary>
        /// Gets or sets the CacheMaxDuration Setting
        /// </summary>
        public TimeSpan CacheMaxDuration
        {
            get
            {
                return this.helper.Read<TimeSpan>(nameof(this.CacheMaxDuration), TimeSpan.FromDays(2));
            }

            set
            {
                this.helper.Write(nameof(this.CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }
    }
}