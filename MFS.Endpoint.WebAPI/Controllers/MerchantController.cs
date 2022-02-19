using AutoMapper;
using MFS.Contract.CommssionAggregate;
using MFS.Contract.MerchantAggregate;
using MFS.Domain.CommissionAggregate;
using MFS.Domain.Common;
using MFS.Domain.MerchantAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MFS.Endpoint.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantServiceCommand _merchantServiceCommand;
        private readonly IMerchantServiceQuery _merchantServiceQuery;
        private readonly ICommissionServiceCommand _commissionServiceCommand;
        private readonly IMapper _mapper;


        public MerchantController(IMerchantServiceCommand merchantServiceCommand,
                                  IMerchantServiceQuery merchantServiceQuery,
                                  ICommissionServiceCommand commissionServiceCommand,
                                  IMapper mapper)
        {
            _merchantServiceCommand = merchantServiceCommand;
            _merchantServiceQuery = merchantServiceQuery;
            _commissionServiceCommand = commissionServiceCommand;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(MerchantDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpPost("Create")]
        public MerchantDto CreateMerchant(MerchantCreateDto merchant) =>
            _merchantServiceCommand.CreateMerchant(merchant);


        [ProducesResponseType(typeof(MerchantDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public MerchantDto UpdateMerchant(MerchantDto merchant) =>
            _merchantServiceCommand.UpdateMerchant(merchant);


        [ProducesResponseType(typeof(MerchantDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpDelete("{merchantId}")]
        public MerchantDto RemoveMerchant(int merchantId) =>
            _merchantServiceCommand.RemoveMerchant(merchantId);


        [ProducesResponseType(typeof(MerchantDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpPost("GetList")]
        public List<MerchantDto> GetMerchantList(MerchantDto merchant) =>
            _mapper.Map<List<MerchantDto>>(_merchantServiceQuery.GetMerchantList(merchant));


        [ProducesResponseType(typeof(MerchantDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [HttpPost("CalcCommission")]
        public CommissionDto CalculateMerchantCommission(CommissionDto commission) =>
            _commissionServiceCommand.SubmitMerchantCommission(commission);

    }
}
