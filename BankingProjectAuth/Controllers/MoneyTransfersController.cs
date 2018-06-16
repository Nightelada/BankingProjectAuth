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
    public class MoneyTransfersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MoneyTransfersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MoneyTransfers
        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(currentUser);

            IEnumerable<MoneyTransfer> moneyTransfers = _context.MoneyTransfer.Include(m => m.BankingAccount).Include(m => m.Currency); ;

            if (!roles.Contains("Administrator"))
            {
                return View(moneyTransfers.Where(g => g.BankingAccount.UserID.Equals(currentUser.Id)));
            }
            else
            {
                return View(moneyTransfers);
            }
        }

        // GET: MoneyTransfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyTransfer = await _context.MoneyTransfer
                .Include(m => m.BankingAccount)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (moneyTransfer == null)
            {
                return NotFound();
            }

            return View(moneyTransfer);
        }

        // GET: MoneyTransfers/Create
        public IActionResult Create()
        {
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID");
            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo");
            return View();
        }

        // POST: MoneyTransfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BankingAccountID,Type,CurrencyID,RecipientName,RecipientIBAN,RecipientCountry,RecipientAddress,Reason,AdditionalReason,Amount,TransferDate")] MoneyTransfer moneyTransfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", moneyTransfer.BankingAccountID);
            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo", moneyTransfer.CurrencyID);
            return View(moneyTransfer);
        }

        // GET: MoneyTransfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyTransfer = await _context.MoneyTransfer.SingleOrDefaultAsync(m => m.ID == id);
            if (moneyTransfer == null)
            {
                return NotFound();
            }
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", moneyTransfer.BankingAccountID);
            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo", moneyTransfer.CurrencyID);
            return View(moneyTransfer);
        }

        // POST: MoneyTransfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BankingAccountID,Type,CurrencyID,RecipientName,RecipientIBAN,RecipientCountry,RecipientAddress,Reason,AdditionalReason,Amount,TransferDate")] MoneyTransfer moneyTransfer)
        {
            if (id != moneyTransfer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyTransfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyTransferExists(moneyTransfer.ID))
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
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", moneyTransfer.BankingAccountID);
            ViewData["CurrencyID"] = new SelectList(_context.Currency, "ID", "CurrencyInfo", moneyTransfer.CurrencyID);
            return View(moneyTransfer);
        }

        // GET: MoneyTransfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyTransfer = await _context.MoneyTransfer
                .Include(m => m.BankingAccount)
                .Include(m => m.Currency)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (moneyTransfer == null)
            {
                return NotFound();
            }

            return View(moneyTransfer);
        }

        // POST: MoneyTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneyTransfer = await _context.MoneyTransfer.SingleOrDefaultAsync(m => m.ID == id);
            _context.MoneyTransfer.Remove(moneyTransfer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyTransferExists(int id)
        {
            return _context.MoneyTransfer.Any(e => e.ID == id);
        }
    }
}
