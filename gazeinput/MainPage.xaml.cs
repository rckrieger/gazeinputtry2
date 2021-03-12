//  ---------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using System;
using Windows.Devices.Input.Preview;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.Foundation;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Drawing;
using Windows.UI.Xaml.Shapes;

namespace gazeinput
{
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Reference to the user's eyes and head as detected
        /// by the eye-tracking device.
        /// </summary>
        private GazeInputSourcePreview gazeInputSource;

        /// <summary>
        /// Dynamic store of eye-tracking devices.
        /// </summary>
        /// <remarks>
        /// Receives event notifications when a device is added, removed, 
        /// or updated after the initial enumeration.
        /// </remarks>
        private GazeDeviceWatcherPreview gazeDeviceWatcher;

        /// <summary>
        /// Eye-tracking device counter.
        /// </summary>
        private int deviceCounter = 0;

        private Dictionary<string, Windows.UI.Xaml.Shapes.Rectangle> hashtable = new Dictionary<string, Windows.UI.Xaml.Shapes.Rectangle> ();


        /// <summary>
        /// Timer for gaze focus on RadialProgressBar.
        /// </summary>
        DispatcherTimer timerGaze = new DispatcherTimer();

        /// <summary>
        /// Tracker used to prevent gaze timer restarts.
        /// </summary>
        bool timerStarted = false;

        /// <summary>
        /// Initialize the app.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            hashtable.Add("rect0_0", rect0_0);
            hashtable.Add("rect0_1", rect0_1);
            hashtable.Add("rect0_2", rect0_2);
            hashtable.Add("rect0_3", rect0_3);
            hashtable.Add("rect0_4", rect0_4);
            hashtable.Add("rect0_5", rect0_5);
            hashtable.Add("rect0_6", rect0_6);
            hashtable.Add("rect0_7", rect0_7);
            hashtable.Add("rect0_8", rect0_8);
            hashtable.Add("rect0_9", rect0_9);
            hashtable.Add("rect0_10", rect0_10);
            hashtable.Add("rect0_11", rect0_11);
            hashtable.Add("rect0_12", rect0_12);
            hashtable.Add("rect0_13", rect0_13);
            hashtable.Add("rect0_14", rect0_14);
            hashtable.Add("rect0_15", rect0_15);
            hashtable.Add("rect0_16", rect0_16);
            hashtable.Add("rect0_17", rect0_17);
            hashtable.Add("rect0_18", rect0_18);
            hashtable.Add("rect0_19", rect0_19);
            hashtable.Add("rect0_20", rect0_20);
            hashtable.Add("rect0_21", rect0_21);
            hashtable.Add("rect0_22", rect0_22);
            hashtable.Add("rect0_23", rect0_23);
            hashtable.Add("rect0_24", rect0_24);
            hashtable.Add("rect0_25", rect0_25);

            hashtable.Add("rect1_0", rect1_0);
            hashtable.Add("rect1_1", rect1_1);
            hashtable.Add("rect1_2", rect1_2);
            hashtable.Add("rect1_3", rect1_3);
            hashtable.Add("rect1_4", rect1_4);
            hashtable.Add("rect1_5", rect1_5);
            hashtable.Add("rect1_6", rect1_6);
            hashtable.Add("rect1_7", rect1_7);
            hashtable.Add("rect1_8", rect1_8);
            hashtable.Add("rect1_9", rect1_9);
            hashtable.Add("rect1_10", rect1_10);
            hashtable.Add("rect1_11", rect1_11);
            hashtable.Add("rect1_12", rect1_12);
            hashtable.Add("rect1_13", rect1_13);
            hashtable.Add("rect1_14", rect1_14);
            hashtable.Add("rect1_15", rect1_15);
            hashtable.Add("rect1_16", rect1_16);
            hashtable.Add("rect1_17", rect1_17);
            hashtable.Add("rect1_18", rect1_18);
            hashtable.Add("rect1_19", rect1_19);
            hashtable.Add("rect1_20", rect1_20);
            hashtable.Add("rect1_21", rect1_21);
            hashtable.Add("rect1_22", rect1_22);
            hashtable.Add("rect1_23", rect1_23);
            hashtable.Add("rect1_24", rect1_24);
            hashtable.Add("rect1_25", rect1_25);

