﻿namespace UWP
{
    class Program
    {
        public static void Main()
        {
            Zebble.UIRuntime.GetEntryAssembly = () => typeof(Program).Assembly;
            Zebble.HostInitialization.Initialize();
            Windows.UI.Xaml.Application.Start((p) => new App());
        }
    }
}