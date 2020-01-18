using CovalmorPertamina.Web.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CovalmorPertamina.Web.Requests
{
    public class CreditSignRequest
    {
        public int CreditApprovalId { get; set; }

        [Required(ErrorMessage = "File credit sign harus di upload")]
        [FileTypes("pdf", ErrorMessage = "File harus berbentuk pdf")]
        [FIleSize(500240, ErrorMessage = "Maksimal ukuran file adalah 500240 byte")]
        public HttpPostedFileWrapper CreditSign { get; set; }
    }
}