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
			FizzBuzz(1, 20).Dump();

			var gen = FizzBuzzGen(1);
			for (int i = 0; i < 16 && gen.MoveNext(); ++i)
			{
				gen.Current.Dump();
			}

			var visitors = new List<Func<int, string>>
			{
				i => i % 3 == 0 && i % 5 == 0 ? "FizzBuzz" : null,
				i => i % 3 == 0 ? "Fizz" : null,
				i => i % 5 == 0 ? "Buzz" : null,
				i => i % 7 == 0 ? "Foo" : null,
				i => i.ToString()
			};

			var gen = FizzBuzzVisitor(1, visitors);
			for (int i = 0; i < 16 && gen.MoveNext(); ++i)
			{
				gen.Current.Dump();
			}
		}

		public string FizzBuzz(int start, int end)
		{
			var builder = new StringBuilder();

			for (int i = start; i < end; ++i)
			{
				if (i % 3 == 0)
					builder.Append("Fizz");
				if (i % 5 == 0)
					builder.Append("Buzz");
				if (i % 3 != 0 && i % 5 != 0)
					builder.Append(i);
				builder.AppendLine();
			}

			return builder.ToString();
		}

		public IEnumerator<string> FizzBuzzGen(int start)
		{
			while (true)
			{
				string result = string.Empty;
				if (start % 3 == 0)
					result += "Fizz";
				if (start % 5 == 0)
					result += "Buzz";
				if (start % 3 != 0 && start % 5 != 0)
					result += start;
				yield return result;
			}
		}

		public IEnumerator<string> FizzBuzzVisitor(int start, List<Func<int, string>> visitors)
		{
			if (visitors == null || visitors.Count == 0)
				yield break;

			while (true)
			{
				foreach (var visitor in visitors)
				{
					var result = visitor(start);
					if (result != null)
					{
						yield return result;
						break;
					}
				}
				start++;
			}
		}
	}
}