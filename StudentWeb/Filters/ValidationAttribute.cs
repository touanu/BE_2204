using Microsoft.AspNetCore.Mvc.Filters;
using CommonLibs;

namespace StudentWeb.Filters
{
    public class ValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IFormCollection form = context.HttpContext.Request.Form ?? throw new InvalidOperationException();

            if (!Validation.IsName(form["fullname"]))
            {
                throw new InvalidOperationException();
            }

            if (!int.TryParse(form["age"], out int age))
            {
                throw new InvalidOperationException();
            }

            if (age < 18 || age > 100)
            {
                throw new InvalidOperationException();
            }

            if (!Validation.IsValidEmail(form["email"]))
            {
                throw new InvalidOperationException();
            }
        }
    }
}
