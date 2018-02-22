using Autostop.Services.Identity.Models;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Autostop.Services.Identity.Validation
{
	public class VerifyPhoneNumberTokenGrantValidator : IExtensionGrantValidator
	{
		private readonly PhoneNumberTokenProvider<ApplicationUser> phoneNumberTokenProvider;
		private readonly UserManager<ApplicationUser> userManager;

		public VerifyPhoneNumberTokenGrantValidator(
			PhoneNumberTokenProvider<ApplicationUser> phoneNumberTokenProvider,
			UserManager<ApplicationUser> userManager)
		{
			this.phoneNumberTokenProvider = phoneNumberTokenProvider;
			this.userManager = userManager;
		}

		public string GrantType => Constants.IdentityConstants.GrantType.VerifyPhoneNumber;

		public async Task ValidateAsync(ExtensionGrantValidationContext context)
		{
			var credential = context.Request.Raw.Get(OidcConstants.TokenRequest.GrantType);
			if (credential != null && credential == Constants.IdentityConstants.GrantType.VerifyPhoneNumber)
			{
				var phoneNumber = context.Request.Raw.Get(Constants.IdentityConstants.TokenRequest.PhoneNumber);
				var token = context.Request.Raw.Get(Constants.IdentityConstants.TokenRequest.Token);

				var user = await userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
				if (user == null)
				{
					user = new ApplicationUser()
					{
						UserName = phoneNumber,
						PhoneNumber = phoneNumber,
						SecurityStamp = phoneNumber.Sha256(),
					};

					var result = await phoneNumberTokenProvider.ValidateAsync("verify_number", token, userManager, user);
					if (result)
					{
						var createResult = await userManager.CreateAsync(user);
					}
					context.Result = new GrantValidationResult(subject: user.Id, authenticationMethod: OidcConstants.AuthenticationMethods.ConfirmationBySms);
				}
				
			}
			else
			{
				context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid verify_phone_number credential");
			}
		}
	}
}
