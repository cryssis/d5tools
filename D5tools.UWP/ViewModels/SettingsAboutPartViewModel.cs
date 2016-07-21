// <copyright file="SettingsAboutPartViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.ViewModels
{
    using System;
    using Template10.Mvvm;

    /// <summary>
    /// A ViewModel for AboutPart of SettingsPage View
    /// </summary>
    public class SettingsAboutPartViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the App Logo
        /// </summary>
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        /// <summary>
        /// Gets the App DisplayName
        /// </summary>
        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        /// <summary>
        /// Gets the App Publisher
        /// </summary>
        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        /// <summary>
        /// Gets the App Version
        /// </summary>
        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        /// <summary>
        /// Gets the App RateMe Uri
        /// </summary>
        public Uri RateMe => new Uri("http://aka.ms/template10");
    }
}