using Domain.Models;
using System;
using System.Threading.Tasks;
using Olive;
using Zebble;

namespace Domain
{
    public class ContactApi : BaseApi, IContactApi
    {
        private string baseApi = "https://test.co/api/v1/coffee-drinks";

        public Task<Contact> GetContact(Guid id) => Get<Contact>($"{baseApi}/{id}").OrCompleted();

        public Task<Contact[]> GetContacts() => Get<Contact[]>(baseApi).OrEmpty().ToArray();
        public Task<bool> DeleteContact(Guid id) => Get<bool>($"{baseApi}/{id}").OrCompleted();

    }
}
