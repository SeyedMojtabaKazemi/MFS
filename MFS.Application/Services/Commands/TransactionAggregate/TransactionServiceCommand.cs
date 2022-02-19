using AutoMapper;
using MFS.Contract;
using MFS.Contract.TransactionAggregate;
using MFS.Domain.TransactionAggregate;
using System;
using System.Linq;

namespace MFS.Application.Services.Commands.TransactionAggregate
{
    public class TransactionServiceCommand : ITransactionServiceCommand
    {

        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionServiceCommand(IRepository<Transaction> transactionRepository,
                                         IUnitOfWork unitOfWork,
                                         IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TransactionDto CreateTransaction(TransactionCreateDto transaction)
        {
            var TransactionEntity = Transaction.Create(transaction);

            _transactionRepository.Insert(TransactionEntity);
            _unitOfWork.SaveChanges();

            return _mapper.Map<TransactionDto>(TransactionEntity);
        }

        public TransactionDto RemoveTransaction(int transactionId)
        {
            var TransactionEntity = _transactionRepository.GetExpression(q => q.Id == transactionId).FirstOrDefault();

            if (TransactionEntity == null)
                throw new Exception("Transaction Not Exists");

            _transactionRepository.Remove(TransactionEntity);
            _unitOfWork.SaveChanges();

            return _mapper.Map<TransactionDto>(TransactionEntity);

        }
    }
}
