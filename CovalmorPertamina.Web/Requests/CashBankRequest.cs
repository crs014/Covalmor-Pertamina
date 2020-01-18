using CovalmorPertamina.Web.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CovalmorPertamina.Web.Requests
{
    public class CashBankRequest
    {
        public int CreditApprovalId { get; set; }

        [Required(ErrorMessage = "File bank garansi doc harus di upload")]
        [FileTypes("pdf", ErrorMessage = "File harus berbentuk pdf")]
        [FIleSize(500240, ErrorMessage = "Maksimal ukuran file adalah 500240 byte")]
        public HttpPostedFileWrapper BankGaransiDoc { get; set; }

        [Required(ErrorMessage = "File bank konfirmasi doc harus di upload")]
        [FileTypes("pdf", ErrorMessage = "File harus berbentuk pdf")]
        [FIleSize(500240, ErrorMessage = "Maksimal ukuran file adalah 500240 byte")]
        public HttpPostedFileWrapper BankKonfirmasiDoc { get; set; }
    }
}