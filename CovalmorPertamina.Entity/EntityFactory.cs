using System.Collections.Generic;
using System.Linq;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Repository.Interfaces;

namespace CovalmorPertamina.Entity
{
    public class EntityFactory : IEntityFactory
    {
        private IEnumerable<IBaseRepository> _repositories;

        public EntityFactory(IEnumerable<IBaseRepository> repositories)
        {
            _repositories = repositories;
        }

        public IBaseRepository Repositories(ERepository repository)
        {
            return _repositories.Where(e => e.repository == repository).FirstOrDefault();
        }

        
    }
}
