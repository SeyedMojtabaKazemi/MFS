using AutoMapper;
using MFS.Contract.TransactionAggregate;
using MFS.Domain.Common;
using MFS.Domain.TransactionAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MFS.Endpoint.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransactionServiceQuery _transactionServiceQuery;
        private readonly ITransactionServiceCommand _transactionServiceCommand;

        public TransactionController(IMapper mapper,
                                     ITransactionServiceQuery transactionServiceQuery,
                                     ITransactionServiceCommand transactionServiceCommand)
        {
            _mapper = mapper;
            _transactionServiceCommand = transactionServiceCommand;
            _transactionServiceQuery = transactionServiceQuery;
        }

        [ProducesResponseType(typeof(TransactionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpPost("GetList")]
        public List<TransactionDto> GetTransaction(TransactionSearchDto searchDto) =>
            _mapper.Map<List<TransactionDto>>(_transactionServiceQuery.GetTransactionList(searchDto));


        [ProducesResponseType(typeof(TransactionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpPost("Create")]
        public TransactionDto CreateTransaction(TransactionCreateDto createDto) =>
             _transactionServiceCommand.CreateTransaction(createDto);


        [ProducesResponseType(typeof(TransactionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpDelete("{transactionId}")]
        public TransactionDto RemoveTransaction(int transactionId) =>
            _transactionServiceCommand.RemoveTransaction(transactionId);

    }
}
