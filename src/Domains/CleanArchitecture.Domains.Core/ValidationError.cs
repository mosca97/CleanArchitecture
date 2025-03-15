// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Domains.Core
{
    public sealed record ValidationError : Error
    {
        public ValidationError(Error[] errors)
            : base(
                "Validation.General",
                "One or more validation errors occurred",
                ErrorType.Validation)
        {
            Errors = errors;
        }

        public Error[] Errors { get; }

        public static ValidationError FromResults(IEnumerable<Result> results) =>
            new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
    }
}
