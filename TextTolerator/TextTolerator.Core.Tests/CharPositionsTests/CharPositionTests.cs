using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules;

namespace TextTolerator.Core.Tests.CharPositionsTests
{
    public class CharPositionTests
    {
        public static TheoryData<CharPosition, bool, string> ShouldReturnCorrectBoolean_WhenAtStartTheoryData => new()
        {
            {CharPosition.Start, true, "" },
            {CharPosition.Mid, false, "" },
            {CharPosition.End, false, "" },
            {CharPosition.Start | CharPosition.Mid, true, "" },
            {CharPosition.Start | CharPosition.End, true, "" },
            {CharPosition.Mid | CharPosition.End, false, "" },
            {CharPosition.Start | CharPosition.Mid | CharPosition.End, true, "" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectBoolean_WhenAtStartTheoryData))]
        public void ShouldReturnCorrectBoolean_WhenAtStart(CharPosition input, bool expectedResult, string testDataName)
        {
            var actualResult = input.IsStart();

            Assert.Equal(expectedResult, actualResult);
        }

        public static TheoryData<CharPosition, bool, string> ShouldReturnCorrectBoolean_WhenAtMidTheoryData => new()
        {
            {CharPosition.Start, false, "" },
            {CharPosition.Mid, true, "" },
            {CharPosition.End, false, "" },
            {CharPosition.Start | CharPosition.Mid, true, "" },
            {CharPosition.Start | CharPosition.End, false, "" },
            {CharPosition.Mid | CharPosition.End, true, "" },
            {CharPosition.Start | CharPosition.Mid | CharPosition.End, true, "" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectBoolean_WhenAtMidTheoryData))]
        public void ShouldReturnCorrectBoolean_WhenAtMid(CharPosition input, bool expectedResult, string testDataName)
        {
            var actualResult = input.IsMid();

            Assert.Equal(expectedResult, actualResult);
        }

        public static TheoryData<CharPosition, bool, string> ShouldReturnCorrectBoolean_WhenAtEndTheoryData => new()
        {
            {CharPosition.Start, false, "" },
            {CharPosition.Mid, false, "" },
            {CharPosition.End, true, "" },
            {CharPosition.Start | CharPosition.Mid, false, "" },
            {CharPosition.Start | CharPosition.End, true, "" },
            {CharPosition.Mid | CharPosition.End, true, "" },
            {CharPosition.Start | CharPosition.Mid | CharPosition.End, true, "" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectBoolean_WhenAtEndTheoryData))]
        public void ShouldReturnCorrectBoolean_WhenAtEnd(CharPosition input, bool expectedResult, string testDataName)
        {
            var actualResult = input.IsEnd();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
