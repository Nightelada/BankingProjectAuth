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

namespace BankingProjectAuth.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            TestViewModel tvm = new TestViewModel();
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            IEnumerable<BankingAccount> bankingAccounts = _context.BankingAccount.Include(b => b.Currency)
                .Include(b => b.User)
                .Include(b => b.Cards);

            IEnumerable<Card> cards = _context.Card.ToList();

            tvm.Accounts = bankingAccounts;
            tvm.Cards = cards;

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
