using System;
using System.Net;
using System.Threading.Tasks;
using Autostop.Services.Identity.Abstraction.Services;
using Autostop.Services.Identity.Models;
using Autostop.Services.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Autostop.Services.Identity.Controllers
{
    [Route("api/phone_authentication")]
    public class PhoneAuthenticationController : ControllerBase
    {
        private readonly PhoneNumberTokenProvider<ApplicationUser> _phoneNumberTokenProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISmsService _smsService;

        public PhoneAuthenticationController(
            PhoneNumberTokenProvider<ApplicationUser> phoneNumberTokenProvider,
            UserManager<ApplicationUser> userManager)
        {
            _phoneNumberTokenProvider = phoneNumberTokenProvider;
            _userManager = userManager;
        }

        private string TemporarySecurityStamp = new Guid().ToString();
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]LoginViewModel loginViewModel)
        {
            ApplicationUser user = await GetUser(loginViewModel);

            string token = await _phoneNumberTokenProvider.GenerateAsync("verify_number", _userManager, user);
            return Accepted();
        }        

        [HttpPut]
        public async Task<IActionResult> Put(string token, [FromBody]LoginViewModel loginViewModel)
        {
            return Accepted();
        }

        private async Task<ApplicationUser> GetUser(LoginViewModel loginViewModel)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == loginViewModel.PhoneNumber);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    PhoneNumber = loginViewModel.PhoneNumber,
                    SecurityStamp = TemporarySecurityStamp
                };
            }

            return user;
        }
    }
}
