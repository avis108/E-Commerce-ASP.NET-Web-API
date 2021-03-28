using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce_API.Models;
using E_Commerce_API.Repository;
using E_Commerce_API.Repository.RepositoryInterfaces;

namespace E_Commerce_API.UnitOfWork
{
	public class UnitWork : IUnitOfwork
	{
		private E_CommContext e_CommContext;

		public UnitWork(E_CommContext e_CommContext)
		{
			this.e_CommContext = e_CommContext;
			ordersRepository = new OrdersRepository(e_CommContext);
			customerRepository = new CustomerRepository(e_CommContext);
		}

		public IOrdersRepository ordersRepository { get; set; }
		public ICustomerRepository customerRepository { get; set; }
		
		int IUnitOfwork.Save()
		{
			return e_CommContext.SaveChanges();
		}
	}
}