namespace NetQuick.Core
{
    public interface IDataTypeMapper
    {
        string Map(DataType dataType, bool isRequired);
    }
}