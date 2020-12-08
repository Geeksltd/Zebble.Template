using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    class MainMenu : Zebble.Mvvm.ViewModel
    {
        public event Action Actioned;

        public void TapItem1()
        {
            Dialog.Alert("Hi!");
            Actioned?.Invoke();
        }
    }
}
