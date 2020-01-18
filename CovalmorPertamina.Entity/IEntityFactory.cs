using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity
{
    public interface IEntityFactory
    {
        IBaseRepository Repositories(ERepository repository);
    }
}
