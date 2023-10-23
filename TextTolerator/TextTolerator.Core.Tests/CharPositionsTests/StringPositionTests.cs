using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules;

namespace TextTolerator.Core.Tests.CharPositionsTests
{
    public class StringPositionTests
    {
        public static TheoryData<StringPosition, bool, string> ShouldReturnCorrectBoolean_WhenAtStartTheoryData => new()
        {
            {StringPosition.Start, true, "" },
            {StringPosition.Mid, false, "" },
            {StringPosition.End, false, "" },
            {StringPosition.Start | StringPosition.Mid, true, "" },
            {StringPosition.Start | StringPosition.End, true, "" },
            {StringPosition.Mid | StringPosition.End, false, "" },
            {StringPosition.Start | StringPosition.Mid | StringPosition.End, true, "" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectBoolean_WhenAtStartTheoryData))]
        public void ShouldReturnCorrectBoolean_WhenAtStart(StringPosition input, bool expectedResult, string testDataName)
        {
            var actualResult = input.IsStart();

            Assert.Equal(expectedResult, actualResult);
        }

        public static TheoryData<StringPosition, bool, string> ShouldReturnCorrectBoolean_WhenAtMidTheoryData => new()
        {
            {StringPosition.Start, false, "" },
            {StringPosition.Mid, true, "" },
            {StringPosition.End, false, "" },
            {StringPosition.Start | StringPosition.Mid, true, "" },
            {StringPosition.Start | StringPosition.End, false, "" },
            {StringPosition.Mid | StringPosition.End, true, "" },
            {StringPosition.Start | StringPosition.Mid | StringPosition.End, true, "" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectBoolean_WhenAtMidTheoryData))]
        public void ShouldReturnCorrectBoolean_WhenAtMid(StringPosition input, bool expectedResult, string testDataName)
        {
            var actualResult = input.IsMid();

            Assert.Equal(expectedResult, actualResult);
        }

        public static TheoryData<StringPosition, bool, string> ShouldReturnCorrectBoolean_WhenAtEndTheoryData => new()
        {
            {StringPosition.Start, false, "" },
            {StringPosition.Mid, false, "" },
            {StringPosition.End, true, "" },
            {StringPosition.Start | StringPosition.Mid, false, "" },
            {StringPosition.Start | StringPosition.End, true, "" },
            {StringPosition.Mid | StringPosition.End, true, "" },
            {StringPosition.Start | StringPosition.Mid | StringPosition.End, true, "" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectBoolean_WhenAtEndTheoryData))]
        public void ShouldReturnCorrectBoolean_WhenAtEnd(StringPosition input, bool expectedResult, string testDataName)
        {
            var actualResult = input.IsEnd();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
