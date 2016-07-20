// <copyright file="SettingsPageViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Windows.UI.Xaml;

    /// <summary>
    /// A ViewModel for the SettingsPage View
    /// </summary>
    public class SettingsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the SettingsPart View Model
        /// </summary>
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();

        /// <summary>
        /// Gets the AboutPart View Model
        /// </summary>
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }
}