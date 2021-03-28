using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_API.JsonHeplerClass
{
	public class OrderJsonMapper
	{
		public int OrderID;
		public int Quantity;
		public System.DateTime CreatedDateTime;
		public decimal TotalPrice;
		public string ItemName;
		public int CustomerID;
	}
}