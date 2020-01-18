using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Repository;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovalmorPertamina.Testing.Db
{
    public class EntityFactoryTest : IEntityFactory
    {
        private IEnumerable<IBaseRepository> _repositories;
        
        public EntityFactoryTest(IEnumerable<IBaseRepository> repositories)
        {
            _repositories = repositories;
        }

        public IBaseRepository Repositories(ERepository repository)
        {
            return _repositories.Where(e => e.repository == repository).FirstOrDefault();
        }
    }
}
