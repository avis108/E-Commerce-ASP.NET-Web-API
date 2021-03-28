using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce_API.JsonHeplerClass;
using E_Commerce_API.Models;

namespace E_Commerce_API.JsonHeplerClass
{
	public static class JsonUtility
	{
		public static CustomerJsonMapper CustomerJsonHelper(Customer customer)
		{
			return new CustomerJsonMapper()
			{
				Address = customer.Address,
				CustomerID = customer.CustomerID,
				EmailAddress = customer.EmailAddress,
				CustomerName = customer.CustomerName,
				Orders = (List<OrderJsonMapper>)customer.Orders.
					Select(x => new OrderJsonMapper()
					{
						OrderID = x.OrderID,
						Quantity = x.Quantity,
						CreatedDateTime = x.CreatedDateTime,
						TotalPrice = x.TotalPrice,
						ItemName = x.ItemName
					}).ToList()
			};
		}

		public static List<OrderJsonMapper> OrderJsonHelper(List<Order> orders)
		{
			return (List<OrderJsonMapper>)orders.
					Select(x => new OrderJsonMapper()
					{
						OrderID = x.OrderID,
						Quantity = x.Quantity,
						CreatedDateTime = x.CreatedDateTime,
						TotalPrice = x.TotalPrice,
						ItemName = x.ItemName,
						CustomerID = x.Customer.CustomerID
					}).ToList();
		}

		public static OrderJsonMapper OrderJsonHelper(Order order)
		{
			return new OrderJsonMapper()
					{
						OrderID = order.OrderID,
						Quantity = order.Quantity,
						CreatedDateTime = order.CreatedDateTime,
						TotalPrice = order.TotalPrice,
						ItemName = order.ItemName,
						CustomerID = order.Customer.CustomerID
					};
		}
	}
}