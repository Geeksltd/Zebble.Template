using System;
using System.Collections.Generic;
using System.Text;
using Zebble.Mvvm;

namespace ViewModel
{
    public class Settings : FullScreen
    {
        public void OnLogOutTapped() => ShowPopUp<LogoutConfirmation>();

    }
}
