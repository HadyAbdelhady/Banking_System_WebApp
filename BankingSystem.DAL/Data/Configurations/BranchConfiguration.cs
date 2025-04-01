﻿using BankingSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankingSystem.DAL.Data.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(Br => Br.Location)
                    .HasMaxLength(50)
                    .IsRequired();
            builder.Property(Br => Br.TotalSavings)
                 .HasColumnType("decimal(18,4)")
                 .IsRequired();

            builder.Property(Br => Br.IsDeleted)
                    .HasDefaultValue(false);



        }

      
    }


}
