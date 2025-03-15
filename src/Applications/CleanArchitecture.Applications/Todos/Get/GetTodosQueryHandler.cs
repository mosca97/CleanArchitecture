// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Todos.Get
{
    internal sealed class GetTodosQueryHandler(IApplicationDbContext context)
        : IQueryHandler<GetTodosQuery, List<TodoResponse>>
    {
        public async Task<Result<List<TodoResponse>>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await context.TodoItems
            .Select(todoItem => new TodoResponse
            {
                Id = todoItem.Id,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt,
                CompletedAt = todoItem.CompletedAt
            })
            .ToListAsync(cancellationToken);

            return todos;
        }
    }
}
