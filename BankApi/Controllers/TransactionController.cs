using Application.AccountComands.GetAccountComand;
using Application.AccountComands.UpdateAccountComand;
using Application.TransactionComands;
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransactionController>
        [HttpPost("{accountId}")]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
        [ProducesResponseType<Guid>(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> CreateTransaction([FromRoute]Guid accountId, CreateTransactionRequest request, [FromServices]ICreateTransactionComandHandler handler, CancellationToken cancellationToken)
        {
            UpdateAccountComand updateAccountComand = new(accountId);
            try
            {
                CreateTransactionComand comand = new(accountId, request.Amount, DateTime.Now, request.Direction);
                Guid transaction = await handler.HandleAsync(comand, cancellationToken);
                return Created(string.Empty, transaction);          
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }           
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
