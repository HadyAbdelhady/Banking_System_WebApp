﻿using AutoMapper;
using BankingSystem.BLL.Interfaces;
using BankingSystem.BLL;
using BankingSystem.DAL.Models;
using BankingSystem.PL.ViewModels.Manager;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankingSystem.PL.Controllers.AppAdmin
{
    public class AdminLoansController(IUnitOfWork unitOfWork, IMapper mapper) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public IActionResult GetAllLoans()
        {
            var Loans = _unitOfWork.Repository<Loan>()
                .GetAllIncluding(c => c.Customer, a => a.Account)
                .ToList();

            var allAmount = Loans.Sum(l => l.LoanAmount);
            var allDept = Loans.Sum(l => l.CurrentDebt);
            var allPaid = allAmount - allDept;

            ViewBag.TotalLoans = Loans.Count;
            ViewBag.TotalAmount = allAmount;
            ViewBag.TotalPaid = allPaid;
            ViewBag.TotalDept = allDept;

            var loansViewModel = _mapper.Map<List<LoansViewModel>>(Loans);
            return View(nameof(GetAllLoans), loansViewModel);
        }
        public IActionResult PreviewLoan(int LoanId)
        {
            var Loan = _unitOfWork.Repository<Loan>().GetSingleIncluding(l => l.Id == LoanId,
                                                                        a => a.Account,
                                                                        c => c.Customer,
                                                                        c => c.Customer.FinancialDocument);
            if (Loan == null) return NotFound();

            var LoanDetails = _mapper.Map<Loan, LoanDetailsViewModel>(Loan);

            return View(LoanDetails);
        }



    }
}
