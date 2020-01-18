using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class TrCaNoteRepository : ITrCaNoteRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.TrCaNote;

        public TrCaNoteRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<TrCaNote> Create(TrCaNote data)
        {
            return Task.Run(() =>
            {
                TrCaNote trCaNote = _db.TrCaNotes.Add(data);
                _db.SaveChanges();
                return data;
            });
        }

        public Task<TrCaNote> Delete(int id)
        {
            return Task.Run(() =>
            {
                TrCaNote trCaNote = _db.TrCaNotes.Find(id);
                if(trCaNote != null)
                {
                    _db.TrCaNotes.Remove(trCaNote);
                    _db.SaveChanges();
                }
                return trCaNote;
            });
        }

        public IEnumerable<TrCaNote> GetAll()
        {
            return _db.TrCaNotes;
        }

        public Task<TrCaNote> GetOne(int id)
        {
            return Task.Run(() => _db.TrCaNotes.Find(id));
        }

        public Task<TrCaNote> GetOneByCreditId(int id)
        {
            return Task.Run(() => _db.TrCaNotes.Where(e => e.CreditApprovalId == id).FirstOrDefault());
        }

        public Task<TrCaNote> Update(int id, TrCaNote data)
        {
            return Task.Run(() =>
            {
                TrCaNote trCaNote = _db.TrCaNotes.Find(id);
                if(trCaNote != null)
                {
                    trCaNote.TanggalNota = data.TanggalNota;
                    trCaNote.Perihal = data.Perihal;
                    trCaNote.Isi = data.Isi;
                    trCaNote.UpdatedAt = DateTime.UtcNow;
                    _db.SaveChanges();
                }
                return trCaNote;
            });
        }

        public Task<TrCaNote> UpdateByCreditId(int id, TrCaNote data)
        {
            return Task.Run(() =>
            {
                TrCaNote trCaNote = _db.TrCaNotes.Where(e => e.CreditApprovalId == id).FirstOrDefault();
                if (trCaNote != null)
                {
                    trCaNote.TanggalNota = data.TanggalNota;
                    trCaNote.Perihal = data.Perihal;
                    trCaNote.Isi = data.Isi;
                    trCaNote.UpdatedAt = DateTime.UtcNow;
                    _db.SaveChanges();
                }
                return trCaNote;
            });
        }
    }
}
