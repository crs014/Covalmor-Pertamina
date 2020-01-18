using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Entity.Repository;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Testing.Db;
using System.Collections.Generic;

namespace CovalmorPertamina.Testing
{
    public abstract class TestBaseController
    {
        private CovalmorContextTest _covalmorContextTest;
        protected EntityFactoryTest _entityFactory;
        
        public TestBaseController()
        {
            _covalmorContextTest = new CovalmorContextTest();
            _entityFactory = new EntityFactoryTest(new List<IBaseRepository>() 
            {
                new CaCustomerDetailRepository(_covalmorContextTest),
                new CreditApprovalRepository(_covalmorContextTest),
                new CreditScoringRepository(_covalmorContextTest),
                new CustomerRepository(_covalmorContextTest),
                new ProductRepository(_covalmorContextTest),
                new QuantitativeAspectRepository(_covalmorContextTest),
                new SignatureRepository(_covalmorContextTest),
                new StaticValueRepository(_covalmorContextTest),
                new TrCaActionNoteRepository(_covalmorContextTest),
                new TrCaNoteRepository(_covalmorContextTest),
                new TrCaProductRepository(_covalmorContextTest),
                new UserRepository(_covalmorContextTest, new JWTService())
            });
        }
        
    }
}
