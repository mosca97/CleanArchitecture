﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;

namespace CleanArchitecture.Applications.Apiaries.Get
{
    public record GetAllApiariesQuery() : IQuery<List<ApiaryDto>>;
}
