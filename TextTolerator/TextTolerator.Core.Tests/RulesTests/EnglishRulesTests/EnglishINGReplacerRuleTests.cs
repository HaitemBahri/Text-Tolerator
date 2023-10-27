using TextTolerator.Core.Rules.EnglishRules;

namespace TextTolerator.Core.Tests.RulesTests.EnglishRulesTests
{
    public class EnglishINGReplacerRuleTests
    {
        private EnglishINGReplacerRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"going", new List<string>(){ "goin'", "going"}, "(ing -> in')"},
            {"GOING", new List<string>(){ "GOIN'", "GOING"}, "(ING -> IN')"},

            {"goin'", new List<string>(){ "going", "goin'"}, "(in' -> ing)"},
            {"GOIN'", new List<string>(){ "GOING", "GOIN'"}, "(IN' -> ING)"},

            {"goinng", new List<string>(){"goinng"}, "No change"},
            {"GOINNG", new List<string>(){"GOINNG"}, "No change"},

            {"goinn'", new List<string>(){ "goinn'"}, "No change"},
            {"GOINN'", new List<string>(){ "GOINN'"}, "No change"},
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
