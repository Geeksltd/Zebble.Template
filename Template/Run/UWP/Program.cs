﻿namespace UWP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        public static void Main()
        {
            Zebble.UIRuntime.GetEntryAssembly = () => typeof(Program).GetAssembly();

            Windows.UI.Xaml.Application.Start((p) => new App());
        }
    }
}