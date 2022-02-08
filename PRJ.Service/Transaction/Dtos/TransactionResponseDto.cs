using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.Transaction.Dtos
{
    public class TransactionResponseDto
    {
        public int responseCode { get; set; }
        public int approvalCode { get; set; }
        public string dateTime { get; set; }
    }
}
