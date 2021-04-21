using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace ViewModel
{
	public class LandingPage : FullScreen
	{
		public async Task onLogInTapped() => Forward<Login>();
	
	}
}
