// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Budget.Catergories.Get
{
    internal sealed class GetCategoriesQueryHandler(IApplicationDbContext context)
        : IQueryHandler<GetCategoriesQuery, List<ExpenseCategoryResponse>>
    {
        public async Task<Result<List<ExpenseCategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await context.Categories
                .Select(c => new ExpenseCategoryResponse
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync(cancellationToken);
        }
    }
}
