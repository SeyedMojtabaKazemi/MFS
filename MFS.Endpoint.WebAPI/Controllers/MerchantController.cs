using MFS.Application.Services.Commands.MerchantAggregate;
using MFS.Application.Services.Queries;
using MFS.Contract;
using MFS.Contract.CommssionAggregate;
using MFS.Contract.MerchantAggregate;
using MFS.Domain.CommissionAggregate;
using MFS.Domain.Common;
using MFS.Domain.MerchantAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MFS.Endpoint.WebAPI.Controllers
{
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantServiceCommand _merchantServiceCommand;
        private readonly IMerchantServiceQuery _merchantServiceQuery;
        private readonly ICommissionServiceCommand _commissionServiceCommand;

        public MerchantController(IMerchantServiceCommand merchantServiceCommand,
                                  IMerchantServiceQuery merchantServiceQuery,
                                  ICommissionServiceCommand commissionServiceCommand)
        {
            _merchantServiceCommand = merchantServiceCommand;
            _merchantServiceQuery = merchantServiceQuery;
            _commissionServiceCommand = commissionServiceCommand;
        }

        [HttpPost]
        [Route("api/CreateMerchant")]
        public IActionResult CreateMerchant(MerchantCreateDto merchant)
        {
            var id = _merchantServiceCommand.CreateMerchant(merchant);

            return Ok(new MessageDto
            {
                HasError = false,
                Message = "Merchant Added Successfully",
                result = id.ToString()
            });
        }

        [HttpPatch]
        [Route("api/UpdateMerchant")]
        public IActionResult UpdateMerchant(MerchantDto merchant)
        {
            _merchantServiceCommand.UpdateMerchant(merchant);

            return Ok(new MessageDto
            {
                HasError = false,
                Message = "Merchant Updated Successfully"
            });
        }

        [HttpGet]
        [Route("api/RemoveMerchant/{merchantId}")]
        public IActionResult RemoveMerchant(int merchantId)
        {
            _merchantServiceCommand.RemoveMerchant(merchantId);

            return Ok(new MessageDto
            {
                HasError = false,
                Message = "Merchant Removed Successfully"
            });
        }

        [HttpPost]
        [Route("api/GetMerchantList")]
        public IActionResult GetMerchantList(MerchantDto merchant) =>
            Ok(_merchantServiceQuery.GetMerchantList(merchant));


        [HttpPost]
        [Route("api/CalcCommission")]
        public IActionResult CalculateMerchantCommission(CommissionDto commission)
        {
            _commissionServiceCommand.SubmitMerchantCommission(commission);

            return Ok(new MessageDto
            {
                HasError = false,
                Message = "Commission Calculated sucessfully"
            });
        }

    }
}
