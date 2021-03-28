using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce_API.Models;
using System.Data.Entity;

namespace E_Commerce_API.Repository
{
	public class OrdersRepository : IRepository<Order>, IOrdersRepository
	{
		private E_CommContext dbContext;

		public OrdersRepository(E_CommContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public IEnumerable<Order> GetOrders(int pageSize, int pageIndex)
		{
			var data = dbContext.Orders
				.OrderBy(x => x.CreatedDateTime)
				.Skip((pageIndex - 1) * pageSize).Take(pageSize)
				.ToList();
			return data;
		}

		public Order Create(Order entity)
		{
			dbContext.Orders.Add(entity);
			return entity;
		}

		public Order FindByID(int ID)
		{
			return dbContext.Orders.Find(ID);
		}
	}


}