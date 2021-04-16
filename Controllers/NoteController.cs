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
    public class NoteController : BaseController<NoteController>
    {
        private readonly IBudgetManager _budgetManager;
        
        public NoteController(ILogger<NoteController> logger, IBudgetManager budgetManager) : base(logger)
        {
            _budgetManager = budgetManager;
        }
        
        [HttpGet] 
        public async Task GetAll() 
        {
            try
            {
                var response = await _budgetManager.GetAll();
                await SuccessResult(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }
        
        [HttpPost("create")] 
        public async Task Create(BudgetModel budget) 
        {
            try
            {
                var response = await _budgetManager.Create(budget);
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
                var response = await _budgetManager.Remove(id);
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