using Domain.Models;
using Olive;
using System;
using System.Collections.Generic;
using System.Text;
using Zebble.Mvvm;

namespace ViewModel
{
    public class ContactInfo : FullScreen<Contact>
    {
        public Bindable<string> firstName => Source.Get(x => x.FirstName);
        public Bindable<string> lastName => Source.Get(x => x.LastName);
        public Bindable<byte[]> Photo => Source.Get(x => x.Photo);
        public Bindable<string> Phone => Source.Get(x => x.PhoneNumber);
        public Bindable<DateTime> DateOfBirth => Source.Get(x => x.DateOfBirth.Value);
        public Bindable<string> Email => Source.Get(x => x.Email);

        public void OnDeleteContactTapped() => ShowPopUp<DeleteContactConfirmation>(x => x.Source.Set(Source));
    }
}
