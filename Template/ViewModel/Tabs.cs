using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
	public class Tabs : Zebble.Mvvm.ViewModel
	{
		public void OnContactsTapped() => Forward<Contacts>();
		public void OnCategoriesTapped() => Forward<Categories>();
		public void OnSettingsTapped() => Forward<Settings>();
	}
}
