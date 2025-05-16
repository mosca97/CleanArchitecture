// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using CleanArchitecture.Domains.Core.Entities;

namespace CleanArchitecture.Applications.Apiaries.Create
{
    internal sealed class CreateApiaryCommandHandler(IApplicationDbContext context)
        : ICommandHandler<CreateApiaryCommand, long>
    {
        public async Task<Result<long>> Handle(CreateApiaryCommand request, CancellationToken cancellationToken)
        {
            var apiary = new Apiary()
            {
                Name = request.Name,
                Altitude = request.Altitude,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                Hives = new List<Hive>()
            };

            context.Apiaries.Add(apiary);

            await context.SaveChangesAsync(cancellationToken);

            return apiary.Id;
        }
    }
}
