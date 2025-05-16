// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Domains.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Apiary> Apiaries { get; set; }
        public DbSet<Hive> Hives { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<MedicalTreatment> Treatments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
