// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Apiaries.Get;
using CleanArchitecture.Applications.Data;
using CleanArchitecture.Domains.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Applications.Apiaries.GetById
{
    internal sealed class GetApiaryByIdQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetApiaryByIdQuery, ApiaryDto>
    {
        public async Task<Result<ApiaryDto>> Handle(GetApiaryByIdQuery request, CancellationToken cancellationToken)
        {
            var apiary = await context.Apiaries
                .Where(apiary => apiary.Id == request.Id)
                .Select(apiary => new ApiaryDto
                {
                    Id = apiary.Id,
                    Name = apiary.Name,
                    Altitude = apiary.Altitude,
                    Latitude = apiary.Latitude,
                    Longitude = apiary.Longitude,
                    Hives = apiary.Hives.Select(h => new HiveDto
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
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (apiary is null)
            {
                return Result.Failure<ApiaryDto>(new Error("Apiary.NotFound", $"Apiary with id {request.Id} not found", ErrorType.NotFound));
            }

            return apiary;
        }
    }
}
