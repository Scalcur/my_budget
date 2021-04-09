using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using my_budget.Models;

namespace my_budget.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public abstract class BaseController<T> : ControllerBase
        {
            protected readonly ILogger<T> _logger;

            public BaseController(ILogger<T> logger)
            {
                _logger = logger;
            }

            protected async Task SuccessResult<D>(D data)
            {            
                Response.StatusCode = 200;
                await HandlerResponse<D>(data, "");
            }

            protected async Task ErrorResult(string errorText)
            {
                Response.StatusCode = 400;
                await HandlerResponse<object>(null, errorText);
            }

            private async Task HandlerResponse<D>(D data, string errorText)
            {
            var responseModel = new ServerResponseModel<D>
            {
                ResponseData = data,
                Error = errorText
            };

            await Response.WriteAsJsonAsync(responseModel);
            }
        }
}