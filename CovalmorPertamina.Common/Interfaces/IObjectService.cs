namespace CovalmorPertamina.Common.Interfaces
{
    public interface IObjectService
    {
        object DeserializerObject(string json);

        string SerializerObject(object data);
    }
}
