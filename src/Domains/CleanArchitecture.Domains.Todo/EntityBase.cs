// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Domains.Todo
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
