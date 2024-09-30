using Application.AccountComands.CreateAccountComand;
using Application.AccountComands.DeleteAccountComand;
using Application.AccountComands.GetAccountComand;
using BankApi.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // GET api/<AccountController>/5
        [HttpGet("{accountId}")]
        [ProducesResponseType<Guid>(StatusCodes.Status200OK)]
        [ProducesResponseType<Guid>(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AccountDto>> GetAccount([FromRoute]Guid accountId, IGetAccountComandHandler handler,CancellationToken cancellationToken)
        {
            GetAccountComand comand = new(accountId);
            try
            {
                Account account = await handler.HandleAsync(comand, cancellationToken);                   

                Account.AccountType accountType = account is CurrentAccount ? Account.AccountType.CurrentAccount
                                                                            : Account.AccountType.SavingAccount;
                AccountDto accountDto = new(account.UserId, accountType, account.Balance);
                return Ok(accountDto);
            
            } catch(KeyNotFoundException)
            {
                return NotFound();
            }            
        }

        // POST api/<AccountController>
        [HttpPost("{userId}")]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> CreateAccount([FromRoute] Guid userId, [FromServices]ICreateAccountComandHandler handler, CancellationToken cancellationToken)
        {
            try
            {
                CreateAccountComand comand = new(userId);
                Guid accountId = await handler.HandleAsync(comand, cancellationToken);
                return Created(string.Empty, accountId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("user not found");
            }          
        }

        // PUT api/<AccountController>/5
        [HttpPatch("{id}")]
        /*public async Task <ActionResult> UpdateAccount([FromRoute] Guid id,[FromServices]ICreateTransactionComandHandler createTransaction, [FromServices]IUpdateAccountComandHandler handler, IGetAccountComandHandler getAccount,UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            GetAccountComand getAccountComand = new(id);
            CreateTransactionComand transactionComand = new CreateTransactionComand();
            Account? accountGetted = await getAccount.HandleAsync(getAccountComand, cancellationToken);
            createTransaction.HandleAsync(getAccountComand, cancellationToken);
            UpdateAccountComand updateAccountComand = new(id);
            //if(accountGetted.Balance != )

            await handler.HandleAsync(updateAccountComand, cancellationToken);
        }*/

        // DELETE api/<AccountController>/5
        [HttpDelete("{accountId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAccount([FromRoute] Guid accountId, [FromServices]IDeleteAccountComandHandler handler, CancellationToken cancellationToken)
        {
            DeleteAccountComand comand = new(accountId);
            await handler.HandleAsync(comand, cancellationToken);
            return NoContent();
        }
    }
}
