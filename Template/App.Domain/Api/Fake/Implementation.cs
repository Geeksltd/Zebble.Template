using Domain.Models;
using Olive;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fake
{
    class CategoryApi : BaseFakeApi, ICategoryApi
    {
        public Task<Category> GetCategory(Guid id) => Fetch<Category>(v => v.Id == id);

        public Task<Category[]> GetCategories() => Query<Category>();
    }

    class ContactApi : BaseFakeApi, IContactApi
    {
        internal static User User;

        public Task<Contact> GetContact(Guid id) => Fetch<Contact>(v => v.Id == id);

        public Task<Contact[]> GetContacts() => Query<Contact>();

        public Task<bool> DeleteContact(Guid id) => Return(true);
    }

    class AuthenticationApi : BaseFakeApi, IAuthenticationApi
    {
        internal static User User;

        public Task<AuthenticationResponse> AuthenticateWithCredentials(string email, string password)
        {
            if (email == "bad@test.co") return null;

            ContactApi.User = new User
            {
                Email = email,
                FirstName = email.RemoveFrom("@"),
                LastName = "Joe",
                Id = email.GetHashCode().ToGuid(),
                MobileNumber = email.GetHashCode().ToString()
            };

            return Return(new AuthenticationResponse
            {
                Status = AuthenticationResponseStatus.Successful,
                Message = "",
            });
        }

        public Task<User> GetCurrentUser() => Return(User);
    }
}
