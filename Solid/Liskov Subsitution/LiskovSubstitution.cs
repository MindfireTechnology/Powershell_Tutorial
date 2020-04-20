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

			Log(t);

			List<Animal> animalList = new List<Animal> { a, m, t };
			LogList(animalList);
		}

		public void Log(object o)
		{
			if (o is Animal a)
				Log(a);

			o.ToString().Dump();
		}

		public void LogList(List<object> animals)
		{
			animals.ForEach(o =>
			{
				Log(o);
			});
		}

		// Define other methods and classes here
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