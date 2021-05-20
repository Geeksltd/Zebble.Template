using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    public partial class LogoutConfirmation : ModalScreen
    {
        public async Task OnLogoutTapped()
        {
            await Current.Delete();
            DisposeCache();
            Go<Login>();
        }

        public void OnCancelTapped() => HidePopUp();

        partial void DisposeCache();
    }
}
