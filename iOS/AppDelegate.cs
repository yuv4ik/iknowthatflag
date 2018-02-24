﻿using Foundation;
using IKnowThatFlag.iOS.Services;
using UIKit;

namespace IKnowThatFlag.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App(new IocModule()));

            return base.FinishedLaunching(app, options);
        }
    }
}
