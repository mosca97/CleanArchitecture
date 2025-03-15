// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Api.Models.Todos.Requests;
using CleanArchitecture.Applications.Todos.Complete;
using CleanArchitecture.Applications.Todos.Create;
using CleanArchitecture.Applications.Todos.Get;
using CleanArchitecture.Applications.Todos.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ISender sender)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> Get(CancellationToken cancellationToken)
        {
            var command = new GetTodosQuery();

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var command = new GetTodoByIdQuery(id);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateTodoRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateTodoCommand() { Description = request.Description };

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        [HttpPut("{id}/complete")]
        public async Task<IResult> Put(Guid id, CancellationToken cancellationToken)
        {
            var command = new CompleteTodoCommand(id);

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomeResults.Problem);
        }
    }
}
