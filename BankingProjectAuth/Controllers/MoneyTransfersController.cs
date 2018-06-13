using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankingProjectAuth.Data;
using BankingProjectAuth.Models;

namespace BankingProjectAuth.Controllers
{
    public class MoneyTransfersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoneyTransfersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoneyTransfers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MoneyTransfer.Include(m => m.BankingAccount);
            return View(await applicationDbContext.ToListAsync());
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
            return View();
        }

        // POST: MoneyTransfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BankingAccountID,Type,Currency,RecipientName,RecipientIBAN,RecipientCountry,RecipientAddress,Reason,AdditionalReason,Amount,TransferDate")] MoneyTransfer moneyTransfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", moneyTransfer.BankingAccountID);
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
            return View(moneyTransfer);
        }

        // POST: MoneyTransfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BankingAccountID,Type,Currency,RecipientName,RecipientIBAN,RecipientCountry,RecipientAddress,Reason,AdditionalReason,Amount,TransferDate")] MoneyTransfer moneyTransfer)
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
