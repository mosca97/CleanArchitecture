// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using CleanArchitecture.Domains.Todo;
using Mapster;
using Microsoft.EntityFrameworkCore;

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

    public abstract class GenericCreateCommand<TCommand, TDomain>(DbContext context)
        : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TDomain : class, new()
    {
        public async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var domainModel = request.Adapt<TDomain>();

            var set = context.Set<TDomain>();

            set.Add(domainModel);

            await context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }

    public abstract class GenericCreateCommand<TCommand, TDomain, TResponse>(DbContext context)
        : ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TDomain : EntityBase<TResponse>
    {
        public async Task<Result<TResponse>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var domainModel = request.Adapt<TDomain>();

            var set = context.Set<TDomain>();

            set.Add(domainModel);

            await context.SaveChangesAsync(cancellationToken);

            return domainModel.Id;
        }
    }
}
