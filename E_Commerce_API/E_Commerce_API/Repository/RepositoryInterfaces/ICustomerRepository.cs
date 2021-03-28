using E_Commerce_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Repository.RepositoryInterfaces
{
	public interface ICustomerRepository : IRepository<Customer>
	{
		bool FindByEmailAddress(string emailAddress);
		
	}
}
