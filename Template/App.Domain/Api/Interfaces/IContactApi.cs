using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    interface IContactApi
    {
        Task<Contact[]> GetContacts();
        Task<Contact> GetContact(Guid id);
        Task<bool> DeleteContact(Guid id);

    }
}
