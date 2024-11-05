using HouseRentigSys2.Extensions;
using HouseRentingSys2.Core.Contracts;
using HouseRentingSys2.Core.Models.Agent;
using HouseRentingSys2.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentigSys2.Controllers
{
    [Authorize]
	public class AgentController : BaseController
	{
		private readonly IAgentService agentService;
        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;	
        }
        [HttpGet]
		public async Task<IActionResult> Become()
		{
			if (await agentService.ExistsByIdAsync(User.Id()))
			{
				return BadRequest();
			}

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
