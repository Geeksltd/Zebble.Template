using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
	public class Contact
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public byte[] Photo { get; set; }

	}
}
