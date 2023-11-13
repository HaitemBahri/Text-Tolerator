using TextTolerator.Core.Rules;
using TextTolerator.Core.Rules.ArabicRules;
using TextTolerator.Core.Rules.EnglishRules;
using TextTolerator.Core.RulesProviders;

namespace TextTolerator.Core.Tests.RulesProvidersTests
{
    public class FixedRulesProviderTests
    {
        private FixedRulesProvider _sut;

        public static TheoryData<List<IRule>, string> ShouldReturnCorrectRulesTheoryData => new()
        {
            {new List<IRule>() {
                new ArabicAccentPolisherRule(),
                new ArabicCommonLetterReplacerRule(),
                new EnglishINGReplacerRule(),
            }, "Mixed Rules" },

        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectRulesTheoryData))]
        public void ShouldReturnCorrectResult(List<IRule> expectedResult, string testDataName)
        {
            _sut = new FixedRulesProvider(expectedResult.ToArray());

            var genericRulesProviderTests = new GenericRulesProviderTests();

            genericRulesProviderTests.ShouldReturnCorrectRules(_sut, expectedResult, testDataName);
        }
    }
}
