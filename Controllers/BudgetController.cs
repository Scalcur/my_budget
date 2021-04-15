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
                var response = _clientManager.GetAll().Result;
                await SuccessResult(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }
        
        [HttpPost("create")] 
        public async Task Create(ClientModel client) 
        {
            try
            {
                var response = _clientManager.Create(client).Result;
                await SuccessResult(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [HttpDelete("delete/{id:length(24)}")] 
        public async Task Delete(string id) 
        {
            try
            {
                var response = _clientManager.Remove(id).Result;
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