// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Budget;
using CleanArchitecture.Domains.Core;

namespace CleanArchitecture.Applications.Budget.Expenses.Create
{
    internal sealed class CreateExpenseCommandHandler(IApplicationDbContext context)
        : ICommandHandler<CreateExpenseCommand, long>
    {
        public async Task<Result<long>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense()
            {
                Title = request.Title,
                CategoryId = request.CategoryId,
                Money = request.Money,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            context.Expenses.Add(expense);

            await context.SaveChangesAsync(cancellationToken);

            return expense.Id;
        }
    }
}
