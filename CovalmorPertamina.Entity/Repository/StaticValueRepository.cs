using System.Collections.Generic;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;

namespace CovalmorPertamina.Entity.Repository
{
    public class StaticValueRepository : IStaticValueRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.StaticValue;

        public StaticValueRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public IEnumerable<StaticValue> GetAll()
        {
            return _db.StaticValues;
        }
    }
}
