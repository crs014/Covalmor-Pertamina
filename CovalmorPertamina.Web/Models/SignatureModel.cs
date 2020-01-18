using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace CovalmorPertamina.Web.Models
{
    public class SignatureModel
    {

        private Signature _signature;

        public SignatureModel() 
        {
            _signature = new Signature();
        }

        public SignatureModel(Signature signature)
        {
            _signature = signature;
        }

        public static IEnumerable<SignatureModel> GetAll(IEnumerable<Signature> signatures)
        {
            return signatures.Select(e => new SignatureModel(e));
        }

        public int Id => _signature.Id;
 
        public string Name1 => _signature.Name1;
     
        public string Name2 => _signature.Name2;
     
        public string Position1 => _signature.Position1;

        public string Position2 => _signature.Position2;
       
        public string DocumentType => _signature.DocumentType;
    }
}