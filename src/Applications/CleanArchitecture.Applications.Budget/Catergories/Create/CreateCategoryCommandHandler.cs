// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Budget;
using CleanArchitecture.Domains.Core;

namespace CleanArchitecture.Applications.Budget.Catergories.Create
{
    internal sealed class CreateCategoryCommandHandler(IApplicationDbContext context)
        : ICommandHandler<CreateCategoryCommand, int>
    {
        public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new ExpenseCategory()
            {
                Name = request.Name
            };

            context.Categories.Add(category);

            await context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
