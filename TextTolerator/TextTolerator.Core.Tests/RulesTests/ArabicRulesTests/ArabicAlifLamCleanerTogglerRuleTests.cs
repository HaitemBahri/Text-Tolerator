using TextTolerator.Core.Rules.ArabicRules;

namespace TextTolerator.Core.Tests.RulesTests.ArabicRulesTests
{
    public class ArabicAlifLamCleanerTogglerRuleTests
    {
        private ArabicAlifLamCleanerTogglerRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"القلعة", new List<string>(){ "قلعة", "القلعة"}, "( ال ) - Starts With"},
            {"سيارة", new List<string>(){ "السيارة", "سيارة"}, "( ال ) - Doen't Start With"},
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
