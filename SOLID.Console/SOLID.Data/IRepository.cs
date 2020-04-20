using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOLID.Data
{
	public interface IRepository<T>
	{
		Task<T> Get(int id);
		Task<IEnumerable<T>> GetAll();
	}
}
