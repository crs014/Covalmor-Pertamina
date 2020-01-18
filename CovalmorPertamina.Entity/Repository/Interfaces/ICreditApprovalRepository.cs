using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface ICreditApprovalRepository : ILoadRepository<ICreditApprovalRepository>
    {
        IQueryable<CreditApproval> GetAll();

        Task<CreditApproval> GetOne(int id);

        Task<CreditApproval> Create(CreditApproval data);

        Task<CreditApproval> Delete(int id);

        Task<CreditApproval> Update(int id, CreditApproval data);

        Task<CreditApproval> UpdateStatus(int id, EStatusCredit statusCredit, bool isApprove = false);

        Task AddIntroductionMemo(int id, string introductionMemo);

        Task AddDocLka(int id, string docLka);

        Task AddDocCas(int id, string docCas);

        Task AddDocBg(int id, string docBg);

        Task AddDocPml(int id, string docPml);

        Task<CreditApproval> AddCashBank(int id, string bankGaransi, string bankKonfirmasi);

        Task AddBankGaransi(int id, string bankGaransi);

        Task AddBankKonfirmasiDoc(int id, string bankKonfirmasi);

        Task AddCreditScoring(int id, string creditScoring);

        Task<CreditApproval> AddCreditSign(int id, string creditSign);
    }
}
