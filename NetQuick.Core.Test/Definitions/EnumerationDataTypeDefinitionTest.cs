using NetQuick.Core.Definitions;
using NUnit.Framework;

namespace NetQuick.Core.Test.Definitions
{
    [TestFixture]
    public class EnumerationDataTypeDefinitionTest
    {
        public enum GenderWithId
        {
            Male = 1, 
            Female = 2
        }

        public enum GenderWithoutId
        {
            Male ,
            Female
        }

        [Test]
        public void ConvertEnumToDataType_With_Id()
        {
           var definition = ListDataTypeDefinition.FromEnum<GenderWithId>();
        }

        [Test]
        public void ConvertEnumToDataType_Without_Id()
        {
            var definition = ListDataTypeDefinition.FromEnum<GenderWithoutId>();
        }
    }
}
