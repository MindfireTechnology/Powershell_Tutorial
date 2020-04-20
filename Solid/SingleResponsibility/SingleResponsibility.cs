using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AFS.Solid
{
	[Route("api/v1/[controller]")]
	public class SingleResponsibilityController : Controller
	{
		protected IResponsibilityService ResponsibilityService { get; }

		[HttpGet]
		public async Task<IActionResult> Get(int count)
		{
			using (var context = new DbContext("my connection string"))
			{
				var items = from i in context.items
							where i.Deleted == false
								&& i.StartDate < DateTime.Now
								&& i.EndDate > DateTime.Now
							select i;

				return Json(items.Take(count));
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(int count)
		{
			var items = await ResponsibilityService.GetCurrentItems();
			Logger.Info($"Retrieved {count} items");
			return Json(items.Take(count));
		}
	}
}