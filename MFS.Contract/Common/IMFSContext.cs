﻿using MFS.Domain.MerchantAggregate;
using MFS.Domain.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Contract
{
    public interface IMFSContext
    {
        DbSet<Merchant> Merchants { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}
