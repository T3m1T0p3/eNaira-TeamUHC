using enairaUHC.src.DbService;
using enairaUHC.src.eNairaServices;
using enairaUHC.src.Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.Controllers
{
    [ApiController]
    [Route("api/transaction/")]
    public class TransactionController:ControllerBase
    {
        

        IEnairaService _enairaService;
        IRepository _repository;
        public TransactionController(IEnairaService enairaService,IRepository repository)
        {
            _enairaService = enairaService;
        }

        [HttpGet("/getbalance/{userId}")]
        public async Task<IActionResult> GetBalance(string userId,[FromQuery]string password)
        {
            try
            {
                var token = await _enairaService.GetTokenAsync(userId,password);
                Console.WriteLine(token);
                var balance = await _enairaService.GetEnairaBalance(userId,token);
                var Balance = new EnairaBalance { Balance = balance };
                return Ok(Balance);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*public IActionResult TransferToInsurer()
        {
            try
            {
                return null;
            }

            catch(Exception e)
            {
                return null;
            }
        }

        public IActionResult DepositToCustomerWallet()
        {
            return null;
        }*/

    }
}
