using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFS.Domain.Common
{
    public class MessageDto
    {
        public string result { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}
