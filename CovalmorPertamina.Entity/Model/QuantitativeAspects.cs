using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class QuantitativeAspect
    {
        [Key]
        public int Id { get; set; }

        public int CreditApporvalId { get; set; }

        public DateTime DateTime1 { get; set; }

        public DateTime DateTime2 { get; set; }

        public bool ReportCastIsAviable { get; set; }

        public float CashAndCashEquivalents1 { get; set; }

        public float CashAndCashEquivalents2 { get; set; }

        public float ShortTermInvestment1 { get; set; }

        public float ShortTermInvestment2 { get; set; }

        public float ReceivablesIncludingRelatedReceivables1 { get; set; }

        public float ReceivablesIncludingRelatedReceivables2 { get; set; }

        public float Stock1 { get; set; }

        public float Stock2 { get; set; }

        public float PrepaidExpenses1 { get; set; }

        public float PrepaidExpenses2 { get; set; }

        public float PrepaidTaxes1 { get; set; }

        public float PrepaidTaxes2 { get; set; }

        public float OtherCash1 { get; set; }

        public float OtherCash2 { get; set; }

        public float IntangibleAssetsAmortizationGoodwill1 { get; set; }

        public float IntangibleAssetsAmortizationGoodwill2 { get; set; }

        public float TotalAssets1 { get; set; }

        public float TotalAssets2 { get; set; }

        public float TotalShortTermDebtLiabilities1 { get; set; }

        public float TotalShortTermDebtLiabilities2 { get; set; }

        public float InterestBearingPayables1 { get; set; }

        public float InterestBearingPayables2 { get; set; }

        public float TotalAmountOfDebt1 { get; set; }

        public float TotalAmountOfDebt2 { get; set; }

        public float TotalCapitalEquity1 { get; set; }

        public float TotalCapitalEquity2 { get; set; }

        public float SalesRevenue1 { get; set; }

        public float SalesRevenue2 { get; set; }

        public float CostOfGoodsDirectCharges1 { get; set; }

        public float CostOfGoodsDirectCharges2 { get; set; }

        public float AdministrativeBurden1 { get; set; }

        public float AdministrativeBurden2 { get; set; }

        public float FinancialRevenuesExpenses1 { get; set; }

        public float FinancialRevenuesExpenses2 { get; set; }

        public float TaxExpense1 { get; set; }

        public float TaxExpense2 { get; set; }

        public float OtherIncomeExpenses1 { get; set; }

        public float OtherIncomeExpenses2 { get; set; }

        [ForeignKey("CreditApporvalId")]
        public CreditApproval CreditApproval { get; set; }
    }
}
