using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules;
using TextTolerator.Core.Rules.ArabicRules;
using TextTolerator.Core.Rules.EnglishRules;
using TextTolerator.Core.Rules.PhoneNumberRules;
using TextTolerator.Core.Rules.RulesBases;
using TextTolerator.Core.Rules.WebsiteRules;
using TextTolerator.Core.RulesProviders;
using Xunit.Sdk;

namespace TextTolerator.Core.Tests.RulesProvidersTests
{
    public class GenericRulesProviderTests
    {
        public static TheoryData<IRulesProvider, List<IRule>, string> ShouldReturnCorrectRulesTheoryData => new()
        {
            {new GenericRulesProvider<ArabicRuleAttribute>(), new List<IRule>() {
                new ArabicAccentPolisherRule(),
                new ArabicAlifLamCleanerTogglerRule(),
                new ArabicCommonLetterReplacerRule(),
            }, "Arabic Rules" },

            {new GenericRulesProvider<EmailAddressRuleAttribute>(), new List<IRule>() {
                new CaserRuleBase(),
            }, "EmailAddress Rules" },

            {new GenericRulesProvider<EnglishRuleAttribute>(), new List<IRule>() {
                new CaserRuleBase(),
                new EnglishContractionRule(),
                new EnglishINGReplacerRule(),
                new EnglishSZReplacerRule(),
            }, "English Rules" },

            {new GenericRulesProvider<PhoneNumberRuleAttribute>(), new List<IRule>() {
                new PhoneNumberBracketsPolisherRule(),
                new PhoneNumberIntCodeReplacerRule(),
                new PhoneNumberSeparatorPolisherRule(),
            }, "PhoneNumber Rules" },

            {new GenericRulesProvider<WebsiteRuleAttribute>(), new List<IRule>() {
                new Website2HttpCleanerTogglerRule(),
                new Website1WWWCleanerTogglerRule(),
                new CaserRuleBase(),
            }, "Website Rules" },
        };

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectRulesTheoryData))]
        public void ShouldReturnCorrectRules(IRulesProvider _sut, IEnumerable<IRule> expectedResult, string testDataName)
        {
            IEnumerable<IRule> actualResult = _sut.GetRules();

            var expectedResultList = expectedResult.ToList();
            var actualResultList = actualResult.ToList();

            if (expectedResult.Count() != actualResult.Count())
                throw new XunitException("Expected result differs in count from the actual result.\n"
                    + GetFailedAssertionMessage(expectedResultList, actualResultList));

            for(int i = 0; i < expectedResultList.Count(); i++)
            {
                if (expectedResultList[i].GetType() != actualResultList[i].GetType() )
                {
                    throw new XunitException("Elements of expected result is different from actual result.\n"
                        + GetFailedAssertionMessage(expectedResultList, actualResultList));
                }
            }
        }

        private string GetFailedAssertionMessage(List<IRule> expectedResult, List<IRule> actualResult)
        {
            return "Expected Result = " + String.Join(",", expectedResult)
                    + "\nActual Result = " + String.Join(",", actualResult);
        }
    }
}
