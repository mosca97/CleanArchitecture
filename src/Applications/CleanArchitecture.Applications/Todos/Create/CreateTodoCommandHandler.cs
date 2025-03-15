// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using CleanArchitecture.Domains.Todo;

namespace CleanArchitecture.Applications.Todos.Create
{
    internal sealed class CreateTodoCommandHandler(IApplicationDbContext context)
        : ICommandHandler<CreateTodoCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new TodoItem
            {
                Description = request.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            context.TodoItems.Add(todo);

            await context.SaveChangesAsync(cancellationToken);

            return todo.Id;
        }
    }
}