            hashtable.Add("rect2_0", rect2_0);
            hashtable.Add("rect2_1", rect2_1);
            hashtable.Add("rect2_2", rect2_2);
            hashtable.Add("rect2_3", rect2_3);
            hashtable.Add("rect2_4", rect2_4);
            hashtable.Add("rect2_5", rect2_5);
            hashtable.Add("rect2_6", rect2_6);
            hashtable.Add("rect2_7", rect2_7);
            hashtable.Add("rect2_8", rect2_8);
            hashtable.Add("rect2_9", rect2_9);
            hashtable.Add("rect2_10", rect2_10);
            hashtable.Add("rect2_11", rect2_11);
            hashtable.Add("rect2_12", rect2_12);
            hashtable.Add("rect2_13", rect2_13);
            hashtable.Add("rect2_14", rect2_14);
            hashtable.Add("rect2_15", rect2_15);
            hashtable.Add("rect2_16", rect2_16);
            hashtable.Add("rect2_17", rect2_17);
            hashtable.Add("rect2_18", rect2_18);
            hashtable.Add("rect2_19", rect2_19);
            hashtable.Add("rect2_20", rect2_20);
            hashtable.Add("rect2_21", rect2_21);
            hashtable.Add("rect2_22", rect2_22);
            hashtable.Add("rect2_23", rect2_23);
            hashtable.Add("rect2_24", rect2_24);
            hashtable.Add("rect2_25", rect2_25);

            hashtable.Add("rect3_0", rect3_0);
            hashtable.Add("rect3_1", rect3_1);
            hashtable.Add("rect3_2", rect3_2);
            hashtable.Add("rect3_3", rect3_3);
            hashtable.Add("rect3_4", rect3_4);
            hashtable.Add("rect3_5", rect3_5);
            hashtable.Add("rect3_6", rect3_6);
            hashtable.Add("rect3_7", rect3_7);
            hashtable.Add("rect3_8", rect3_8);
            hashtable.Add("rect3_9", rect3_9);
            hashtable.Add("rect3_10", rect3_10);
            hashtable.Add("rect3_11", rect3_11);
            hashtable.Add("rect3_12", rect3_12);
            hashtable.Add("rect3_13", rect3_13);
            hashtable.Add("rect3_14", rect3_14);
            hashtable.Add("rect3_15", rect3_15);
            hashtable.Add("rect3_16", rect3_16);
            hashtable.Add("rect3_17", rect3_17);
            hashtable.Add("rect3_18", rect3_18);
            hashtable.Add("rect3_19", rect3_19);
            hashtable.Add("rect3_20", rect3_20);
            hashtable.Add("rect3_21", rect3_21);
            hashtable.Add("rect3_22", rect3_22);
            hashtable.Add("rect3_23", rect3_23);
            hashtable.Add("rect3_24", rect3_24);
            hashtable.Add("rect3_25", rect3_25);

            hashtable.Add("rect4_0", rect4_0);
            hashtable.Add("rect4_1", rect4_1);
            hashtable.Add("rect4_2", rect4_2);
            hashtable.Add("rect4_3", rect4_3);
            hashtable.Add("rect4_4", rect4_4);
            hashtable.Add("rect4_5", rect4_5);
            hashtable.Add("rect4_6", rect4_6);
            hashtable.Add("rect4_7", rect4_7);
            hashtable.Add("rect4_8", rect4_8);
            hashtable.Add("rect4_9", rect4_9);
            hashtable.Add("rect4_10", rect4_10);
            hashtable.Add("rect4_11", rect4_11);
            hashtable.Add("rect4_12", rect4_12);
            hashtable.Add("rect4_13", rect4_13);
            hashtable.Add("rect4_14", rect4_14);
            hashtable.Add("rect4_15", rect4_15);
            hashtable.Add("rect4_16", rect4_16);
            hashtable.Add("rect4_17", rect4_17);
            hashtable.Add("rect4_18", rect4_18);
            hashtable.Add("rect4_19", rect4_19);
            hashtable.Add("rect4_20", rect4_20);
            hashtable.Add("rect4_21", rect4_21);
            hashtable.Add("rect4_22", rect4_22);
            hashtable.Add("rect4_23", rect4_23);
            hashtable.Add("rect4_24", rect4_24);
            hashtable.Add("rect4_25", rect4_25);

