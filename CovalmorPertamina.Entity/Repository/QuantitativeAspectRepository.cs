using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class QuantitativeAspectRepository : IQuantitativeAspectRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.QuantitativeAspect;


        public QuantitativeAspectRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<QuantitativeAspect> Create(QuantitativeAspect data)
        {
            return Task.Run(() =>
            {
                QuantitativeAspect quantitativeAspect = _db.QuantitativeAspects.Add(data);
                _db.SaveChanges();
                return quantitativeAspect;
            });
        }

        public Task<QuantitativeAspect> Delete(int id)
        {
            return Task.Run(() =>
            {
                QuantitativeAspect quantitativeAspect = _db.QuantitativeAspects.Find(id);
                if(quantitativeAspect != null)
                {
                    _db.QuantitativeAspects.Remove(quantitativeAspect);
                    _db.SaveChanges();
                }
                return quantitativeAspect;
            });
        }

        public IEnumerable<QuantitativeAspect> GetAll()
        {
            return _db.QuantitativeAspects;
        }

        public Task<QuantitativeAspect> GetOne(int id)
        {
            return Task.Run(() => _db.QuantitativeAspects.Find(id));
        }

        public Task<QuantitativeAspect> Update(int id, QuantitativeAspect data)
        {
            return Task.Run(() =>
            {
                QuantitativeAspect quantitativeAspect = _db.QuantitativeAspects.Find(id);
                if(quantitativeAspect != null)
                {
                    quantitativeAspect.DateTime1 = data.DateTime1;
                    quantitativeAspect.DateTime1 = data.DateTime2;
                    quantitativeAspect.ReportCastIsAviable = data.ReportCastIsAviable;
                    quantitativeAspect.CashAndCashEquivalents1 = data.CashAndCashEquivalents1;
                    quantitativeAspect.CashAndCashEquivalents2 = data.CashAndCashEquivalents2;
                    quantitativeAspect.ShortTermInvestment1 = data.ShortTermInvestment1;
                    quantitativeAspect.ShortTermInvestment2 = data.ShortTermInvestment2;
                    quantitativeAspect.ReceivablesIncludingRelatedReceivables1 = data.ReceivablesIncludingRelatedReceivables1;
                    quantitativeAspect.ReceivablesIncludingRelatedReceivables2 = data.ReceivablesIncludingRelatedReceivables2;
                    quantitativeAspect.Stock1 = data.Stock1;
                    quantitativeAspect.Stock2 = data.Stock2;
                    quantitativeAspect.PrepaidExpenses1 = data.PrepaidExpenses1;
                    quantitativeAspect.PrepaidExpenses2 = data.PrepaidExpenses2;
                    quantitativeAspect.PrepaidTaxes1 = data.PrepaidTaxes1;
                    quantitativeAspect.PrepaidTaxes2 = data.PrepaidTaxes2;
                    quantitativeAspect.OtherCash1 = data.OtherCash1;
                    quantitativeAspect.OtherCash2 = data.OtherCash2;
                    quantitativeAspect.IntangibleAssetsAmortizationGoodwill1 = data.IntangibleAssetsAmortizationGoodwill1;
                    quantitativeAspect.IntangibleAssetsAmortizationGoodwill2 = data.IntangibleAssetsAmortizationGoodwill2;
                    quantitativeAspect.TotalAssets1 = data.TotalAssets1;
                    quantitativeAspect.TotalAssets2 = data.TotalAssets2;
                    quantitativeAspect.TotalShortTermDebtLiabilities1 = data.TotalShortTermDebtLiabilities1;
                    quantitativeAspect.TotalShortTermDebtLiabilities2 = data.TotalShortTermDebtLiabilities2;
                    quantitativeAspect.InterestBearingPayables1 = data.InterestBearingPayables1;
                    quantitativeAspect.InterestBearingPayables2 = data.InterestBearingPayables2;
                    quantitativeAspect.TotalAmountOfDebt1 = data.TotalAmountOfDebt1;
                    quantitativeAspect.TotalAmountOfDebt2 = data.TotalAmountOfDebt2;
                    quantitativeAspect.TotalCapitalEquity1 = data.TotalCapitalEquity1;
                    quantitativeAspect.TotalCapitalEquity2 = data.TotalCapitalEquity2;
                    quantitativeAspect.SalesRevenue1 = data.SalesRevenue1;
                    quantitativeAspect.SalesRevenue2 = data.SalesRevenue2;
                    quantitativeAspect.CostOfGoodsDirectCharges1 = data.CostOfGoodsDirectCharges1;
                    quantitativeAspect.CostOfGoodsDirectCharges2 = data.CostOfGoodsDirectCharges2;
                    quantitativeAspect.AdministrativeBurden1 = data.AdministrativeBurden1;
                    quantitativeAspect.AdministrativeBurden2 = data.AdministrativeBurden2;
                    quantitativeAspect.FinancialRevenuesExpenses1 = data.FinancialRevenuesExpenses1;
                    quantitativeAspect.FinancialRevenuesExpenses2 = data.FinancialRevenuesExpenses2;
                    quantitativeAspect.TaxExpense1 = data.TaxExpense1;
                    quantitativeAspect.TaxExpense2 = data.TaxExpense2;
                    quantitativeAspect.OtherIncomeExpenses1 = data.OtherIncomeExpenses1;
                    quantitativeAspect.OtherIncomeExpenses2 = data.OtherIncomeExpenses2;
                    _db.SaveChanges();
                }       
                return quantitativeAspect;
            });
        }
    }
}
