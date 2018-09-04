namespace NetQuick.Core.Definitions
{ 
    public class BuiltInModelDefinition : ModelDefinition
    {
        public DataType DataType { get; }

        internal BuiltInModelDefinition(DataType dataType) : base(dataType.ToString())
        {
            DataType = dataType;
        }

        public static BuiltInModelDefinition Create(DataType dataType)
        {
            return new BuiltInModelDefinition(dataType);
        }

        public static BuiltInModelDefinition Text { get { return new BuiltInModelDefinition(DataType.Text); } }
        public static BuiltInModelDefinition Date { get { return new BuiltInModelDefinition(DataType.Date); } }
        public static BuiltInModelDefinition Number { get { return new BuiltInModelDefinition(DataType.Number); } }
        public static BuiltInModelDefinition UniqueIdentifier { get { return new BuiltInModelDefinition(DataType.UniqueIdentifier); } }

    }
}

