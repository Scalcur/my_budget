using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_budget.Models;
using my_budget.Interfaces;

namespace my_budget.Controllers
{
    [ApiController]
    [Route("test/[controller]")]
    public class BudgetController : BaseController<BudgetController>
    {
        private readonly IClientManager _clientManager;
        
        public BudgetController(ILogger<BudgetController> logger, IClientManager clientManager) : base(logger)
        {
            _clientManager = clientManager;
        }

        [HttpGet] 
        public async Task GetAll() 
        {
            try
            {
                var response = _clientManager.GetAll();
                await SuccessResult(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }
    }
}