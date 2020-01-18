using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class CreditScoringRepository : ICreditScoringRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.CreditScoring;

        public CreditScoringRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<CreditScoring> Create(CreditScoring data)
        {
            return Task.Run(() =>
            {
                CreditScoring creditScoring = _db.CreditScorings.Add(data);
                _db.SaveChanges();
                return creditScoring;
            });
        }

        public Task<CreditScoring> Delete(int id)
        {
            return Task.Run(() =>
            {
                CreditScoring creditScoring = _db.CreditScorings.Find(id);
                if(_db.CreditScorings != null)
                {
                    _db.CreditScorings.Remove(creditScoring);
                    _db.SaveChanges();
                }
                return creditScoring;
            });
        }

        public IEnumerable<CreditScoring> GetAll()
        {
            return _db.CreditScorings;
        }

        public Task<CreditScoring> GetOne(int id)
        {
            return Task.Run(() => _db.CreditScorings.Find(id));
        }

        public Task<CreditScoring> Update(int id, CreditScoring data)
        {
            return Task.Run(() =>
            {
                CreditScoring creditScoring = _db.CreditScorings.Find(id);
                if (creditScoring != null)
                {
                    creditScoring.UpdatedAt = DateTime.UtcNow;
                    creditScoring.CustomerName = data.CustomerName;
                    creditScoring.CustomerSap = data.CustomerSap;
                    creditScoring.TypeIndustry = data.TypeIndustry;
                    creditScoring.Score = data.Score;
                    _db.SaveChanges();
                }
                return creditScoring;
            });
        }
    }
}
