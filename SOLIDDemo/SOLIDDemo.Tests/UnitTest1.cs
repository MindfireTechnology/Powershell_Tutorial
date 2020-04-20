using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SOLIDDemo.Web;
using System.Threading.Tasks;

namespace SOLIDDemo.Tests
{
	[TestClass]
	public class UnitTest1
	{
		protected Processor Processor { get; set; }
		protected ILogger<Processor> Logger { get; set; }
		protected WebRequester Requester { get; set; }

		[TestInitialize]
		public void Initialize()
		{
			Logger = Substitute.For<ILogger<Processor>>();
			Requester = Substitute.For<WebRequester>();
			Processor = new Processor(Logger, Requester);
		}

		[TestMethod]
		public async Task TestMethod1()
		{
			Logger.Received(5).LogDebug(Arg.Any<EventId>(), Arg.Any<string>());
			await Processor.Run();
		}
	}
}