            hashtable.Add("rect5_0", rect5_0);
            hashtable.Add("rect5_1", rect5_1);
            hashtable.Add("rect5_2", rect5_2);
            hashtable.Add("rect5_3", rect5_3);
            hashtable.Add("rect5_4", rect5_4);
            hashtable.Add("rect5_5", rect5_5);
            hashtable.Add("rect5_6", rect5_6);
            hashtable.Add("rect5_7", rect5_7);
            hashtable.Add("rect5_8", rect5_8);
            hashtable.Add("rect5_9", rect5_9);
            hashtable.Add("rect5_10", rect5_10);
            hashtable.Add("rect5_11", rect5_11);
            hashtable.Add("rect5_12", rect5_12);
            hashtable.Add("rect5_13", rect5_13);
            hashtable.Add("rect5_14", rect5_14);
            hashtable.Add("rect5_15", rect5_15);
            hashtable.Add("rect5_16", rect5_16);
            hashtable.Add("rect5_17", rect5_17);
            hashtable.Add("rect5_18", rect5_18);
            hashtable.Add("rect5_19", rect5_19);
            hashtable.Add("rect5_20", rect5_20);
            hashtable.Add("rect5_21", rect5_21);
            hashtable.Add("rect5_22", rect5_22);
            hashtable.Add("rect5_23", rect5_23);
            hashtable.Add("rect5_24", rect5_24);
            hashtable.Add("rect5_25", rect5_25);


            hashtable.Add("rect6_0", rect6_0);
            hashtable.Add("rect6_1", rect6_1);
            hashtable.Add("rect6_2", rect6_2);
            hashtable.Add("rect6_3", rect6_3);
            hashtable.Add("rect6_4", rect6_4);
            hashtable.Add("rect6_5", rect6_5);
            hashtable.Add("rect6_6", rect6_6);
            hashtable.Add("rect6_7", rect6_7);
            hashtable.Add("rect6_8", rect6_8);
            hashtable.Add("rect6_9", rect6_9);
            hashtable.Add("rect6_10", rect6_10);
            hashtable.Add("rect6_11", rect6_11);
            hashtable.Add("rect6_12", rect6_12);
            hashtable.Add("rect6_13", rect6_13);
            hashtable.Add("rect6_14", rect6_14);
            hashtable.Add("rect6_15", rect6_15);
            hashtable.Add("rect6_16", rect6_16);
            hashtable.Add("rect6_17", rect6_17);
            hashtable.Add("rect6_18", rect6_18);
            hashtable.Add("rect6_19", rect6_19);
            hashtable.Add("rect6_20", rect6_20);
            hashtable.Add("rect6_21", rect6_21);
            hashtable.Add("rect6_22", rect6_22);
            hashtable.Add("rect6_23", rect6_23);
            hashtable.Add("rect6_24", rect6_24);
            hashtable.Add("rect6_25", rect6_25);


            hashtable.Add("rect7_0", rect7_0);
            hashtable.Add("rect7_1", rect7_1);
            hashtable.Add("rect7_2", rect7_2);
            hashtable.Add("rect7_3", rect7_3);
            hashtable.Add("rect7_4", rect7_4);
            hashtable.Add("rect7_5", rect7_5);
            hashtable.Add("rect7_6", rect7_6);
            hashtable.Add("rect7_7", rect7_7);
            hashtable.Add("rect7_8", rect7_8);
            hashtable.Add("rect7_9", rect7_9);
            hashtable.Add("rect7_10", rect7_10);
            hashtable.Add("rect7_11", rect7_11);
            hashtable.Add("rect7_12", rect7_12);
            hashtable.Add("rect7_13", rect7_13);
            hashtable.Add("rect7_14", rect7_14);
            hashtable.Add("rect7_15", rect7_15);
            hashtable.Add("rect7_16", rect7_16);
            hashtable.Add("rect7_17", rect7_17);
            hashtable.Add("rect7_18", rect7_18);
            hashtable.Add("rect7_19", rect7_19);
            hashtable.Add("rect7_20", rect7_20);
            hashtable.Add("rect7_21", rect7_21);
            hashtable.Add("rect7_22", rect7_22);
            hashtable.Add("rect7_23", rect7_23);
            hashtable.Add("rect7_24", rect7_24);
            hashtable.Add("rect7_25", rect7_25);


