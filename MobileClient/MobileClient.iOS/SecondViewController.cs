﻿using System;
using UIKit;
using Microsoft.AppCenter;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;

namespace MobileClient
{
    public partial class SecondViewController : UIViewController
    {
        protected SecondViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            AppCenterLog.Verbose("TabLocation", "I swapped to the second tab!");

            base.ViewDidLoad();

            LoginButton.TouchUpInside += LoginButton_TouchUpInside;
            CallApiButton.TouchUpInside += CallApiButton_TouchUpInside;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        async void LoginButton_TouchUpInside(object sender, EventArgs e)
        {
            await Task.CompletedTask;
        }

        async void CallApiButton_TouchUpInside(object sender, EventArgs e)
        {
            await Task.CompletedTask;
        }

        partial void LogoutButton_TouchUpInside(UIButton sender)
        {
            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

            var mainStoryboard = appDelegate.MainStoryboard;

            var loginPageViewController = appDelegate.GetViewController(mainStoryboard, "LoginPageViewController") as LoginPageViewController;

            // purge account
            NSUserDefaults.StandardUserDefaults.SetString("", "Username");
            NSUserDefaults.StandardUserDefaults.SetString("", "AccessToken");
            NSUserDefaults.StandardUserDefaults.SetString("", "TokenType");
            NSUserDefaults.StandardUserDefaults.SetString("", "RefreshToken");
            NSUserDefaults.StandardUserDefaults.SetString("", "ExpiresIn");
            NSUserDefaults.StandardUserDefaults.SetString("", "ExpirationDate");

            appDelegate.SetRootViewController(loginPageViewController, true);
        }
    }
}
