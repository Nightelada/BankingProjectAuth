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
    public class UtilityBillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilityBillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UtilityBills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UtilityBill.Include(u => u.BankingAccount);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UtilityBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilityBill = await _context.UtilityBill
                .Include(u => u.BankingAccount)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (utilityBill == null)
            {
                return NotFound();
            }

            return View(utilityBill);
        }

        // GET: UtilityBills/Create
        public IActionResult Create()
        {
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID");
            return View();
        }

        // POST: UtilityBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BankingAccountID,Type,Status,Provider,Name,SubscriptionNumber,DebtDate,Ammount")] UtilityBill utilityBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilityBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", utilityBill.BankingAccountID);
            return View(utilityBill);
        }

        // GET: UtilityBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilityBill = await _context.UtilityBill.SingleOrDefaultAsync(m => m.ID == id);
            if (utilityBill == null)
            {
                return NotFound();
            }
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", utilityBill.BankingAccountID);
            return View(utilityBill);
        }

        // POST: UtilityBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BankingAccountID,Type,Status,Provider,Name,SubscriptionNumber,DebtDate,Ammount")] UtilityBill utilityBill)
        {
            if (id != utilityBill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilityBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilityBillExists(utilityBill.ID))
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
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", utilityBill.BankingAccountID);
            return View(utilityBill);
        }

        // GET: UtilityBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilityBill = await _context.UtilityBill
                .Include(u => u.BankingAccount)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (utilityBill == null)
            {
                return NotFound();
            }

            return View(utilityBill);
        }

        // POST: UtilityBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilityBill = await _context.UtilityBill.SingleOrDefaultAsync(m => m.ID == id);
            _context.UtilityBill.Remove(utilityBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilityBillExists(int id)
        {
            return _context.UtilityBill.Any(e => e.ID == id);
        }
    }
}
