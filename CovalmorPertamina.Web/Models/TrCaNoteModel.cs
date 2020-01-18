using CovalmorPertamina.Entity.Model;
using System;

namespace CovalmorPertamina.Web.Models
{
    public class TrCaNoteModel
    {
        private TrCaNote _trCaNote;

        public TrCaNoteModel()
        {
            _trCaNote = new TrCaNote();
        }

        public TrCaNoteModel(TrCaNote trCaNote)
        {
            _trCaNote = trCaNote;
        }

        public int Id => _trCaNote.Id;

        public DateTime TanggalNota => _trCaNote.TanggalNota;

        public string Perihal => _trCaNote.Perihal;

        public string Isi => _trCaNote.Isi;

        public string CreatedBy => _trCaNote.CreatedBy;

        public CreditApproval CreditApproval => _trCaNote.CreditApproval;

    }
}