using System.Linq;
using System.Web.Mvc;

namespace CovalmorPertamina.Web.Attributes
{
    public class CustomValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            bool shouldValidate = !filterContext
            .ActionDescriptor
            .GetCustomAttributes(typeof(ExcludeFromAntiForgeryValidationAttribute), true)
            .Any();
            if (shouldValidate)
            {
                System.Web.Helpers.AntiForgery.Validate();
            }
        }
    }
}