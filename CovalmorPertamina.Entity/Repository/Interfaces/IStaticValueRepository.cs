using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface IStaticValueRepository : ILoadRepository<IStaticValueRepository>
    {
        IEnumerable<StaticValue> GetAll();
    }
}
