using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Error
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}
