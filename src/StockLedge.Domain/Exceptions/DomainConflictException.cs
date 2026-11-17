using System;
using System.Collections.Generic;
using System.Text;

namespace StockLedge.Domain.Exceptions
{
	public class DomainConflictException : DomainException
	{
		public string Code { get; }

		public DomainConflictException(string code, string message) : base(message)
		{
			Code = code;
			WithExtension("code", code);
		}
	}
}
