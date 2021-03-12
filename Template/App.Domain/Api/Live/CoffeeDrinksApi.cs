using Domain.Api.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble;
using Olive;

namespace Domain.Api.Live
{
	public class CoffeeDrinksApi : BaseApi, ICoffeeDrinksApi
	{
		private string coffeeDrinksRoot = "https://test.co/api/v1/coffee-drinks";

		public Task<CoffeeDrink> GetCoffeeDrink(Guid id) => Get<CoffeeDrink>($"{coffeeDrinksRoot}/{id}").OrCompleted();

		public Task<CoffeeDrink[]> GetCoffeeDrinks() => Get<CoffeeDrink[]>(coffeeDrinksRoot).OrEmpty();
	}
}
