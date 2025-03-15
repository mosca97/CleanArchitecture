// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Api.Models.Todos.Requests;
using CleanArchitecture.Applications.Todo.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ISender sender)
        : ControllerBase
    {
        // GET: api/<TodoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateTodoRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateTodoCommand() { Description = request.Description };

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
