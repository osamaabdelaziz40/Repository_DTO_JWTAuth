using PRJ.Service.Transaction.Dtos;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.Transaction
{
    public interface ITransactionService
    {
        OutputDTO<TransactionResponseDto> Submit(TransactionRequestDto request);
    }
}
