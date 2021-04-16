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
    public class UserController : BaseController<UserController>
    {
        private readonly IClientManager _clientManager;
        
        public UserController(ILogger<UserController> logger, IClientManager clientManager) : base(logger)
        {
            _clientManager = clientManager;
        }
        
        [HttpGet] 
        public async Task GetAll() 
        {
            try
            {
                var response = await _clientManager.GetAll();
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
                var response = await _clientManager.Create(client);
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
                var response = await _clientManager.Remove(id);
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