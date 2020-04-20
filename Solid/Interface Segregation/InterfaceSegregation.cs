using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AFS.Solid
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var dataReaderWriter = new DataReaderWriter();

			IReadData = dataReaderWriter;
			IWriteData = dataReaderWriter;
		}
	}

	public interface IReadData
	{
		Task<object> Read(string path);
	}

	public interface IWriteData
	{
		Task Write(string path, object data);
	}

	public class DataReaderWriter : IReadData, IWriteData
	{
		public Task<object> Read(string path)
		{
			return Task.FromResult(null);
		}

		public Task Write(string path, object data)
		{
			return Task.CompletedTask;
		}
	}
}