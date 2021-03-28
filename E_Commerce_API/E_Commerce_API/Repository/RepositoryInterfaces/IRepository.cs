using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace E_Commerce_API
{
	public interface IRepository<TEntity> where TEntity : class
	{
		TEntity Create(TEntity entity);
		TEntity FindByID(int ID);
	}
}
