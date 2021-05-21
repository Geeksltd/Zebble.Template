using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Olive;

namespace Domain
{
    class BaseFakeApi
    {
        static List<object> FakeDb = new List<object>();

        static BaseFakeApi()
        {
            Add(new Category { Id = Guid.NewGuid(), Name = "Friend" });
            Add(new Category { Id = Guid.NewGuid(), Name = "Family" });
            Add(new Category { Id = Guid.NewGuid(), Name = "Client" });
            Add(new Category { Id = Guid.NewGuid(), Name = "Supplier" });

            Add(new Contact { Id = Guid.NewGuid(), FirstName = "Joe", LastName = "Menon", Email = "menon@crm.co", PhoneNumber = "+447999147852", DateOfBirth = LocalTime.Now.AddYears(-10) });
            Add(new Contact { Id = Guid.NewGuid(), FirstName = "Adam", LastName = "Sharma", Email = "sharma@crm.co", PhoneNumber = "+447999147842", DateOfBirth = LocalTime.Now.AddYears(-60) });
            Add(new Contact { Id = Guid.NewGuid(), FirstName = "Kate", LastName = "Roy", Email = "roy@crm.co", PhoneNumber = "+447999167842", DateOfBirth = LocalTime.Now.AddYears(-30) });
            Add(new Contact { Id = Guid.NewGuid(), FirstName = "Jon", LastName = "Verma", Email = "verma@crm.co", PhoneNumber = "+447999144842", DateOfBirth = LocalTime.Now.AddYears(-12) });


        }

        protected static Task<T[]> Query<T>(Func<T, bool> criteria = null)
            => Return(FakeDb.OfType<T>().Where(v => criteria == null || criteria(v)).ToArray());

        protected static Task<T> Fetch<T>(Func<T, bool> criteria = null)
            => Return(FakeDb.OfType<T>().FirstOrDefault(v => criteria == null || criteria(v)));

        protected static T Add<T>(T item) => item.Set(x => FakeDb.Add(x));

        public static Guid Id() => (FakeDb.Count + 100).ToGuid();

        protected static Task<T> Return<T>(T value) => Task.FromResult(value);
    }
}
