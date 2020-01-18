using CovalmorPertamina.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovalmorPertamina.Web.Requests
{
    public class SignatureRequest
    {
        private Signature _signature;

        public SignatureRequest()
        {
            _signature = new Signature();
        }

        [Required(ErrorMessage = "Kolom nama-1 tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nama-1")]
        public string Name1 
        {
            get
            {
                return _signature.Name1;
            }
            set
            {
                _signature.Name1 = value;
            }
        }

        [Required(ErrorMessage = "Kolom nama-2 tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nama-2")]
        public string Name2 
        {
            get
            {
                return _signature.Name2;
            }
            set
            {
                _signature.Name2 = value;
            } 
        }

        [Required(ErrorMessage = "Kolom posisi-1 tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom posisi-1")]
        public string Position1 
        {
            get
            {
                return _signature.Position1;
            }
            set
            {
                _signature.Position1 = value;
            } 
        }

        [Required(ErrorMessage = "Kolom posisi-2 tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom posisi-2")]
        public string Position2 
        {
            get
            {
                return _signature.Position2;
            }
            set
            {
                _signature.Position2 = value;
            } 
        }

        [Required(ErrorMessage = "Kolom tipe dokumen tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom tipe dokumen")]
        public string DocumentType 
        {
            get
            {
                return _signature.DocumentType;
            }
            set
            {
                _signature.DocumentType = value;
            } 
        }

        public Signature GetObject() => _signature;
    }
}