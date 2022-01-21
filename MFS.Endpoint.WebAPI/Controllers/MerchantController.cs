using MFS.Application.Interfaces.Common;
using MFS.Domain.Common;
using MFS.Domain.MerchantAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFS.Endpoint.WebAPI.Controllers
{
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IRepository<Merchant> _MerchantRepository;

        public MerchantController(IRepository<Merchant> MerchantRepository)
        {
            _MerchantRepository = MerchantRepository;
        }

        public MessageDto CreateMerchant([FromBody]MerchantCommand merchant)
        {
            var MerchatnInfo = Merchant.Create(merchant);

            var id = _MerchantRepository.Insert(MerchatnInfo);

            return new MessageDto
            {
                HasError=false,
                Message ="Merchant Added Successfully",
                result = id.ToString()
            };
        }
    }
}