            hashtable.Add("rect8_0", rect8_0);
            hashtable.Add("rect8_1", rect8_1);
            hashtable.Add("rect8_2", rect8_2);
            hashtable.Add("rect8_3", rect8_3);
            hashtable.Add("rect8_4", rect8_4);
            hashtable.Add("rect8_5", rect8_5);
            hashtable.Add("rect8_6", rect8_6);
            hashtable.Add("rect8_7", rect8_7);
            hashtable.Add("rect8_8", rect8_8);
            hashtable.Add("rect8_9", rect8_9);
            hashtable.Add("rect8_10", rect8_10);
            hashtable.Add("rect8_11", rect8_11);
            hashtable.Add("rect8_12", rect8_12);
            hashtable.Add("rect8_13", rect8_13);
            hashtable.Add("rect8_14", rect8_14);
            hashtable.Add("rect8_15", rect8_15);
            hashtable.Add("rect8_16", rect8_16);
            hashtable.Add("rect8_17", rect8_17);
            hashtable.Add("rect8_18", rect8_18);
            hashtable.Add("rect8_19", rect8_19);
            hashtable.Add("rect8_20", rect8_20);
            hashtable.Add("rect8_21", rect8_21);
            hashtable.Add("rect8_22", rect8_22);
            hashtable.Add("rect8_23", rect8_23);
            hashtable.Add("rect8_24", rect8_24);
            hashtable.Add("rect8_25", rect8_25);


            hashtable.Add("rect9_0", rect9_0);
            hashtable.Add("rect9_1", rect9_1);
            hashtable.Add("rect9_2", rect9_2);
            hashtable.Add("rect9_3", rect9_3);
            hashtable.Add("rect9_4", rect9_4);
            hashtable.Add("rect9_5", rect9_5);
            hashtable.Add("rect9_6", rect9_6);
            hashtable.Add("rect9_7", rect9_7);
            hashtable.Add("rect9_8", rect9_8);
            hashtable.Add("rect9_9", rect9_9);
            hashtable.Add("rect9_10", rect9_10);
            hashtable.Add("rect9_11", rect9_11);
            hashtable.Add("rect9_12", rect9_12);
            hashtable.Add("rect9_13", rect9_13);
            hashtable.Add("rect9_14", rect9_14);
            hashtable.Add("rect9_15", rect9_15);
            hashtable.Add("rect9_16", rect9_16);
            hashtable.Add("rect9_17", rect9_17);
            hashtable.Add("rect9_18", rect9_18);
            hashtable.Add("rect9_19", rect9_19);
            hashtable.Add("rect9_20", rect9_20);
            hashtable.Add("rect9_21", rect9_21);
            hashtable.Add("rect9_22", rect9_22);
            hashtable.Add("rect9_23", rect9_23);
            hashtable.Add("rect9_24", rect9_24);
            hashtable.Add("rect9_25", rect9_25);

            hashtable.Add("rect10_0", rect10_0);
            hashtable.Add("rect10_1", rect10_1);
            hashtable.Add("rect10_2", rect10_2);
            hashtable.Add("rect10_3", rect10_3);
            hashtable.Add("rect10_4", rect10_4);
            hashtable.Add("rect10_5", rect10_5);
            hashtable.Add("rect10_6", rect10_6);
            hashtable.Add("rect10_7", rect10_7);
            hashtable.Add("rect10_8", rect10_8);
            hashtable.Add("rect10_9", rect10_9);
            hashtable.Add("rect10_10", rect10_10);
            hashtable.Add("rect10_11", rect10_11);
            hashtable.Add("rect10_12", rect10_12);
            hashtable.Add("rect10_13", rect10_13);
            hashtable.Add("rect10_14", rect10_14);
            hashtable.Add("rect10_15", rect10_15);
            hashtable.Add("rect10_16", rect10_16);
            hashtable.Add("rect10_17", rect10_17);
            hashtable.Add("rect10_18", rect10_18);
            hashtable.Add("rect10_19", rect10_19);
            hashtable.Add("rect10_20", rect10_20);
            hashtable.Add("rect10_21", rect10_21);
            hashtable.Add("rect10_22", rect10_22);
            hashtable.Add("rect10_23", rect10_23);
            hashtable.Add("rect10_24", rect10_24);
            hashtable.Add("rect10_25", rect10_25);

