// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructures;

public class CategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
{
    public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);

        builder
            .HasMany(x => x.Incomes)
            .WithOne(e => e.Category)
            .HasForeignKey(x => x.CategoryId);

        builder
            .HasMany(x => x.Expenses)
            .WithOne(e => e.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}
