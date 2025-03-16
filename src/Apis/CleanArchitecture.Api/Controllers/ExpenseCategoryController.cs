// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Applications.Budget.Catergories.Create;
using CleanArchitecture.Applications.Budget.Catergories.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Api.Controllers
{
    public class PostRequest
    {
        public string Name { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoryController(ISender sender)
        : ControllerBase
    {
        // GET: api/<ExpenseCategoryController>
        [HttpGet]
        public async Task<IResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetCategoriesQuery();

            var result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        // GET api/<ExpenseCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExpenseCategoryController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] PostRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateCategoryCommand()
            {
                Name = request.Name
            };

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        // PUT api/<ExpenseCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpenseCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