            hashtable.Add("rect11_0", rect11_0);
            hashtable.Add("rect11_1", rect11_1);
            hashtable.Add("rect11_2", rect11_2);
            hashtable.Add("rect11_3", rect11_3);
            hashtable.Add("rect11_4", rect11_4);
            hashtable.Add("rect11_5", rect11_5);
            hashtable.Add("rect11_6", rect11_6);
            hashtable.Add("rect11_7", rect11_7);
            hashtable.Add("rect11_8", rect11_8);
            hashtable.Add("rect11_9", rect11_9);
            hashtable.Add("rect11_10", rect11_10);
            hashtable.Add("rect11_11", rect11_11);
            hashtable.Add("rect11_12", rect11_12);
            hashtable.Add("rect11_13", rect11_13);
            hashtable.Add("rect11_14", rect11_14);
            hashtable.Add("rect11_15", rect11_15);
            hashtable.Add("rect11_16", rect11_16);
            hashtable.Add("rect11_17", rect11_17);
            hashtable.Add("rect11_18", rect11_18);
            hashtable.Add("rect11_19", rect11_19);
            hashtable.Add("rect11_20", rect11_20);
            hashtable.Add("rect11_21", rect11_21);
            hashtable.Add("rect11_22", rect11_22);
            hashtable.Add("rect11_23", rect11_23);
            hashtable.Add("rect11_24", rect11_24);
            hashtable.Add("rect11_25", rect11_25);

            hashtable.Add("rect12_0", rect12_0);
            hashtable.Add("rect12_1", rect12_1);
            hashtable.Add("rect12_2", rect12_2);
            hashtable.Add("rect12_3", rect12_3);
            hashtable.Add("rect12_4", rect12_4);
            hashtable.Add("rect12_5", rect12_5);
            hashtable.Add("rect12_6", rect12_6);
            hashtable.Add("rect12_7", rect12_7);
            hashtable.Add("rect12_8", rect12_8);
            hashtable.Add("rect12_9", rect12_9);
            hashtable.Add("rect12_10", rect12_10);
            hashtable.Add("rect12_11", rect12_11);
            hashtable.Add("rect12_12", rect12_12);
            hashtable.Add("rect12_13", rect12_13);
            hashtable.Add("rect12_14", rect12_14);
            hashtable.Add("rect12_15", rect12_15);
            hashtable.Add("rect12_16", rect12_16);
            hashtable.Add("rect12_17", rect12_17);
            hashtable.Add("rect12_18", rect12_18);
            hashtable.Add("rect12_19", rect12_19);
            hashtable.Add("rect12_20", rect12_20);
            hashtable.Add("rect12_21", rect12_21);
            hashtable.Add("rect12_22", rect12_22);
            hashtable.Add("rect12_23", rect12_23);
            hashtable.Add("rect12_24", rect12_24);
            hashtable.Add("rect12_25", rect12_25);

            hashtable.Add("rect13_0", rect13_0);
            hashtable.Add("rect13_1", rect13_1);
            hashtable.Add("rect13_2", rect13_2);
            hashtable.Add("rect13_3", rect13_3);
            hashtable.Add("rect13_4", rect13_4);
            hashtable.Add("rect13_5", rect13_5);
            hashtable.Add("rect13_6", rect13_6);
            hashtable.Add("rect13_7", rect13_7);
            hashtable.Add("rect13_8", rect13_8);
            hashtable.Add("rect13_9", rect13_9);
            hashtable.Add("rect13_10", rect13_10);
            hashtable.Add("rect13_11", rect13_11);
            hashtable.Add("rect13_12", rect13_12);
            hashtable.Add("rect13_13", rect13_13);
            hashtable.Add("rect13_14", rect13_14);
            hashtable.Add("rect13_15", rect13_15);
            hashtable.Add("rect13_16", rect13_16);
            hashtable.Add("rect13_17", rect13_17);
            hashtable.Add("rect13_18", rect13_18);
            hashtable.Add("rect13_19", rect13_19);
            hashtable.Add("rect13_20", rect13_20);
            hashtable.Add("rect13_21", rect13_21);
            hashtable.Add("rect13_22", rect13_22);
            hashtable.Add("rect13_23", rect13_23);
            hashtable.Add("rect13_24", rect13_24);
            hashtable.Add("rect13_25", rect13_25);

