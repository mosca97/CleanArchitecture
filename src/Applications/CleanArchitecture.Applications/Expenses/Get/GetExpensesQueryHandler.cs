// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Expenses.Get
{
    internal sealed class GetExpensesQueryHandler(IApplicationDbContext context)
        : IQueryHandler<GetExpensesQuery, List<ExpenseResponse>>
    {
        public async Task<Result<List<ExpenseResponse>>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            return await context.Expenses
                .AsNoTracking()
                .Select(e => new ExpenseResponse
                {
                    Id = e.Id,
                    Description = e.Description,
                    CategoryId = e.CategoryId,
                    CreatedAt = e.CreatedAt,
                    Money = e.Money,
                    Title = e.Title
                })
                .ToListAsync(cancellationToken);
        }
    }
}
