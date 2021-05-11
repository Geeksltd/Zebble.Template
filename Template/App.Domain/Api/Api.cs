using Domain.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    static class Api
    {
        public static ICategoryApi Category { get; private set; } = new CategoryApi();
        public static IContactApi Contact { get; private set; } = new ContactApi();
        public static IAuthenticationApi Authentication { get; private set; } = new AuthenticationApi();


        public static void Fake()
        {
            Category = new Fake.CategoryApi();
            Contact = new Fake.ContactApi();
            Authentication = new Fake.AuthenticationApi();
        }
    }
}
