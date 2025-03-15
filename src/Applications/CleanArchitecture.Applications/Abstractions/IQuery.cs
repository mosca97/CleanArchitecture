// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Core;
using MediatR;

namespace CleanArchitecture.Applications.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
