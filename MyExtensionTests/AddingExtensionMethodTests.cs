using System.Collections.Generic;
using homeWorkTill2303;
using Xunit;

namespace MyExtensionTests
{
    public class AddingExtensionMethodTests
    {
        [Fact]
        public void AddingIntsResultShouldBeInt()
        {
            var number1 = 1;
            var number2 = 2;
            var result = number1.MyAddOneToAnotherAttribute(number2);
            Assert.IsType<int>(result);
        }

        [Fact]
        public void AddingStringsResultShouldBeString()
        {
            var text1 = "aaaa";
            var text2 = "bbbbb";
            var result = text1.MyAddOneToAnotherAttribute(text2);
            Assert.IsType<string>(result);
        }

        [Fact]
        public void AddingDifferentTypeOfObjectsThereShouldBeErrorMessage()
        {
            var text1 = "aaaa";
            var number1 = 1;
            var result = text1.MyAddOneToAnotherAttribute(number1);
            Assert.Multiple(
                () => Assert.True(text1.GetType() != number1.GetType()),
                () => Assert.Contains("error,", result)
            );
        }

        [Fact]
        public void AddingNotStringOrIntTypeArgumentsThereShouldBeErrorMessage()
        {
            var collection = new List<string>();
            var floatNumber = 1.1f;
            var result = collection.MyAddOneToAnotherAttribute(floatNumber);
            Assert.Multiple(
                () => Assert.True(collection.GetType() != floatNumber.GetType()),
                () => Assert.Contains("error,", result)
            );
        }
    }
}
