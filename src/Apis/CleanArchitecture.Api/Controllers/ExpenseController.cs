// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Applications.Expenses.Create;
using CleanArchitecture.Applications.Expenses.Get;
using CleanArchitecture.Domains.Budget.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Api.Controllers
{
    public class ExpenseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController(ISender sender) : ControllerBase
    {
        // GET: api/<ExpenseController>
        [HttpGet]
        public async Task<IResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetExpensesQuery();

            var result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] ExpenseRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateExpenseCommand(
                request.CategoryId,
                request.Name,
                request.Description,
                new Money(request.Amount, request.Currency));

            var result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomeResults.Problem);
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
