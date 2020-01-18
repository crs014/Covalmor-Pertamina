using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CovalmorPertamina.Web.Attributes
{
    public class FIleSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FIleSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return _maxSize > (value as HttpPostedFileWrapper).ContentLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The file size should not exceed {0}", _maxSize);
        }
    }
}