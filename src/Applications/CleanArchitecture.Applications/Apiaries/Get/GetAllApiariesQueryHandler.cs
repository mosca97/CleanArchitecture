// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Apiaries.Get
{
    internal sealed class GetAllApiariesQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetAllApiariesQuery, List<ApiaryDto>>
    {
        public async Task<Result<List<ApiaryDto>>> Handle(GetAllApiariesQuery request, CancellationToken cancellationToken)
        {
            return await context.Apiaries
                .AsNoTracking()
                .Select(e => new ApiaryDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Altitude = e.Altitude,
                    Latitude = e.Latitude,
                    Longitude = e.Longitude,
                    Hives = e.Hives.Select(h => new HiveDto
                    {
                        Id = h.Id,
                        Name = h.Name,
                        HiveType = h.HiveType,
                        QueeBeeYear = h.QueeBeeYear,
                        Notes = h.Notes
                                .Select(n => new NoteDto
                                {
                                    Id = n.Id,
                                    Date = n.Date,
                                    Description = n.Description
                                })
                                .ToList(),
                        Treatments = h.Treatments
                                .Select(t => new MedicalTreatmentDto
                                {
                                    Id = t.Id,
                                    Date = t.Date,
                                    Description = t.Description
                                })
                                .ToList()
                    })
                        .ToList()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
