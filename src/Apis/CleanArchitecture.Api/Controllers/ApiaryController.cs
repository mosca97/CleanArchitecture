// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Apiaries.Create;
using CleanArchitecture.Applications.Apiaries.Get;
using CleanArchitecture.Presentations;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiaryController(
        IQueryHandler<GetAllApiariesQuery, List<ApiaryDto>> queryHandler,
        ICommandHandler<CreateApiaryCommand, long> commandHandler) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ApiaryApiResponse>))]
        public async Task<IResult> Get(CancellationToken cancellationToken)
        {
            await commandHandler.Handle(new CreateApiaryCommand("Apiary 1", 1.0, 1.0, 1.0), cancellationToken);
            var result = await queryHandler.Handle(new GetAllApiariesQuery(), cancellationToken);

            List<ApiaryApiResponse> items = new()
            {
                new()
                { Id = 1, Name = "Apiary 1", Latitude = 1.0, Longitude = 1.0, Altitude = 1.0,
                    Hives = new()
                    {
                        new() { Id = 1, Name = "ARNIA 001"}
                    }
                },
                new(){ Id = 2, Name = "Apiary 2", Latitude = 2.0, Longitude = 2.0, Altitude = 2.0 },
                new(){ Id = 3, Name = "Apiary 3", Latitude = 3.0, Longitude = 3.0, Altitude = 3.0 }
            };

            return Results.Ok(items);

            //var result = await sender.Send(new GetAllApiariesQuery(), cancellationToken);

            //return result.Match(Results.Ok, CustomeResults.Problem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiaryApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetById(long id, CancellationToken cancellationToken)
        {
            ApiaryApiResponse item = new()
            {
                Id = 1,
                Name = "Apiary 1",
                Latitude = 1.0,
                Longitude = 1.0,
                Altitude = 1.0,
                Hives = new()
                    {
                        new() { Id = 1, Name = "ARNIA 001"}
                    }
            };

            return Results.Ok(item);
        }
    }
}
