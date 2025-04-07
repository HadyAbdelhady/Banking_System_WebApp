using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankingSystem.DAL.Models;

namespace BankingSystem.DAL.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<MyManager>
    {
        public void Configure(EntityTypeBuilder<MyManager> builder)
        {
            builder.HasOne(m => m.Branch)
               .WithOne(b => b.MyManager)
               .HasForeignKey<MyManager>(m => m.BranchId);

            builder.Property(m => m.Salary)
            .IsRequired()
             .HasColumnType("decimal(18,4)");
        }
    }
}
