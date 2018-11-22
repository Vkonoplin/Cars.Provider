using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VK.Cars.Provider.Service.WebApi.Business.Exceptions;
using ErrorModel = VK.Cars.Provider.Service.WebApi.Infrastructure.Models.ErrorModel;

namespace VK.Cars.Provider.Service.WebApi.Infrastructure
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            context.Result = GetErrorActionResult(context);
        }

        public IActionResult GetErrorActionResult(ExceptionContext context)
        {
            var exception = context.Exception as BaseBusinessException;

            var errorResult = new ErrorModel() { Code = 500, TraceId = context.HttpContext.TraceIdentifier };

            if (exception == null)
            {
                errorResult.Message = "An unexpected error has occured.  Contact support for assistance.";
            }
            else
            {
                errorResult.ErrorCode = exception.GetErrorCode();
                errorResult.Message = exception.Message;
                errorResult.Data = exception.Data;
            }

            return new ObjectResult(errorResult);
        }
    }
}
