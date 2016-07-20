// <copyright file="Splash.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace D5tools.UWP.Views
{
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// The Splash UserControl for Extended SplashScreen
    /// </summary>
    public sealed partial class Splash : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Splash"/> class.
        /// </summary>
        /// <param name="splashScreen">The SplashScreen of the App to be imitated</param>
        public Splash(SplashScreen splashScreen)
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += (s, e) => this.Resize(splashScreen);
            this.Resize(splashScreen);
        }

        /// <summary>
        /// Resizes the control to imitate the designed SplashScreen
        /// </summary>
        /// <param name="splashScreen">The splash screen to be imitated</param>
        private void Resize(SplashScreen splashScreen)
        {
            if (splashScreen.ImageLocation.Top == 0)
            {
                this.splashImage.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                this.rootCanvas.Background = null;
                this.splashImage.Visibility = Visibility.Visible;
            }

            this.splashImage.Height = splashScreen.ImageLocation.Height;
            this.splashImage.Width = splashScreen.ImageLocation.Width;
            this.splashImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
            this.splashImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
            this.ProgressTransform.TranslateY = this.splashImage.Height / 2;
        }
    }
}