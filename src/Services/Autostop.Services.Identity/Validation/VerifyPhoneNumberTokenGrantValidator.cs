using Autostop.Services.Identity.Models;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var credential = context.Request.Raw.Get(OidcConstants.TokenRequest.GrantType);
            if (credential != null && credential == Constants.IdentityConstants.GrantType.VerifyPhoneNumber)
            {
                var phoneNumber = context.Request.Raw.Get(Constants.IdentityConstants.TokenRequest.PhoneNumber);
                var token = context.Request.Raw.Get(Constants.IdentityConstants.TokenRequest.Token);

                context.Result = new GrantValidationResult(new Dictionary<string, object>
                {
                    { "verificationId", Guid.NewGuid() }
                });
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid verify_phone_number credential");
            }

            return Task.CompletedTask;
        }
    }
}
