// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Presentations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HiveController(ISender sender) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HiveApiResponse>))]
        public async Task<IResult> Get(CancellationToken cancellationToken)
        {

            List<HiveApiResponse> items = new()
            {
                new(){ Id = 1, ApiaryId = 1, Name = "Hive 1", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 2, ApiaryId = 1, Name = "Hive 3", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 3, ApiaryId = 1, Name = "Hive 4", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 4, ApiaryId = 1, Name = "Hive 5", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 5, ApiaryId = 1, Name = "Hive 6", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 6, ApiaryId = 1, Name = "Hive 7", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 7, ApiaryId = 1, Name = "Hive 8", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 8, ApiaryId = 1, Name = "Hive 2", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() }
            };

            return Results.Ok(items);

            //var result = await sender.Send(new GetAllApiariesQuery(), cancellationToken);

            //return result.Match(Results.Ok, CustomeResults.Problem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HiveApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetById(long id, CancellationToken cancellationToken)
        {
            return Results.Ok(new HiveApiResponse() { Id = 1, ApiaryId = 1, Name = "Hive 1", QueeBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() });
        }

        [HttpPost("{id}/Note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HiveApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> AddNote(long id, NoteApiResponse note, CancellationToken cancellationToken)
        {
            return Results.Ok();
        }
    }
}
