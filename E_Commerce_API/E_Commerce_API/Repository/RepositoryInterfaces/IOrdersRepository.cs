using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_API.Models;

namespace E_Commerce_API
{
	public interface IOrdersRepository : IRepository<Order>
	{
		IEnumerable<Order> GetOrders(int pageSize, int pageIndex);
	}
}
