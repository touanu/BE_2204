using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductWeb.Filter
{
    namespace WebMVC_NetCore.Filter
    {
        public class ValidationAttribute : TypeFilterAttribute
        {
            public ValidationAttribute(string function, string permision) :
                base(typeof(ClaimRequirementFilter))
            {
                Arguments = [function, permision];
            }
        }

        public class ClaimRequirementFilter : IAuthorizationFilter
        {
            public string _function { get; set; }

            public string _permision { get; set; }

            public ClaimRequirementFilter(string function, string permision)
            {
                _function = function;
                _permision = permision;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var userid = _function;
                // userid = 1 và nếu permisson ! VIEW thì trả về thông báo lỗi
                if (userid == "1" && _permision != "VIEW")
                {

                }
            }
        }
    }
}
