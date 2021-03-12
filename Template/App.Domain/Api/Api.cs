using System;
using System.Collections.Generic;
using System.Text;
using Domain.Api.Interfaces;

namespace Domain.Api
{
	class Api
	{
        public static ICoffeeDrinksApi CoffeeDrinks { get; private set; } = new Live.CoffeeDrinksApi();

        public static void Fake()
        {
            CoffeeDrinks = new Fake.CoffeeDrinksApi();
        }
    }
}
