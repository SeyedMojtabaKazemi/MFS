using AutoMapper;
using MFS.Contract.TransactionAggregate;
using MFS.Domain.Common;
using MFS.Domain.TransactionAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFS.Endpoint.WebAPI.Controllers
{
    [ApiController]
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

        [HttpPost]
        [Route("/api/GetTransactionList")]
        public IActionResult GetTransaction(TransactionSearchDto searchDto) =>
            Ok(_mapper.Map<List<TransactionDto>>(_transactionServiceQuery.GetTransactionList(searchDto)));


        [HttpPost]
        [Route("/api/CreateTransaction")]
        public IActionResult CreateTransaction(TransactionCreateDto createDto)
        {
            int id = _transactionServiceCommand.CreateTransaction(createDto);

            return Ok(new MessageDto
            {
                HasError = false,
                Message = "Transaction Added Successfully",
                result = id.ToString()
            });
        }

        [HttpGet]
        [Route("/api/RemoveTransaction/{transactionId}")]
        public IActionResult RemoveTransaction(int transactionId)
        {
            _transactionServiceCommand.RemoveTransaction(transactionId);

            return Ok(new MessageDto
            {
                HasError = false,
                Message = "Transaction Removed Successfully"
            });
        }
    }
}
