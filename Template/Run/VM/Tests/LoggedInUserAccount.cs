using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace App.Tests
{
    abstract class LoggedInUserAccount : TestScript
    {
        protected override async Task SetUp()
        {
            await base.SetUp();

            await Run<LoginTest>();
        }
    }
}
