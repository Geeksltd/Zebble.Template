using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace ViewModel
{
    public class DeleteContactConfirmation : ModalScreen<Contact>
    {
        public Guid id => Source.Get(x => x.Id);

        public async Task OnConfirmTapped()
        {
            try
            {
                bool result = await Api.Contact.DeleteContact(id);
                HidePopUp();

                if (result)
                {
                    Go<Contacts>();

                    ShowPopUp<SuccessAlert>(x => x.Message.Value = "Your account has been deleted");
                }
                else
                {
                    ShowPopUp<WarningAlert>(x => x.Message.Value = "An error was occured.");
                }
            }
            catch (Exception ex)
            {
                ShowPopUp<WarningAlert>(x => x.Message.Value = ex.Message);
            }
        }

        public void OnCancelTapped() => HidePopUp();
    }
}
