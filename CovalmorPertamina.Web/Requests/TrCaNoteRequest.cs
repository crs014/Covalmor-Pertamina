using CovalmorPertamina.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovalmorPertamina.Web.Requests
{
    public class TrCaNoteRequest
    {
        private TrCaNote _trCaNote;

        public TrCaNoteRequest()
        {
            _trCaNote = new TrCaNote();
        }

        public int CreditApprovalId 
        {
            get
            {
                return _trCaNote.CreditApprovalId;
            }
            set
            {
                _trCaNote.CreditApprovalId = value;
            } 
        }

        [Required(ErrorMessage = "Kolom tanggal nota tidak boleh kosong")]
        public DateTime TanggalNota 
        {
            get
            {
                return _trCaNote.TanggalNota;
            }
            set
            {
                _trCaNote.TanggalNota = value;
            } 
        }

        [Required(ErrorMessage = "Kolom perihal tidak boleh kosong")]
        [MaxLength(45, ErrorMessage = "Maksimal karakter 45 pada kolom perihal")]
        public string Perihal 
        {
            get
            {
                return _trCaNote.Perihal;
            }
            set
            {
                _trCaNote.Perihal = value;
            } 
        }

        [Required(ErrorMessage = "Kolom isi tidak boleh kosong")]
        public string Isi 
        {
            get
            {
                return _trCaNote.Isi;
            }
            set
            {
                _trCaNote.Isi = value;
            } 
        }

        public TrCaNote GetObject() => _trCaNote;
    }
}