// <copyright file="ViewModelBase.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.UI.Xaml.Navigation;

namespace D5tools.UWP.Mvvm
{
    /// <summary>
    /// A ViewModelBase derived from GalaSoft ViewModelBase and using the NavigationService from Template 10
    /// </summary>
    public class ViewModelBase
        : GalaSoft.MvvmLight.ViewModelBase,
        Template10.Services.NavigationService.INavigable
    {
        /// <inheritdoc/>
        [JsonIgnore]
        public Template10.Services.NavigationService.INavigationService NavigationService { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public Template10.Common.IDispatcherWrapper Dispatcher { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public Template10.Common.IStateItems SessionState { get; set; }

        /// <inheritdoc/>
        public virtual Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public virtual Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public virtual Task OnNavigatingFromAsync(Template10.Services.NavigationService.NavigatingEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}