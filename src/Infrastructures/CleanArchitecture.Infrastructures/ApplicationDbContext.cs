// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Budget;
using CleanArchitecture.Domains.Todo;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructures;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public DbSet<Income> Incomes { get; set; }

    public DbSet<ExpenseCategory> Categories { get; set; }
}
