using Domain;
using Domain.Models;
using Olive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;
using Zebble;

namespace ViewModel
{
    public class Contacts : FullScreen
    {
        public CollectionViewModel<Item> Items = new();

        protected override async Task NavigationStartedAsync()
        {
            await LoadListItems();
            await base.NavigationStartedAsync();
        }

        public async Task LoadListItems()
        {

            var contacts = (await Api.Contact.GetContacts()).ToArray();
            Items.Replace(contacts);
        }
        public class Item : Zebble.Mvvm.ViewModel<Contact>
        {
            public Bindable<string> FirstName => Source.Get(x => x.FirstName);
            public Bindable<string> LastName => Source.Get(x => x.LastName);
            public Bindable<string> FullName => Source.Get(x => $"{x.FirstName} {x.LastName}");
            public Bindable<byte[]> Photo => Source.Get(x => x.Photo);
            public Bindable<string> Phone => Source.Get(x => x.PhoneNumber);
            public Bindable<DateTime> DateOfBirth => Source.Get(x => x.DateOfBirth.Value);
            public Bindable<string> Email => Source.Get(x => x.Email);

            public void OnContactTapped() => Forward<ContactInfo>(x => x.Source(Source));
        }

    }
}
