// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Todos.Complete
{
    internal sealed class CompeteTodoCommandHandler(IApplicationDbContext context)
        : ICommandHandler<CompleteTodoCommand>
    {
        public async Task<Result> Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await context.TodoItems.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (todo is null)
            {
                return Result.Failure(new Error("TodoItem.NotFound", "Todo item not found", ErrorType.NotFound));
            }

            if (todo.IsCompleted)
            {
                return Result.Failure(new Error("TodoItem.AlreadyCompleted", "Todo item already completed", ErrorType.Problem));
            }

            todo.IsCompleted = true;
            todo.CompletedAt = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