            hashtable.Add("rect14_0", rect14_0);
            hashtable.Add("rect14_1", rect14_1);
            hashtable.Add("rect14_2", rect14_2);
            hashtable.Add("rect14_3", rect14_3);
            hashtable.Add("rect14_4", rect14_4);
            hashtable.Add("rect14_5", rect14_5);
            hashtable.Add("rect14_6", rect14_6);
            hashtable.Add("rect14_7", rect14_7);
            hashtable.Add("rect14_8", rect14_8);
            hashtable.Add("rect14_9", rect14_9);
            hashtable.Add("rect14_10", rect14_10);
            hashtable.Add("rect14_11", rect14_11);
            hashtable.Add("rect14_12", rect14_12);
            hashtable.Add("rect14_13", rect14_13);
            hashtable.Add("rect14_14", rect14_14);
            hashtable.Add("rect14_15", rect14_15);
            hashtable.Add("rect14_16", rect14_16);
            hashtable.Add("rect14_17", rect14_17);
            hashtable.Add("rect14_18", rect14_18);
            hashtable.Add("rect14_19", rect14_19);
            hashtable.Add("rect14_20", rect14_20);
            hashtable.Add("rect14_21", rect14_21);
            hashtable.Add("rect14_22", rect14_22);
            hashtable.Add("rect14_23", rect14_23);
            hashtable.Add("rect14_24", rect14_24);
            hashtable.Add("rect14_25", rect14_25);
        }

        /// <summary>
        /// Override of OnNavigatedTo page event starts GazeDeviceWatcher.
        /// </summary>
        /// <param name="e">Event args for the NavigatedTo event</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Start listening for device events on navigation to eye-tracking page.
            StartGazeDeviceWatcher();
        }

        /// <summary>
        /// Override of OnNavigatedFrom page event stops GazeDeviceWatcher.
        /// </summary>
        /// <param name="e">Event args for the NavigatedFrom event</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Stop listening for device events on navigation from eye-tracking page.
            StopGazeDeviceWatcher();
        }

        /// <summary>
        /// Tick handler for gaze focus timer.
        /// </summary>
        /// <param name="sender">Source of the gaze entered event</param>
        /// <param name="e">Event args for the gaze entered event</param>
        private void TimerGaze_Tick(object sender, object e)
        {
            // Increment progress bar.
            GazeRadialProgressBar.Value += 1;


        }

        /// <summary>
        /// Set/reset the screen location of the progress bar.
        /// </summary>
        private void SetGazeTargetLocation()
        {
            // Ensure the gaze timer restarts on new progress bar location.
            timerGaze.Stop();
            timerStarted = false;

            // Get the bounding rectangle of the app window.
            Rect appBounds = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds;

            // Translate transform for moving progress bar.
            TranslateTransform translateTarget = new TranslateTransform();

            // Calculate random location within gaze canvas.
            Random random = new Random();
            int randomX = 
                random.Next(
                    0, 
                    (int)appBounds.Width - (int)GazeRadialProgressBar.Width);
            int randomY = 
                random.Next(
                    0, 
                    (int)appBounds.Height - (int)GazeRadialProgressBar.Height - (int)Header.ActualHeight);

            translateTarget.X = 0;
            translateTarget.Y = 0;

            GazeRadialProgressBar.RenderTransform = translateTarget;

            // Show progress bar.
            GazeRadialProgressBar.Visibility = Visibility.Visible;
            GazeRadialProgressBar.Value = 0;
        }

        /// <summary>
        /// GazeEntered handler.
        /// </summary>
        /// <param name="sender">Source of the gaze entered event</param>
        /// <param name="e">Event args for the gaze entered event</param>
        private void GazeEntered(
            GazeInputSourcePreview sender, 
            GazeEnteredPreviewEventArgs args)
        {
            // Show ellipse representing gaze point.
            eyeGazePositionEllipse.Visibility = Visibility.Visible;

            // Mark the event handled.
            args.Handled = true;
        }

        /// <summary>
        /// GazeExited handler.
        /// Call DisplayRequest.RequestRelease to conclude the 
        /// RequestActive called in GazeEntered.
        /// </summary>
        /// <param name="sender">Source of the gaze exited event</param>
        /// <param name="e">Event args for the gaze exited event</param>
        private void GazeExited(
            GazeInputSourcePreview sender, 
            GazeExitedPreviewEventArgs args)
        {
            // Hide gaze tracking ellipse.
            eyeGazePositionEllipse.Visibility = Visibility.Collapsed;

            // Mark the event handled.
            args.Handled = true;
        }

        /// <summary>
        /// GazeMoved handler translates the ellipse on the canvas to reflect gaze point.
        /// </summary>
        /// <param name="sender">Source of the gaze moved event</param>
        /// <param name="e">Event args for the gaze moved event</param>
        private void GazeMoved(GazeInputSourcePreview sender, GazeMovedPreviewEventArgs args)
        {
            // Update the position of the ellipse corresponding to gaze point.
            if (args.CurrentPoint.EyeGazePosition != null)
            {
                double gazePointX = args.CurrentPoint.EyeGazePosition.Value.X;
                double gazePointY = args.CurrentPoint.EyeGazePosition.Value.Y;

                double ellipseLeft = 
                    gazePointX - 
                    (eyeGazePositionEllipse.Width / 2.0f);
                double ellipseTop = 
                    gazePointY - 
                    (eyeGazePositionEllipse.Height / 2.0f) - 
                    (int)Header.ActualHeight;

                // Translate transform for moving gaze ellipse.
                TranslateTransform translateEllipse = new TranslateTransform
                {
                    X = ellipseLeft,
                    Y = ellipseTop
                };

                eyeGazePositionEllipse.RenderTransform = translateEllipse;

                // The gaze point screen location.
                Windows.Foundation.Point gazePoint = new Windows.Foundation.Point(gazePointX, gazePointY);
                
                int rectx = ((int) gazePointX) / 100;
                int recty = (((int)gazePointY) / 25)-4;
                string rectname = "rect" + rectx.ToString()+ "_" + recty.ToString();
                try
                {
                    Windows.UI.Xaml.Shapes.Rectangle ele = hashtable[rectname];
                    // Basic hit test to determine if gaze point is on progress bar.   
                    ele.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    

                }
                catch (Exception e)
                {
                    Console.WriteLine("IOException source: {0}, rectname {1}", e.Source, rectname);
                }



                // Mark the event handled.
                args.Handled = true;
            }
        }

        /// <summary>
        /// Return whether the gaze point is over the progress bar.
        /// </summary>
        /// <param name="gazePoint">The gaze point screen location</param>
        /// <param name="elementName">The progress bar name</param>
        /// <param name="uiElement">The progress bar UI element</param>
        /// <returns></returns>
        private bool DoesElementContainPoint(
            Windows.Foundation.Point gazePoint, string elementName, UIElement uiElement)
        {
            // Use entire visual tree of progress bar.
            IEnumerable<UIElement> elementStack = 
              VisualTreeHelper.FindElementsInHostCoordinates(gazePoint, uiElement, true);
            foreach (UIElement item in elementStack)
            {
                //Cast to FrameworkElement and get element name.
                if (item is FrameworkElement feItem)
                {
                    if (feItem.Name.Equals(elementName))
                    {
                        if (!timerStarted)
                        {
                            // Start gaze timer if gaze over element.
                            timerGaze.Start();
                            timerStarted = true;
                        }
                        return true;
                    }
                }
            }

            // Stop gaze timer and reset progress bar if gaze leaves element.
            timerGaze.Stop();
            GazeRadialProgressBar.Value = 0;
            timerStarted = false;
            return false;
        }

        /// <summary>
        /// Start gaze watcher and declare watcher event handlers.
        /// </summary>
        private void StartGazeDeviceWatcher()
        {
            if (gazeDeviceWatcher == null)
            {
                gazeDeviceWatcher = GazeInputSourcePreview.CreateWatcher();
                gazeDeviceWatcher.Added += this.DeviceAdded;
                gazeDeviceWatcher.Updated += this.DeviceUpdated;
                gazeDeviceWatcher.Removed += this.DeviceRemoved;
                gazeDeviceWatcher.Start();
            }
        }

        /// <summary>
        /// Shut down gaze watcher and stop listening for events.
        /// </summary>
        private void StopGazeDeviceWatcher()
        {
            if (gazeDeviceWatcher != null)
            {
                gazeDeviceWatcher.Stop();
                gazeDeviceWatcher.Added -= this.DeviceAdded;
                gazeDeviceWatcher.Updated -= this.DeviceUpdated;
                gazeDeviceWatcher.Removed -= this.DeviceRemoved;
                gazeDeviceWatcher = null;
            }
        }

        /// <summary>
        /// Eye-tracking device connected (added, or available when watcher is initialized).
        /// </summary>
        /// <param name="sender">Source of the device added event</param>
        /// <param name="e">Event args for the device added event</param>
        private void DeviceAdded(GazeDeviceWatcherPreview source, 
            GazeDeviceWatcherAddedPreviewEventArgs args)
        {
            if (IsSupportedDevice(args.Device))
            {
                deviceCounter++;
                TrackerCounter.Text = deviceCounter.ToString();
            }
            // Set up gaze tracking.
            TryEnableGazeTrackingAsync(args.Device);
        }

        /// <summary>
        /// Initial device state might be uncalibrated, 
        /// but device was subsequently calibrated.
        /// </summary>
        /// <param name="sender">Source of the device updated event</param>
        /// <param name="e">Event args for the device updated event</param>
        private void DeviceUpdated(GazeDeviceWatcherPreview source,
            GazeDeviceWatcherUpdatedPreviewEventArgs args)
        {
            // Set up gaze tracking.
            TryEnableGazeTrackingAsync(args.Device);
        }

        /// <summary>
        /// Handles disconnection of eye-tracking devices.
        /// </summary>
        /// <param name="sender">Source of the device removed event</param>
        /// <param name="e">Event args for the device removed event</param>
        private void DeviceRemoved(GazeDeviceWatcherPreview source,
            GazeDeviceWatcherRemovedPreviewEventArgs args)
        {
            // Decrement gaze device counter and remove event handlers.
            if (IsSupportedDevice(args.Device))
            {
                deviceCounter--;
                TrackerCounter.Text = deviceCounter.ToString();

                if (deviceCounter == 0)
                {
                    gazeInputSource.GazeEntered -= this.GazeEntered;
                    gazeInputSource.GazeMoved -= this.GazeMoved;
                    gazeInputSource.GazeExited -= this.GazeExited;
                }
            }
        }

        /// <summary>
        /// Initialize gaze tracking.
        /// </summary>
        /// <param name="gazeDevice"></param>
        private async void TryEnableGazeTrackingAsync(GazeDevicePreview gazeDevice)
        {
            // If eye-tracking device is ready, declare event handlers and start tracking.
            if (IsSupportedDevice(gazeDevice))
            {
                timerGaze.Interval = new TimeSpan(0, 0, 0, 0, 20);
                timerGaze.Tick += TimerGaze_Tick;


                // This must be called from the UI thread.
                gazeInputSource = GazeInputSourcePreview.GetForCurrentView();

                gazeInputSource.GazeEntered += GazeEntered;
                gazeInputSource.GazeMoved += GazeMoved;
                gazeInputSource.GazeExited += GazeExited;
            }
            // Notify if device calibration required.
            else if (gazeDevice.ConfigurationState ==
                     GazeDeviceConfigurationStatePreview.UserCalibrationNeeded ||
                     gazeDevice.ConfigurationState ==
                     GazeDeviceConfigurationStatePreview.ScreenSetupNeeded)
            {
                // Device isn't calibrated, so invoke the calibration handler.
                System.Diagnostics.Debug.WriteLine(
                    "Your device needs to calibrate. Please wait for it to finish.");
                await gazeDevice.RequestCalibrationAsync();
            }
            // Notify if device calibration underway.
            else if (gazeDevice.ConfigurationState == 
                GazeDeviceConfigurationStatePreview.Configuring)
            {
                // Device is currently undergoing calibration.  
                // A device update is sent when calibration complete.
                System.Diagnostics.Debug.WriteLine(
                    "Your device is being configured. Please wait for it to finish"); 
            }
            // Device is not viable.
            else if (gazeDevice.ConfigurationState == GazeDeviceConfigurationStatePreview.Unknown)
            {
                // Notify if device is in unknown state.  
                // Reconfigure/recalbirate the device.  
                System.Diagnostics.Debug.WriteLine(
                    "Your device is not ready. Please set up your device or reconfigure it."); 
            }
        }

        /// <summary>
        /// Check if eye-tracking device is viable.
        /// </summary>
        /// <param name="gazeDevice">Reference to eye-tracking device.</param>
        /// <returns>True, if device is viable; otherwise, false.</returns>
        private bool IsSupportedDevice(GazeDevicePreview gazeDevice)
        {
            TrackerState.Text = gazeDevice.ConfigurationState.ToString();
            return (gazeDevice.CanTrackEyes &&
                     gazeDevice.ConfigurationState == 
                     GazeDeviceConfigurationStatePreview.Ready);
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
