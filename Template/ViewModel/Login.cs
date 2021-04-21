using Domain;
using Olive;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace ViewModel
{
	public class Login : FullScreen
	{
		public Bindable<string> Email = new();
		public Bindable<string> Password = new();

		public async Task OnLoginTapped()
		{
			if (Email.Value.IsEmpty())
			{
				ShowPopUp<WarningAlert>(x => x.Message.Value = "Please enter the email you used to register.");
				return;
			}
			if (!Email.Value.IsValidEmailAddress())
			{
				ShowPopUp<WarningAlert>(x => x.Message.Value = "Please enter the email you used to register.");
				return;
			}

			if (Password.Value.IsEmpty())
			{
				ShowPopUp<WarningAlert>(x => x.Message.Value = "Please enter the email you used to register.");
				return;
			}

		}
	}
}
