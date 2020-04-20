using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDemo.Data
{
	public interface IRepository<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);
		Task Insert(T data);
	}
}
