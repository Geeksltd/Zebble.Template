using System;
using Zebble;
using System.Collections.Generic;
using System.Text;
using Zebble.Mvvm;
using System.Threading.Tasks;
using ViewModel;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace App.Tests
{
    class LoginTest : TestScript
    {
        protected override async Task Execute()
        {
            await On<LandingPage>().onLogInTapped();
            await On<Login>().OnLoginTapped();
            On<WarningAlert>().OnOkTapped();
            On<Login>().Email.Set("test");
            await On<Login>().OnLoginTapped();
            On<WarningAlert>().OnOkTapped();
            On<Login>().Email.Set("test@geeks.ltd.uk");
            await On<Login>().OnLoginTapped();
            On<WarningAlert>().OnOkTapped();
            On<Login>().Email.Set("test@geeks.ltd.uk");
            On<Login>().Password.Set("123@qwE");
            await On<Login>().OnLoginTapped();
            Expect("Categories");



        }
    }
}
