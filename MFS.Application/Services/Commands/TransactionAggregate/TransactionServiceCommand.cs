using MFS.Contract;
using MFS.Contract.TransactionAggregate;
using MFS.Domain.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Application.Services.Commands.TransactionAggregate
{
    public class TransactionServiceCommand : ITransactionServiceCommand
    {

        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionServiceCommand(IRepository<Transaction> transactionRepository,
                                         IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public int CreateTransaction(TransactionCreateDto transaction)
        {
            var TransactionEntity = Transaction.Create(transaction);

            _transactionRepository.Insert(TransactionEntity);
            _unitOfWork.SaveChanges();

            return TransactionEntity.Id;
        }

        public void RemoveTransaction(int transactionId)
        {
            var TransactionEntity = _transactionRepository.GetExpression(q => q.Id == transactionId).FirstOrDefault();

            if (TransactionEntity == null)
                throw new Exception("Transaction Not Exists");

            _transactionRepository.Remove(TransactionEntity);
            _unitOfWork.SaveChanges();
        }
    }
}
