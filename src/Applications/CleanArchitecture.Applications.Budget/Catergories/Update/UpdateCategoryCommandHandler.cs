// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Budget.Catergories.Update
{
    internal sealed class UpdateCategoryCommandHandler(IApplicationDbContext context)
        : ICommandHandler<UpdateCategoryCommand>
    {
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (category is null)
                {
                    return Result.Failure(new("Category.NotFound", $"Category {request.Id} not found", ErrorType.NotFound));
                }

                category.Name = request.Name;
                context.Categories.Update(category);

                await context.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new("Category.UpdateFailed", ex.Message, ErrorType.Problem));
            }
        }
    }
}
