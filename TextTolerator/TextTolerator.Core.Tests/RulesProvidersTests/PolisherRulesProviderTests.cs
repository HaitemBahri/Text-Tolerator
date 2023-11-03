using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.ArabicRules;
using TextTolerator.Core.Rules.EnglishRules;
using TextTolerator.Core.Rules.PhoneNumberRules;
using TextTolerator.Core.Rules.RulesBases;
using TextTolerator.Core.Rules.WebsiteRules;
using TextTolerator.Core.Rules;
using TextTolerator.Core.RulesProviders;

namespace TextTolerator.Core.Tests.RulesProvidersTests
{
    public class PolisherRulesProviderTests
    {
        private PolisherRulesProvider _sut = new();

        public static TheoryData<List<IRule>, string> ShouldReturnCorrectRulesTheoryData => new()
        {
            {new List<IRule>() {
                new ArabicAccentPolisherRule(),
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
