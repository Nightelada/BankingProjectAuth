﻿using System;
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
    public class CreditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Credits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Credit.Include(c => c.BankingAccount);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Credits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credit
                .Include(c => c.BankingAccount)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // GET: Credits/Create
        public IActionResult Create()
        {
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID");
            return View();
        }

        // POST: Credits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BankingAccountID,Type,Duration,TotalPrincipal,OwedPrincipal,OverduePrincipal,InterestRate,TotalInterest,OwedInterest,OverdueInterest,InstallmentAmmount,NextInstallment,LastInstallment,TotalTaxes,OwedTaxes,OverdueTaxes")] Credit credit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", credit.BankingAccountID);
            return View(credit);
        }

        // GET: Credits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credit.SingleOrDefaultAsync(m => m.ID == id);
            if (credit == null)
            {
                return NotFound();
            }
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", credit.BankingAccountID);
            return View(credit);
        }

        // POST: Credits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BankingAccountID,Type,Duration,TotalPrincipal,OwedPrincipal,OverduePrincipal,InterestRate,TotalInterest,OwedInterest,OverdueInterest,InstallmentAmmount,NextInstallment,LastInstallment,TotalTaxes,OwedTaxes,OverdueTaxes")] Credit credit)
        {
            if (id != credit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditExists(credit.ID))
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
            ViewData["BankingAccountID"] = new SelectList(_context.BankingAccount, "ID", "ID", credit.BankingAccountID);
            return View(credit);
        }

        // GET: Credits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credit
                .Include(c => c.BankingAccount)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // POST: Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credit = await _context.Credit.SingleOrDefaultAsync(m => m.ID == id);
            _context.Credit.Remove(credit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditExists(int id)
        {
            return _context.Credit.Any(e => e.ID == id);
        }
    }
}
