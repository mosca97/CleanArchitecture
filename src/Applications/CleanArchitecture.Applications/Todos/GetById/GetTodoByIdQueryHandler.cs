// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Todos.GetById
{
    internal class GetTodoByIdQueryHandler(IApplicationDbContext context)
        : IQueryHandler<GetTodoByIdQuery, TodoResponse>
    {
        public async Task<Result<TodoResponse>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await context.TodoItems
                .Where(todo => todo.Id == request.Id)
                .Select(todo => new TodoResponse
                {
                    Id = todo.Id,
                    Description = todo.Description,
                    CompletedAt = todo.CompletedAt,
                    IsCompleted = todo.IsCompleted,
                    CreatedAt = todo.CreatedAt
                })
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (todo is null)
            {
                return Result.Failure<TodoResponse>(new Error("TodoItem.NotFound", $"Todo item with id {request.Id} not found", ErrorType.NotFound));
            }

            return todo;
        }
    }
}
