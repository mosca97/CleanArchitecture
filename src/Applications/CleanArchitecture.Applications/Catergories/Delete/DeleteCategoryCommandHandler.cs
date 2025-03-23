// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Budget.Catergories.Delete
{
    internal sealed class DeleteCategoryCommandHandler(IApplicationDbContext context)
        : ICommandHandler<DeleteCategoryCommand>
    {
        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            if (category is null)
            {
                return Result.Failure(new("Category.NotFound", $"Category {request.Id} not found", ErrorType.NotFound));
            }

            category.Id = request.Id;
            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow;

            context.Categories.Update(category);

            await context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
