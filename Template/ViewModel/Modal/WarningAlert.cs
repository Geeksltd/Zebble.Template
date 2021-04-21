using Olive;
using System;
using System.Collections.Generic;
using System.Text;
using Zebble.Mvvm;

namespace ViewModel
{
	public class WarningAlert : ModalScreen
	{
		public Bindable<string> Message = new();

		public void OnOkTapped() => HidePopUp();
	}
}
