using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
	public static class Extensions
	{
		public static bool IsValidEmailAddress(this string @this)
		{
			return Regex.Match(@this, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase).Success;
		}
	}
}
