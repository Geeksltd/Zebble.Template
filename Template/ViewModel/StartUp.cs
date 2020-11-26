using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    // TODO: Learn: https://zebble.net/docs/introduction

    class StartUp
    {
        public static Task Run()
        {
            // TODO: Any required init
            Zebble.Mvvm.ViewModel.Go<WelcomePage>();
            return Task.CompletedTask;
        }
    }
}
