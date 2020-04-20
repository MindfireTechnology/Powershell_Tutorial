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
			Animal a = new Animal { Name = "Bob" };
			Mammal m = new Mammal { Name = "Spot" };
			Tiger t = new Tiger { Name = "Tigger" };
			List<Animal> animalList = new List<Animal> { a, m, t };

			var fileLogger = new FileLogger();
			var consoleLogger = new ConsoleLogger();

			Log(consoleLogger, animalList);
			Log(fileLogger, animalList);
		}

		public static void Log(ILogger logger, IEnumerable<Animal> animals)
		{
			foreach(var animal in animals)
			{
				logger.Debug(animal.Speak());
			}
		}

		public interface ILogger
		{
			void Debug(string message);
			void Error(string message);
			void Info(string message);
		}

		public class FileLogger : ILogger
		{
			void Debug(string message)
			{
				System.IO.File.WriteAllText(@"C:\temp\debug.txt", message);
			}
			void Error(string message)
			{
				System.IO.File.WriteAllText(@"C:\temp\error.txt", message);
			}
			void Info(string message)
			{
				System.IO.File.WriteAllText(@"C:\temp\info.txt", message);
			}
		}

		public class ConsoleLogger : ILogger
		{
			void Debug(string message)
			{
				System.Diagnostics.Debug.WriteLine(message);
			}
			void Error(string message)
			{
				Console.Error.WriteLine(message);
			}
			void Info(string message)
			{
				Console.WriteLine(message);
			}
		}

		public class Animal
		{
			public string Name { get; set; }

			public virtual string Speak()
			{
				return $"Hello, I'm a generic animal named {Name}";
			}
		}

		public class Mammal : Animal
		{
			public override string Speak()
			{
				return $"Mammal's are the greatest! My name is {Name}";
			}
		}

		public class Tiger : Mammal
		{
			public override string Speak()
			{
				return $"Go Tigers! I'm {Name}";
			}
		}
	}
}