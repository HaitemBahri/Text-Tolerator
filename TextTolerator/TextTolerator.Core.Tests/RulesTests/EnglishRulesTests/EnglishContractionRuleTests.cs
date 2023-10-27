using TextTolerator.Core.Rules.EnglishRules;

namespace TextTolerator.Core.Tests.RulesTests.EnglishRulesTests
{
    public class EnglishContractionRuleTests
    {
        private EnglishContractionRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"can't", new List<string>(){ "cannot", "can't"}, "Special case"},
            {"cannot", new List<string>(){ "can't", "cannot"}, "Special case"},

            {"don't", new List<string>(){ "do not", "don't" }, "(n't)"},
            {"does not ", new List<string>(){ "doesn't ", "does not " }, "(not)"},

            {"he's", new List<string>(){ "he is", "he's" }, "('s)"},
            {"she is ", new List<string>(){ "she's ", "she is " }, "(is)"},

            {"we've", new List<string>(){ "we have", "we've" }, "('ve)"},
            {"you have ", new List<string>(){ "you've ", "you have " }, "(have)"},

        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectResultTheoryData))]
        public void ShouldReturnCorrectResult(string input, List<string> expectedResult, string testDataName)
        {
            var actualResult = _sut.ProcessText(input);

            expectedResult.Sort();
            actualResult.Sort();

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
