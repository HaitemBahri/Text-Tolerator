using TextTolerator.Core.Rules.CleanerRules;

namespace TextTolerator.Core.Tests.RulesTests
{
    public class EnglishCleanerRuleTests
    {
        private EnglishCleanerRule _sut = new();

        public EnglishCleanerRuleTests()
        {

        }

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"can't", new List<string>(){ "can't", "cant" }, "(') - Mid"},

            {"going", new List<string>(){ "going", "goin" }, "(g) - End"},
            {"GOING", new List<string>(){ "GOING", "GOIN" }, "(G) - End"},
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
