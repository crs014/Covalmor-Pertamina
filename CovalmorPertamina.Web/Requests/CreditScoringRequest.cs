using CovalmorPertamina.Web.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CovalmorPertamina.Web.Requests
{
    public class CreditScoringRequest
    {
        public int CreditApprovalId { get; set; }

        [Required(ErrorMessage = "File credit scoring doc harus di upload")]
        [FileTypes("pdf,xlsx,xls", ErrorMessage = "File harus berbentuk pdf,xlsx,xls")]
        [FIleSize(500240, ErrorMessage = "Maksimal ukuran file adalah 500240 byte")]
        public HttpPostedFileWrapper CreditScoringDoc { get; set; }
    }
}