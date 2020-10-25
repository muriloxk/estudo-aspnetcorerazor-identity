﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using estudo_aspnetcore_identity.Models;
using Microsoft.AspNetCore.Authorization;
using estudo_aspnetcore_identity.Extensions;

namespace estudo_aspnetcore_identity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View();
        }

        [Authorize(Policy = "PodeGravar")]
        public IActionResult SecretClaimGravar()
        {
            return View();
        }

        [ClaimsAuthorizeAttribute("ClaimType", "ClaimValue")]
        public IActionResult CustomAttributClaim()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
