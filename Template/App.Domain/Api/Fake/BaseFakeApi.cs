using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Olive;

namespace Domain.Api.Fake
{
	class BaseFakeApi
	{
		static List<object> FakeDb = new List<object>();

		static BaseFakeApi()
		{
			Add(new CoffeeDrink { Id = Guid.NewGuid(), Name = "Black Coffee", Price = 1.00, Photo = new byte[] { } });
			Add(new CoffeeDrink { Id = Guid.NewGuid(), Name = "Moca", Price = 10.99, Photo = new byte[] { } });
			Add(new CoffeeDrink { Id = Guid.NewGuid(), Name = "Moca", Price = 10.99, Photo = new byte[] { } });
			Add(new CoffeeDrink { Id = Guid.NewGuid(), Name = "Moca", Price = 10.99, Photo = new byte[] { } });
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
