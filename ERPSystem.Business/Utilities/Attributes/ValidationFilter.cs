using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Utilities.Attributes
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private readonly Type _validationType;

        public ValidationFilter(Type validationType)
        {
            _validationType = validationType;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ValidationHelper.Validate(_validationType, context.ActionArguments.Values.ToArray());
            await next();
        }
    }
}
