// <copyright file="SettingsPageViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.ViewModels
{
    using Template10.Mvvm;

    /// <summary>
    /// A ViewModel for the SettingsPage View
    /// </summary>
    public class SettingsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the SettingsPart View Model
        /// </summary>
        public SettingsGeneralPartViewModel SettingsPartViewModel { get; } = new SettingsGeneralPartViewModel();

        /// <summary>
        /// Gets the AboutPart View Model
        /// </summary>
        public SettingsAboutPartViewModel AboutPartViewModel { get; } = new SettingsAboutPartViewModel();
    }
}