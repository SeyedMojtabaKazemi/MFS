﻿using MFS.Domain.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Contract.TransactionAggregate
{
    public interface ITransactionServiceQuery
    {
        List<Transaction> GetTransactionList(TransactionSearchDto searchDto);
    }
}
