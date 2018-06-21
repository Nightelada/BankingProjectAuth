using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingProjectAuth.Models;
using Microsoft.AspNetCore.Authorization;
using BankingProjectAuth.Data;
using Microsoft.AspNetCore.Identity;
using BankingProjectAuth.Models.BankingAccountViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace BankingProjectAuth.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            TestViewModel tvm = new TestViewModel();
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            IEnumerable<BankingAccount> bankingAccounts = _context.BankingAccount.Include(b => b.Currency)
                .Include(b => b.User)
                .Include(b => b.Cards)
                .Where(b => b.UserID == currentUser.Id);

            IEnumerable<Card> cards = _context.Card.Where(c => c.BankingAccount.UserID == currentUser.Id).ToList();
            IEnumerable<Credit> credits = _context.Credit.Where(c => c.BankingAccount.UserID == currentUser.Id).ToList();

            tvm.BankingAccounts = bankingAccounts;
            tvm.Cards = cards;
            tvm.Credits = credits;

            return View(tvm);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet("/Home/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            var reExecute = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            _logger.LogInformation($"Unexpected Status Code: {statusCode}, OriginalPath: {reExecute.OriginalPath}");
            return View(statusCode);
        }
    }
}
