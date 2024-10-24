﻿using HouseRentingSys2.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentigSys2.Controllers
{
	[Authorize]
	public class HouseController : Controller
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = new AllHousesQueryModel();
			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			var model = new AllHousesQueryModel();
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = new HouseDetailsViewModel();
			return View(model);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(HouseFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var model = new HouseFormModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, HouseFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = 1 });
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = new HouseDetailsViewModel();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Delete(HouseDetailsViewModel model)
		{
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Rent(int id)
		{
			return RedirectToAction(nameof(Mine));
		}

		[HttpPost]
		public async Task<IActionResult> Leave(HouseDetailsViewModel model)
		{
			return RedirectToAction(nameof(Mine));
		}
	}
}
