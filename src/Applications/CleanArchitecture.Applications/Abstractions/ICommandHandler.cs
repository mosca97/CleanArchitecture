// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Core;

namespace CleanArchitecture.Applications.Abstractions
{
    public interface ICommandHandler<in TCommand>
    {
        Task<Result> Handle(TCommand request, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    {
        Task<Result<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
