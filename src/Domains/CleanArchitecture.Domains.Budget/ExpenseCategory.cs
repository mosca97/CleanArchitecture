// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Domains.Budget
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Expense> Expenses { get; set; } = [];
        public ICollection<Income> Incomes { get; set; } = [];
    }
}
