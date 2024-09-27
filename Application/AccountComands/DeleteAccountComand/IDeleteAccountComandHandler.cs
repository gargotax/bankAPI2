using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountComands.DeleteAccountComand
{
    public interface IDeleteAccountComandHandler
    {
        Task HandleAsync(DeleteAccountComand comand, CancellationToken cancellationToken);
    }
}
