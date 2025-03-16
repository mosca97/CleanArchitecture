// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Budget;
using CleanArchitecture.Domains.Todo;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Data
{
    public interface IApplicationDbContext
    {
        DbSet<TodoItem> TodoItems { get; }
        public DbSet<Expense> Expenses { get; }
        public DbSet<Income> Incomes { get; }
        public DbSet<ExpenseCategory> Categories { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
