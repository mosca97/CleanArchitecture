// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Web.BlazorApp.Models;

public class ExpenseCategory
{
    public long Id { get; set; }
    public string Name { get; set; }
}

public class CreateExpenseCategory
{
    public string Name { get; set; }
}
