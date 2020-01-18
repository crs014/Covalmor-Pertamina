using CovalmorPertamina.Entity.Model;
using System.ComponentModel.DataAnnotations;

namespace CovalmorPertamina.Web.Requests
{
    public class ActionNoteRequest
    {
        private TrCaActionNote _trCaActionNote;

        public ActionNoteRequest()
        {
            _trCaActionNote = new TrCaActionNote();
        }

        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom note")]
        public string ActionNote 
        {
            get
            {
                return _trCaActionNote.ActionNote;
            }
            set
            {
                _trCaActionNote.ActionNote = value;
            }
        }

        public TrCaActionNote GetObject() => _trCaActionNote;
    }
}