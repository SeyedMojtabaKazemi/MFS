using MFS.Contract;
using MFS.Domain.MerchantAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MFS.Application.Common;
using MFS.Contract.MerchantAggregate;

namespace MFS.Application.Services.Queries
{
    public class MerchantServiceQuery : IMerchantServiceQuery
    {
        private readonly IMFSContext _context;

        public MerchantServiceQuery(IMFSContext context)
        {
            _context = context;
        }

        public List<Merchant> GetMerchantList(MerchantDto merchant)
        {
            Expression<Func<Merchant, bool>> query = q => true;

            if (merchant.Id > 0)
            {
                Expression<Func<Merchant, bool>> newCond = q => q.Id == merchant.Id;
                query = ExpressionExtension<Merchant>.AndAlso(query, newCond);
            }

            if (!string.IsNullOrEmpty(merchant.FirstName))
            {
                Expression<Func<Merchant, bool>> newCond = q => q.FirstName == merchant.FirstName;
                query = ExpressionExtension<Merchant>.AndAlso(query, newCond);
            }

            if (!string.IsNullOrEmpty(merchant.LastName))
            {
                Expression<Func<Merchant, bool>> newCond = q => q.LastName == merchant.LastName;
                query = ExpressionExtension<Merchant>.AndAlso(query, newCond);
            }

            if (!string.IsNullOrEmpty(merchant.Email))
            {
                Expression<Func<Merchant, bool>> newCond = q => q.Email == merchant.Email;
                query = ExpressionExtension<Merchant>.AndAlso(query, newCond);
            }

            if (!string.IsNullOrEmpty(merchant.NationalCode))
            {
                Expression<Func<Merchant, bool>> newCond = q => q.NationalCode == merchant.NationalCode;
                query = ExpressionExtension<Merchant>.AndAlso(query, newCond);
            }

            if (!string.IsNullOrEmpty(merchant.PhoneNo))
            {
                Expression<Func<Merchant, bool>> newCond = q => q.PhoneNo == merchant.PhoneNo;
                query = ExpressionExtension<Merchant>.AndAlso(query, newCond);
            }

            var lst = _context.Merchants.Include(q => q.MerchantDiscount).Where(query).ToList();

            return lst;
        }
    }
}