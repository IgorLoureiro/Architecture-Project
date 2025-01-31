using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExpectionsBase;
using System.Net;

namespace MyRecipeBook.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MyRecipeBookException)
            {
                HandleProjectException(context);
            }
            else
            {
               ThrowUnknowException(context);
            }

            throw new NotImplementedException();
        }

        private void HandleProjectException(ExceptionContext ex) { 
            if(ex.Exception is ErrorOnValidationException)
            {
                var exception = ex.Exception as ErrorOnValidationException;

                ex.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ex.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
            }
        }

        private void ThrowUnknowException(ExceptionContext ex)
        {
            ex.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ex.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOWN_ERROR));
        }
    }
}
