using CovalmorPertamina.Common.Statics;

namespace CovalmorPertamina.Web.Models.DataTable
{
    public class CreditApprovalDataTableModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PeriodeVolume { get; set; }
        public string TransactionValueEstimatedPeriod { get; set; }
        public string CreditLimit { get; set; }
        public string Creator { get; set; }
       

        private string _status;
        public string Status 
        {
            get
            {
                return StringService.AddSpacesToBeforeCapital(_status);
            }
            set
            {
                _status = value;
            } 
        }
    }
}