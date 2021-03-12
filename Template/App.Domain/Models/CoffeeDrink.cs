using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
	public class CoffeeDrink
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public double Price { get; set; }

        public override string ToString() => Name;
    }
}
