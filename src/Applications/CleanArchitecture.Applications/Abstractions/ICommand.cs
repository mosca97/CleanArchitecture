// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Applications.Abstractions
{
    public interface IBaseCommand;

    public interface ICommand : IBaseCommand;

    public interface ICommand<TResponse> : IBaseCommand;
}
