using PRJ.Service.RSA;
using PRJ.Service.Transaction.Dtos;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly IRsaHelper _rsaHelper;
        public TransactionService(IRsaHelper rsaHelper)
        {
            _rsaHelper = rsaHelper;
        }

        public OutputDTO<TransactionResponseDto> Submit(TransactionRequestDto dto)
        {
            try
            {
                var systemTraceNr = _rsaHelper.Decrypt(dto.SystemTraceNr.ToString());
                var processingCode = _rsaHelper.Decrypt(dto.ProcessingCode.ToString());
                var functionCode = _rsaHelper.Decrypt(dto.FunctionCode.ToString());
                var currencyCode = _rsaHelper.Decrypt(dto.CurrencyCode.ToString());
                var cardNo = _rsaHelper.Decrypt(dto.CardNo.ToString());
                var cardHolder = _rsaHelper.Decrypt(dto.CardHolder.ToString());
                var amountTrxn = _rsaHelper.Decrypt(dto.AmountTrxn.ToString());

                return Output.Handler<TransactionResponseDto>(ResponseMessagesCode.ADD, new TransactionResponseDto() {
                 dateTime = DateTime.UtcNow.ToShortDateString(),
                 responseCode = 00,
                 approvalCode = 123123
                });
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return Output.Handler<TransactionResponseDto>(ResponseMessagesCode.BAD_REQUEST, null);
            }
        }
    }
}
