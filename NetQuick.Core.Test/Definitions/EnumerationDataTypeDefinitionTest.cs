using NetQuick.Core.Definitions;
using Xunit;

namespace NetQuick.Core.Test.Definitions
{
    public class EnumerationDataTypeDefinitionTest
    {
        public enum GenderWithId
        {
            Male = 1,
            Female = 2
        }

        public enum GenderWithoutId
        {
            Male,
            Female
        }

        [Fact]
        public void ConvertEnumToDataType_With_Id()
        {
            var definition = ListDataTypeDefinition.FromEnum<GenderWithId>();
        }

        [Fact]
        public void ConvertEnumToDataType_Without_Id()
        {
            var definition = ListDataTypeDefinition.FromEnum<GenderWithoutId>();
        }
    }
}
