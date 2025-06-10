// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json.Serialization;
using CleanArchitecture.Applications.Abstractions;
using CleanArchitecture.Applications.Apiaries.Create;
using CleanArchitecture.Applications.Apiaries.Get;
using CleanArchitecture.Presentations;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    public class PatchApiaryRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long Id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Latitude { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Longitude { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Altitude { get; set; }
    }

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiaryController(
        IQueryHandler<GetAllApiariesQuery, List<ApiaryDto>> queryHandler,
        ICommandHandler<CreateApiaryCommand, long> commandHandler) : ControllerBase
    {
        private List<ApiaryApiResponse> apiaries = new List<ApiaryApiResponse>()
        {
            new()
            { Id = 1, Name = "Civitella", Latitude = 1.0, Longitude = 1.0, Altitude = 1.0,
                Hives = new()
                {
                    new() { Id = 1, Name = "ARNIA 001"},
                    new() { Id = 2, Name = "ARNIA 002"},
                    new() { Id = 3, Name = "ARNIA 003"},
                    new() { Id = 4, Name = "ARNIA 004"},
                    new() { Id = 5, Name = "ARNIA 005"}
                }
            },
            new(){ Id = 2, Name = "Polgeto", Latitude = 2.0, Longitude = 2.0, Altitude = 2.0 },
            new(){ Id = 3, Name = "Apiary 3", Latitude = 3.0, Longitude = 3.0, Altitude = 3.0 }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ApiaryApiResponse>))]
        public async Task<IResult> Get(CancellationToken cancellationToken)
        {
            //await commandHandler.Handle(new CreateApiaryCommand("Apiary 1", 1.0, 1.0, 1.0), cancellationToken);
            //var result = await queryHandler.Handle(new GetAllApiariesQuery(), cancellationToken);

            return Results.Ok(apiaries ?? []);

            //var result = await sender.Send(new GetAllApiariesQuery(), cancellationToken);

            //return result.Match(Results.Ok, CustomeResults.Problem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiaryApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetById(long id, CancellationToken cancellationToken)
        {
            return Results.Ok(apiaries.FirstOrDefault(a => a.Id == id));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiaryApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> PatchById(long id, PatchApiaryRequest request, CancellationToken cancellationToken)
        {
            return Results.Ok(apiaries.FirstOrDefault(a => a.Id == id));
        }
    }
}
