// <copyright file="ViewModelLocator.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.ViewModels
{
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// A ViewModel locator class fro Dependency Injection pattern
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelLocator"/> class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => GalaSoft.MvvmLight.Ioc.SimpleIoc.Default);

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // Design Time
            }
            else
            {
                // Runtime
            }

            // TODO: Register
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<MainPageViewModel>();
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<SettingsPageViewModel>();
        }

        // TODO: properties for ViewModel strongly type binding

        /// <summary>
        /// Gets the registered MainPage ViewModel
        /// </summary>
        public MainPageViewModel MainPageViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();

        /// <summary>
        /// Gets the registered SettingsPage ViewModel
        /// </summary>
        public SettingsPageViewModel SettingsPageViewModel => ServiceLocator.Current.GetInstance<SettingsPageViewModel>();
    }
}