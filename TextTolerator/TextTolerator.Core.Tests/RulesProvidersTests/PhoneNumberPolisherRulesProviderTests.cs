using TextTolerator.Core.Rules;
using TextTolerator.Core.Rules.ArabicRules;
using TextTolerator.Core.Rules.PhoneNumberRules;
using TextTolerator.Core.RulesProviders;

namespace TextTolerator.Core.Tests.RulesProvidersTests
{
    public class PhoneNumberPolisherRulesProviderTests
    {
        private PhoneNumberPolisherRulesProvider _sut = new();

        public static TheoryData<List<IRule>, string> ShouldReturnCorrectRulesTheoryData => new()
        {
            {new List<IRule>() {
                new PhoneNumberBracketsPolisherRule(),
                new PhoneNumberSeparatorPolisherRule(),
            }, "Polisher Rules" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectRulesTheoryData))]
        public void ShouldReturnCorrectResult(List<IRule> expectedResult, string testDataName)
        {
            var actualResult = _sut.GetRules();

            var genericRulesProviderTests = new GenericRulesProviderTests();

            genericRulesProviderTests.ShouldReturnCorrectRules(_sut, expectedResult, testDataName);
        }

    }
}
