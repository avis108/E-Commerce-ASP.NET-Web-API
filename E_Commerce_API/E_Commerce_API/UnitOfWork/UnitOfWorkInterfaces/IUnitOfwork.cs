using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_API.Models;
using E_Commerce_API.Repository.RepositoryInterfaces;

namespace E_Commerce_API.UnitOfWork
{
	interface IUnitOfwork
	{
		IOrdersRepository ordersRepository { get; set; }
		ICustomerRepository customerRepository { get; set; }
		int Save();
	}
}
