// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Presentations;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    public class QueenBeeYearRequest
    {
        public string Year { get; set; }
    }
    public class HiveNameRequest
    {
        public string Name { get; set; }
    }
    public class TreatmentRequest
    {
        public string Description { get; set; }
        public DateOnly? Date { get; set; }
    }

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HiveController : ControllerBase
    {
        List<HiveApiResponse> items = new()
            {
                new(){ Id = 1, ApiaryId = 1, Name = "Hive 1", QueenBeeYear = "2023", Notes = new List<NoteApiResponse>()
                {
                    new()
                    {
                        Id = 1,
                        Date = new DateOnly(2025, 4, 27),
                        Description = "Regina vergina, ricontrollare"
                    }
                },
                Treatments = new List<TreatmentApiResponse>()
                {
                    new()
                    {
                        Id = 1,
                        Date = new DateOnly(2025, 4, 27),
                        Description = "Acido ossalico nebulizzato"
                    }
                } },
                new(){ Id = 2, ApiaryId = 1, Name = "Hive 3", QueenBeeYear = "0", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 3, ApiaryId = 1, Name = "Hive 4", QueenBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 4, ApiaryId = 1, Name = "Hive 5", QueenBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 5, ApiaryId = 1, Name = "Hive 6", QueenBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 6, ApiaryId = 1, Name = "Hive 7", QueenBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 7, ApiaryId = 1, Name = "Hive 8", QueenBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() },
                new(){ Id = 8, ApiaryId = 1, Name = "Hive 2", QueenBeeYear = "2023", Notes = new List<NoteApiResponse>(), Treatments = new List<TreatmentApiResponse>() }
            };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HiveApiResponse>))]
        public async Task<IResult> Get(CancellationToken cancellationToken)
        {
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
            return Results.Ok(items.FirstOrDefault(h => h.Id == id));
        }

        [HttpPost("{id}/Note")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HiveApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> AddNote(long id, NoteApiResponse note, CancellationToken cancellationToken)
        {
            var hive = items.FirstOrDefault(h => h.Id == id);

            hive.Notes.Add(new()
            {
                Id = 1,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Description = note.Description
            });

            return Results.Ok(hive);
        }

        [HttpPost("{id}/Treatment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HiveApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> AddTreatment(long id, TreatmentRequest request, CancellationToken cancellationToken)
        {
            var hive = items.FirstOrDefault(h => h.Id == id);

            hive.Treatments.Add(new()
            {
                Id = 1,
                Date = request.Date ?? DateOnly.FromDateTime(DateTime.Now),
                Description = request.Description
            });

            return Results.Ok(hive);
        }

        [HttpPut("{id}/QueenBeeYear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HiveApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> ChangeQueenBeeYear(long id, QueenBeeYearRequest request, CancellationToken cancellationToken)
        {
            var hive = items.FirstOrDefault(h => h.Id == id);

            hive.QueenBeeYear = request.Year;

            return Results.Ok();
        }

        [HttpPut("{id}/HiveName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HiveApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> ChangeHiveName(long id, HiveNameRequest request, CancellationToken cancellationToken)
        {
            var hive = items.FirstOrDefault(h => h.Id == id);

            hive.Name = request.Name;

            return Results.Ok(hive);
        }
    }
}
