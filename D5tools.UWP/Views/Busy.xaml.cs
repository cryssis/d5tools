// <copyright file="Busy.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.Views
{
    using Template10.Common;
    using Template10.Controls;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// The Busy User Control
    /// </summary>
    public sealed partial class Busy : UserControl
    {
        /// <summary>
        /// The BusyText property of the XAML UserControl
        /// </summary>
        public static readonly DependencyProperty BusyTextProperty =
    DependencyProperty.Register(nameof(BusyText), typeof(string), typeof(Busy), new PropertyMetadata("Please wait..."));

        /// <summary>
        /// The IsBusy property of the XAML UserControl
        /// </summary>
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register(nameof(IsBusy), typeof(bool), typeof(Busy), new PropertyMetadata(false));

        /// <summary>
        /// Initializes a new instance of the <see cref="Busy"/> class.
        /// </summary>
        public Busy()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the text to be shown
        /// </summary>
        public string BusyText
        {
            get { return (string)this.GetValue(BusyTextProperty); }
            set { this.SetValue(BusyTextProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the IsBusy state
        /// </summary>
        public bool IsBusy
        {
            get { return (bool)this.GetValue(IsBusyProperty); }
            set { this.SetValue(IsBusyProperty, value); }
        }

        /// <summary>
        /// Hide and shows the Busy dialog
        /// </summary>
        /// <param name="busy">The dialog is shown</param>
        /// <param name="text">The text to be show on the dialog</param>
        public static void SetBusy(bool busy, string text = null)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                var view = modal.ModalContent as Busy;
                if (view == null)
                {
                    modal.ModalContent = view = new Busy();
                }

                modal.IsModal = view.IsBusy = busy;
                view.BusyText = text;
            });
        }
    }
}