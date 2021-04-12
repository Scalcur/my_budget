using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace my_budget.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : BaseController<BudgetController>
    {
        public BudgetController(ILogger<BudgetController> logger) : base(logger)
        {

        }

        [HttpGet] 
        public async Task GetRequest() 
        {
            try
            {
                var response = HelloResponse();
               await SuccessResult(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [NonAction]
        public string HelloResponse()
        {
            return "Hello world";
        }
    }
}