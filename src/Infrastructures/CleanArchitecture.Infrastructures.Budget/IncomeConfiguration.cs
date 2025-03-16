// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructures.Budget;

public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description);
        builder.Property(x => x.Title);
        builder.Property(x => x.CreatedAt);
        builder.OwnsOne(p => p.Money, moneyConfig =>
        {
            moneyConfig.Property(m => m.Amount);
            moneyConfig.Property(m => m.Currency);
        }).HasNoKey();

        builder
            .HasOne(x => x.Category)
            .WithMany(e => e.Incomes)
            .HasForeignKey(x => x.CategoryId);
    }
}
