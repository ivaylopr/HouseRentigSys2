using HouseRentigSys2.Attributes;
using HouseRentingSys2.Core.Contracts;
using HouseRentingSys2.Core.Models.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HouseRentingSys2.Core.Constants.MessageConstants;

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
		[NotAnAgent]
		public IActionResult Become()
		{
			
			var model = new BecomeAgentFormModel();
			return View(model);
		}

		[HttpPost]
		[NotAnAgent]
		public async Task<IActionResult> Become(BecomeAgentFormModel model)
		{
			if (await agentService.UserWithPhoneNumberExistAsync(User.Id()))
			{
				ModelState.AddModelError(nameof(model.PhoneNumber),PhoneExists);
			}

			if (await agentService.UserHasRentAsync(User.Id()))
			{
				ModelState.AddModelError("Error", HasRents);
			}

			if (ModelState.IsValid== false)
			{
				return View(model);
			}

			await agentService.CreateAsync(User.Id(), model.PhoneNumber);
			return RedirectToAction(nameof(HouseController.All), "House");
		}
	}
}
