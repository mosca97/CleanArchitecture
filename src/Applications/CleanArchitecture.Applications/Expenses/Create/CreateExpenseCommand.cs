// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Domains.Budget.ValueObjects;

namespace CleanArchitecture.Applications.Expenses.Create
{
    public sealed record CreateExpenseCommand(long CategoryId, string Title, string Description, Money Money) : ICommand<long>;
}
