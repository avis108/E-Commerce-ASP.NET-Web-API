using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce_API.Models;
using System.Data.Entity;
using E_Commerce_API.Repository.RepositoryInterfaces;

namespace E_Commerce_API.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private E_CommContext dbContext ;
		
		public CustomerRepository(E_CommContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Customer Create(Customer entity)
		{
			dbContext.Customers.Add(entity);
			return entity;
		}

		public bool FindByEmailAddress(string emailAddress)
		{
			return dbContext.Customers.
				Any(x => x.EmailAddress == emailAddress);
		}

		public Customer FindByID(int ID)
		{
			return dbContext.Customers.Find(ID);
		}
	}
}