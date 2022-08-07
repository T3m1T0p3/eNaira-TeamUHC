using enairaUHC.src.DbService;
using enairaUHC.src.eNairaServices;
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

        [HttpGet("/getbalance/{bvn}")]
        public async Task<IActionResult> GetBalance(string bvn)
        {
            try
            {
                var user = await _repository.GetUserAsync(bvn);
                if (user == null) throw new Exception("Invalid User");
                double bal = await _enairaService.GetEnairaBalance(user);
                var balance=user.Wallet.Balance;
                return Ok(balance);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        public IActionResult Transfer()
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

        /*public IActionResult Receive()
        {
            return null;
        }*/

    }
}
