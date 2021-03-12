using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.Api.Interfaces
{
	interface ICoffeeDrinksApi
	{
		Task<CoffeeDrink[]> GetCoffeeDrinks();

		Task<CoffeeDrink> GetCoffeeDrink(Guid id);
	}
}
