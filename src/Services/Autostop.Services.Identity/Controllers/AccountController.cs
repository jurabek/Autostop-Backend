using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autostop.Services.Identity.Abstraction.Services;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;


namespace Autostop.Services.Identity.Controllers
{
    public class AccountController : ControllerBase
	{
		private readonly ISmsService _smsService;
		private readonly IIdentityServerInteractionService _interactionService;

		public AccountController(
			ISmsService smsService,
			IIdentityServerInteractionService interactionService)
		{
			_smsService = smsService;
			_interactionService = interactionService;
		}

        public IActionResult Index()
        {
	        return Ok();
        }
    }
}
