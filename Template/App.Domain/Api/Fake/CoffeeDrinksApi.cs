using Domain.Api.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Api.Fake
{
	class CoffeeDrinksApi : BaseFakeApi, ICoffeeDrinksApi
	{

		public Task<CoffeeDrink> GetCoffeeDrink(Guid id) => Fetch<CoffeeDrink>(v => v.Id == id);

		public Task<CoffeeDrink[]> GetCoffeeDrinks() => Query<CoffeeDrink>();
	}
}
