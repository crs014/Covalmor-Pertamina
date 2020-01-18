using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class SignatureRepository : ISignatureRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.Signature;

        public SignatureRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<Signature> Create(Signature data)
        {
            return Task.Run(() =>
            {
                Signature signature = _db.Signatures.Add(data);
                _db.SaveChanges();
                return signature;
            });
        }

        public Task<Signature> Delete(int id)
        {
            return Task.Run(() =>
            {
                Signature signature = _db.Signatures.Find(id);
                if(signature != null)
                {
                    _db.Signatures.Remove(signature);
                    _db.SaveChanges();
                }
                return signature;
            });
        }

        public IQueryable<Signature> GetAll()
        {
            return _db.Signatures;
        }

        public Task<Signature> GetOne(int id)
        {
            return Task.Run(() => _db.Signatures.Find(id));
        }

        public Task<Signature> Update(int id, Signature data)
        {
            return Task.Run(() =>
            {
                Signature signature = _db.Signatures.Find(id);
                if(signature != null)
                {
                    signature.Name1 = data.Name1;
                    signature.Name2 = data.Name2;
                    signature.Position1 = data.Position1;
                    signature.Position2 = data.Position2;
                    signature.DocumentType = data.DocumentType;
                    signature.UpdatedAt = DateTime.UtcNow;
                    _db.SaveChanges();
                }
                return signature;
            });
        }
    }
}
