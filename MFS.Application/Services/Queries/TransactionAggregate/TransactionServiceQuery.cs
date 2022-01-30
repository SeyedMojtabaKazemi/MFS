using AutoMapper;
using MFS.Application.Common;
using MFS.Contract;
using MFS.Contract.TransactionAggregate;
using MFS.Domain.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Application.Services.Queries.TransactionAggregate
{
    public class TransactionServiceQuery : ITransactionServiceQuery
    {

        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionServiceQuery(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<Transaction> GetTransactionList(TransactionSearchDto searchDto)
        {
            Expression<Func<Transaction, bool>> query = q => true;

            if (searchDto.TransactionId > 0)
            {
                Expression<Func<Transaction, bool>> newCond = q => q.Id == searchDto.TransactionId;
                query = ExpressionExtension<Transaction>.AndAlso(query, newCond);
            }

            if (searchDto.MerchantId > 0)
            {
                Expression<Func<Transaction, bool>> newCond = q => q.MerchantId == searchDto.MerchantId;
                query = ExpressionExtension<Transaction>.AndAlso(query, newCond);
            }

            if (searchDto.FromDate != null)
            {
                Expression<Func<Transaction, bool>> newCond = q => q.CreateDate.Date >= searchDto.FromDate.Value.Date;
                query = ExpressionExtension<Transaction>.AndAlso(query, newCond);
            }

            if (searchDto.ToDate != null)
            {
                Expression<Func<Transaction, bool>> newCond = q => q.CreateDate.Date >= searchDto.ToDate.Value.Date;
                query = ExpressionExtension<Transaction>.AndAlso(query, newCond);
            }

            var lst = _transactionRepository.GetExpression(query, "Merchant").ToList();

            return lst;
        }
    }
}
