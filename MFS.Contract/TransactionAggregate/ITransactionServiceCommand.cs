using MFS.Domain.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Contract.TransactionAggregate
{
    public interface ITransactionServiceCommand
    {
        int CreateTransaction(TransactionCreateDto transaction);
        void RemoveTransaction(int transactionId);

    }
}
