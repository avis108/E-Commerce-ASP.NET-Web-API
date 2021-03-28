using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	interface IRepository<TEntity>
	{
		TEntity Create();
	}
}
