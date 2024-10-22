using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Mappings;

public class ExpenseMap : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        // Table
        builder.ToTable("Expenses");

        // Primary Key
        builder.HasKey(e => e.Id);

        // Identity
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .UseMySqlIdentityColumn();

        // Properties
        builder.Property(e => e.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasMaxLength(80);

        builder.Property(e => e.Description)
            .HasMaxLength(500)
            .IsRequired(false)
            .HasColumnName("Description");

        builder.Property(e => e.Date)
            .HasColumnType("datetime(6)")
            .HasColumnName("Date")
            .IsRequired();

        builder.Property(e => e.Amount)
            .IsRequired()
            .HasColumnType("DECIMAL(18,2)")
            .HasColumnName("Amount");

        builder.Property(e => e.PaymentType)
            .IsRequired()
            .HasColumnName("PaymentType")
            .HasMaxLength(50)
            .HasConversion<string>();
        
        builder.HasMany(e => e.Tags)
            .WithOne(t => t.Expense)
            .HasForeignKey(t => t.ExpenseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}