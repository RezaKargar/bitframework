﻿using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Bit.Client.Web.BlazorUI.Playground.Web
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
