using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.MerchantAggregate
{
    public class MerchantDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string NationalCode { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime ModifyDate { get; set; }
        //public bool IsDeleted { get; set; }
        public int MerchantDiscount { get; set; }
    }
}