using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankingProjectAuth.Data;
using BankingProjectAuth.Models;
using Microsoft.AspNetCore.Identity;

namespace BankingProjectAuth.Controllers
{
    public class BankingAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BankingAccountsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: BankingAccounts
        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(currentUser);

            IEnumerable<BankingAccount> bankingAccounts = _context.BankingAccount.Include(b => b.Currency).Include(b => b.User);

            if (!roles.Contains("Administrator"))
            {
                return View(bankingAccounts.Where(g => g.UserID.Equals(currentUser.Id)));
            }
            else
            {
                return View(bankingAccounts);
            }
        }

        // GET: BankingAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankingAccount = await _context.BankingAccount
                .Include(b => b.Currency)
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bankingAccount == null)
            {
                return NotFound();
            }

            return View(bankingAccount);
        }

        // GET: BankingAccounts/Create
        public async Task<IActionResult> Create()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo");
            ViewData["UserID"] = new SelectList(_context.User, "Id", "UserName", currentUser.Id);
            return View();
        }

        // POST: BankingAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,AccountType,IBAN,Balance,Available,Blocked,CurrencyID,AllowedOverdraft,UsedOverdraft")] BankingAccount bankingAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankingAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo", bankingAccount.CurrencyID);
            ViewData["UserID"] = new SelectList(_context.User, "Id", "UserName", bankingAccount.UserID);
            return View(bankingAccount);
        }

        // GET: BankingAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankingAccount = await _context.BankingAccount.SingleOrDefaultAsync(m => m.ID == id);
            if (bankingAccount == null)
            {
                return NotFound();
            }
            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo", bankingAccount.CurrencyID);
            ViewData["UserID"] = new SelectList(_context.User, "Id", "UserName", bankingAccount.UserID);
            return View(bankingAccount);
        }

        // POST: BankingAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,AccountType,IBAN,Balance,Available,Blocked,CurrencyID,AllowedOverdraft,UsedOverdraft")] BankingAccount bankingAccount)
        {
            if (id != bankingAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankingAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankingAccountExists(bankingAccount.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo", bankingAccount.CurrencyID);
            ViewData["UserID"] = new SelectList(_context.User, "Id", "UserName", bankingAccount.UserID);
            return View(bankingAccount);
        }

        // GET: BankingAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankingAccount = await _context.BankingAccount
                .Include(b => b.Currency)
                .Include(b => b.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bankingAccount == null)
            {
                return NotFound();
            }

            return View(bankingAccount);
        }

        // POST: BankingAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankingAccount = await _context.BankingAccount.SingleOrDefaultAsync(m => m.ID == id);
            _context.BankingAccount.Remove(bankingAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankingAccountExists(int id)
        {
            return _context.BankingAccount.Any(e => e.ID == id);
        }
    }
}
