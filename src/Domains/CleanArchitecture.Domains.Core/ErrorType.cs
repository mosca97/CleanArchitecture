// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Domains.Core
{
    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
        Problem = 2,
        NotFound = 3,
        Conflict = 4
    }
}
