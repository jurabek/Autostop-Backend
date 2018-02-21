using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autostop.Services.Identity.Abstraction.Services;
using Autostop.Services.Identity.Models;
using Autostop.Services.Identity.ViewModels;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Autostop.Services.Identity.Controllers
{
	public enum AuthOperation
	{
		AddingOtherUserEmail,
		AddingNovelEmail,
		Registering,
		LoggingIn
	}

	[Route("api/v1/identity/")]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ISmsService _smsService;
		private readonly IIdentityServerInteractionService _interactionService;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			IIdentityServerInteractionService interactionService)
		{
			_userManager = userManager;
			_interactionService = interactionService;
		}

		private string TemporarySecurityStamp = new Guid().ToString();

		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
		{
			var email = loginViewModel.Email;
			AuthOperation operation;
			var user = await _userManager.FindByLoginAsync("Email", email);
			if (user == null)
			{
				user = new ApplicationUser()
				{
					Id = email,
					Email = email,
					SecurityStamp = TemporarySecurityStamp
				};
				operation = AuthOperation.Registering;
			}
			else
			{
				operation = AuthOperation.LoggingIn;
			}

			if (operation == AuthOperation.Registering || operation == AuthOperation.LoggingIn)
			{
				string purpose = "register_or_login";
				string token = await _userManager.GenerateUserTokenAsync(user, "Email", purpose);
			}

			return Ok();
		}

		[HttpPost("verify_code")]
		public async Task<IActionResult> VerifyCode([FromBody]VerifyViewModel model)
		{
			var userEmpty = new ApplicationUser()
			{
				Email = model.Email,
				SecurityStamp = TemporarySecurityStamp,
				UserName = model.Email
			};

			var isTokenValid = await _userManager.VerifyUserTokenAsync(userEmpty, "Email", "register_or_login", model.Code);
			if (isTokenValid)
			{
				await _userManager.CreateAsync(userEmpty);
			}
			return Ok();
		}
	}
}
