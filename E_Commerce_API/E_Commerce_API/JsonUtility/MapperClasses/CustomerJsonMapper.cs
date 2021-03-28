using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.JsonHeplerClass
{
	public class CustomerJsonMapper
	{
		public string CustomerName;
		public int CustomerID;
		public string Address;
		public string EmailAddress;
		public List<OrderJsonMapper> Orders;

	}
}