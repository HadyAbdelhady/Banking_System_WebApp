﻿using BankingSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace BankingSystem.PL.ViewModels.Teller
{
    public class AccountViewModel
    {
        public AccountViewModel(Account account)
        {
            Number = account.Number;
        }


        public long Number { get; set; }
        public double? Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public List<Transaction>? AccountTransactions { get; set; }
        public List<Certificate> Certificates { get; set; } = [];

        public List<Loan> Loans { get; set; } = [];
        public List<VisaCard> Cards { get; set; } = [];

        [ForeignKey(nameof(Customer))]
        public string? CustomerId { get; set; }
        public DAL.Models.Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(Branch))]
        public int? BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

    }
}
