// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Apiaries.Get;

namespace CleanArchitecture.Applications.Apiaries.GetById
{
    public record GetApiaryByIdQuery(long Id) : IQuery<ApiaryDto>;
}
