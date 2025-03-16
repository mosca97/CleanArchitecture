// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Budget.ValueObjects;

namespace CleanArchitecture.Domains.Budget;

public class Expense
{
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Money Money { get; set; }
    public DateTime CreatedAt { get; set; }

    public ExpenseCategory Category { get; set; }
}
