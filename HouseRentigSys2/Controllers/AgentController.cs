using HouseRentingSys2.Core.Models.Agent;
using HouseRentingSys2.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentigSys2.Controllers
{
	[Authorize]
	public class AgentController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Become()
		{
			var model = new BecomeAgentFormModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
			return RedirectToAction(nameof(HouseController.All), "House");
		}
	}
}
