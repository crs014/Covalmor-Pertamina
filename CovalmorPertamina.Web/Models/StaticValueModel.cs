using CovalmorPertamina.Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace CovalmorPertamina.Web.Models
{
    public class StaticValueModel
    {
        private StaticValue _staticValue;

        public StaticValueModel()
        {
            _staticValue = new StaticValue();
        }

        public StaticValueModel(StaticValue staticValue)
        {
            _staticValue = staticValue;
        }

        public static IEnumerable<StaticValueModel> GetAll(IEnumerable<StaticValue> staticValues)
        {
            return staticValues.Select(e => new StaticValueModel(e));
        }

        public int Id => _staticValue.Id;

        public string TypeName => _staticValue.TypeName;

        public string TextValue => _staticValue.TextValue;

        public int ColumnScore => _staticValue.ColumnScore;

    }
}