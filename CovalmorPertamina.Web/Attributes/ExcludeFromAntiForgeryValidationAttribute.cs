using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovalmorPertamina.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExcludeFromAntiForgeryValidationAttribute : Attribute
    {
    }
}