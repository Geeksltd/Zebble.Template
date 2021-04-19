using Domain.Models;
using Olive;
using System;
using System.Collections.Generic;
using System.Text;
using Zebble.Mvvm;

namespace ViewModel
{
	public class Contacts : FullScreen
	{
		public CollectionViewModel<Item> Items = new();


		public class Item : Zebble.Mvvm.ViewModel<Contact>
		{
			public Bindable<string> FirstName => Source.Get(x => x.FirstName);
			public Bindable<string> LastName => Source.Get(x => x.LastName);
			public Bindable<byte[]> Photo => Source.Get(x => x.Photo);
			public Bindable<string> Phone => Source.Get(x => x.PhoneNumber);
			public Bindable<DateTime> DateOfBirth => Source.Get(x => x.DateOfBirth.Value);
			public Bindable<string> Email => Source.Get(x => x.Email);
		}

	}
}
