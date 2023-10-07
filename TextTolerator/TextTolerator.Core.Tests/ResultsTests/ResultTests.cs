using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Results;

namespace TextTolerator.Core.Tests.ResultsTests
{
    public class ResultTests
    {
        private string _originalText = "النص الأصلي";
        private Result _sut;

        public ResultTests()
        {
            _sut = new(_originalText);
        }

        public static TheoryData<string[], string> ShouldReturnCorrectResultListTheoryData => new()
        {
            {new string[] {"علبة" }, "" },
            {new string[] {"مدرسة", "مسجد", "أستراليا" }, "" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectResultListTheoryData))]
        public void ShouldReturnCorrectResultList_WhenAddedOnEmptyResultList(string[] input, string testDataName)
        {
            var expectedResult = new string[] { _originalText };
            expectedResult = expectedResult.Concat(input).ToArray();

            _sut.AddToResultList(input);

            var actualResult = _sut.GetResultArray();

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectResultListTheoryData))]
        public void ShouldReturnCorrectResultList_WhenAddedOnNonEmptyResultList(string[] input, string testDataName)
        {
            var initialList = new string[] {"قلعة", "سيارة" };
            var expectedResult = new string[] { _originalText };
            expectedResult = expectedResult.Concat(initialList).ToArray();
            expectedResult = expectedResult.Concat(input).ToArray();

            _sut.AddToResultList(initialList);
            _sut.AddToResultList(input);

            var actualResult = _sut.GetResultArray();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
