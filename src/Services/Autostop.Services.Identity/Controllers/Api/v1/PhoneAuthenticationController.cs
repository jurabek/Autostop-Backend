using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Autostop.Services.Identity.Abstraction.Services;
using Autostop.Services.Identity.Models;
using Autostop.Services.Identity.ViewModels;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autostop.Services.Identity.Controllers.Api.v1
{
	[Route("api/v1/phone_authentication")]
	public class PhoneAuthenticationController : ControllerBase
	{
		private readonly ISmsService _smsService;
		private readonly DataProtectorTokenProvider<ApplicationUser> _dataProtectorTokenProvider;
		private readonly PhoneNumberTokenProvider<ApplicationUser> _phoneNumberTokenProvider;
		private readonly UserManager<ApplicationUser> _userManager;

		public PhoneAuthenticationController(
			ISmsService smsService,
			DataProtectorTokenProvider<ApplicationUser> dataProtectorTokenProvider,
			PhoneNumberTokenProvider<ApplicationUser> phoneNumberTokenProvider,
			UserManager<ApplicationUser> userManager)
		{
			_smsService = smsService;
			_dataProtectorTokenProvider = dataProtectorTokenProvider;
			_phoneNumberTokenProvider = phoneNumberTokenProvider;
			_userManager = userManager;
		}

		[HttpPost("send")]
		[ProducesResponseType((int)HttpStatusCode.Accepted)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[AllowAnonymous]
		public async Task<IActionResult> Post([FromBody]PhoneLoginViewModel loginViewModel)
		{
			var user = await GetUser(loginViewModel);
			var resendToken = await _dataProtectorTokenProvider.GenerateAsync("resend_token", _userManager, user);
			var token = await _phoneNumberTokenProvider.GenerateAsync("verify_number", _userManager, user);
			var success = await _smsService.SendAsync(loginViewModel.PhoneNumber, $"Your Autostop verification code is: {token}");
			var result = new Dictionary<string, string> { { "resend_token", resendToken } };

			return success ? (IActionResult)Accepted(result) : BadRequest();
		}

		[HttpPut("resend/{resendToken}")]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Accepted)]
		public async Task<IActionResult> Put(string resendToken, [FromBody]PhoneLoginViewModel loginViewModel)
		{
			var user = await GetUser(loginViewModel);
			if (!await _dataProtectorTokenProvider.ValidateAsync("resend_token", resendToken, _userManager, user))
			{
				return BadRequest("Invalid verificationId");
			}
			return Accepted();
		}

		private async Task<ApplicationUser> GetUser(PhoneLoginViewModel loginViewModel)
		{
			var phoneNumber = _userManager.NormalizeKey(loginViewModel.PhoneNumber);
			var user = await _userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber) ?? new ApplicationUser
			{
				PhoneNumber = loginViewModel.PhoneNumber,
				SecurityStamp = loginViewModel.PhoneNumber.Sha256()
			};
			return user;
		}
	}
}
