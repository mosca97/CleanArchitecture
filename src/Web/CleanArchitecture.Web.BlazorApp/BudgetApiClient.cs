﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Web.BlazorApp.Models;

namespace CleanArchitecture.Web.BlazorApp;

internal sealed class BudgetApiClient(HttpClient client)
{
    public async Task CreateCategoryAsync(CreateExpenseCategory requet, CancellationToken cancellationToken = default)
    {
        var response = await client.PostAsJsonAsync("api/ExpenseCategory", requet, cancellationToken);
    }

    public async Task<List<ExpenseCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await client.GetFromJsonAsync<List<ExpenseCategory>>("api/ExpenseCategory", cancellationToken);
    }

    public async Task UpdateCategoryAsync(ExpenseCategory category, CancellationToken cancellationToken = default)
    {
        var response = await client.PatchAsJsonAsync("api/ExpenseCategory", category, cancellationToken);
    }

    public async Task DeleteCategoryAsync(long id, CancellationToken cancellationToken = default)
    {
        var response = await client.DeleteAsync($"api/ExpenseCategory/{id}", cancellationToken);
    }

    public async Task CreateExpenseAsync(ExpenseModel request, CancellationToken cancellationToken = default)
    {
        var response = await client.PostAsJsonAsync("api/Expense", request, cancellationToken);
        var content = await response.Content.ReadAsStringAsync();
    }

    public async Task<List<ExpenseModel>> GetExpensesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await client.GetAsync("api/Expense", cancellationToken);
            var content = await response.Content.ReadAsStringAsync();

            return await client.GetFromJsonAsync<List<ExpenseModel>>("api/Expense", cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
