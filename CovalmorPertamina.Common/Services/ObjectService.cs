using CovalmorPertamina.Common.Interfaces;
using System;
using System.Web.Script.Serialization;

namespace CovalmorPertamina.Common.Services
{
    public class ObjectService<T> : IObjectService
    {
        private JavaScriptSerializer _javaScriptSerializer;

        public ObjectService()
        {
            _javaScriptSerializer = new JavaScriptSerializer();
        }

        public object DeserializerObject(string json)
        {
            try
            {
                return _javaScriptSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                throw new Exception("Object is not required");
            }

        }

        public string SerializerObject(object data)
        {
            try
            {
                string json = _javaScriptSerializer.Serialize(data);
                return json;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
