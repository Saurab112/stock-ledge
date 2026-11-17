using System;
using System.Collections.Generic;
using System.Text;

namespace StockLedge.Domain.Exceptions
{
	public class BusinessRuleViolationException : DomainException
	{
		public string Code { get; }

		public BusinessRuleViolationException(string code, string message) : base(message)
		{
			Code = code;
			WithExtension("code", code);
		}
	}
}
