using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class TrCaActionNoteRepository : ITrCaActionNoteRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.TrCaActionNote;

        public TrCaActionNoteRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<TrCaActionNote> Create(TrCaActionNote data)
        {
            return Task.Run(() =>
            {
                TrCaActionNote trCaActionNote = _db.TrCaActionNotes.Add(data);
                _db.SaveChanges();
                return trCaActionNote;
            });
        }

        public Task<TrCaActionNote> Delete(int id)
        {
            return Task.Run(() =>
            {
                TrCaActionNote trCaActionNote = _db.TrCaActionNotes.Find(id);
                if (trCaActionNote != null)
                {
                    _db.TrCaActionNotes.Remove(trCaActionNote);
                    _db.SaveChanges();
                }
                return trCaActionNote;
            });
        }

        public IEnumerable<TrCaActionNote> DeleteByCreatedBy(int id)
        {
            IQueryable<TrCaActionNote> trCaActionNotes = _db.TrCaActionNotes.Where(e => e.ActionBy == id);
            foreach (TrCaActionNote tr in trCaActionNotes)
            {
                _db.TrCaActionNotes.Remove(tr);
                _db.SaveChanges();
            }
            return trCaActionNotes;
            
        }

        public IEnumerable<TrCaActionNote> GetAll()
        {
            return _db.TrCaActionNotes;
        }

        public Task<TrCaActionNote> GetOne(int id)
        {
            return Task.Run(() => _db.TrCaActionNotes.Find(id));
        }

        public Task<TrCaActionNote> Update(int id, TrCaActionNote data)
        {
            return Task.Run(() =>
            {
                TrCaActionNote trCaActionNote = _db.TrCaActionNotes.Find(id);
                if (trCaActionNote != null)
                {
                    trCaActionNote.ActionNote = data.ActionNote;
                    trCaActionNote.ActionType = data.ActionType;
                    trCaActionNote.ActionBy = data.ActionBy;
                    trCaActionNote.UpdatedAt = DateTime.UtcNow;
                    _db.SaveChanges();
                }
                return trCaActionNote;
            });
        }

    }
}
