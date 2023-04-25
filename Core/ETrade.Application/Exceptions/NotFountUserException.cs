using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Exceptions
{
	public class NotFountUserException : Exception
	{
		public NotFountUserException() : base("Username or Password is incorrect!")
		{

		}

		public NotFountUserException(string? message) : base(message)
		{
		}

		public NotFountUserException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
