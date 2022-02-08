using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Transaction;
using PRJ.Service.Transaction.Dtos;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("post")]
        [Authorize]
        public IActionResult submit([FromBody] TransactionRequestDto request)
        {
            var result = _transactionService.Submit(request);
            return Ok(result.Data);
        }
    }
}
