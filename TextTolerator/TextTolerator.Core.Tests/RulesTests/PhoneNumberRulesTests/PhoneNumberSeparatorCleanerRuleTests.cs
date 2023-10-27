using TextTolerator.Core.Rules.PhoneNumberRules;

namespace TextTolerator.Core.Tests.RulesTests.PhoneNumberRulesTests
{
    public class PhoneNumberSeparatorCleanerRuleTests
    {
        private PhoneNumberSeparatorCleanerRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"455 565000", new List<string>(){ "455 565000", "455565000" }, "Space"},
            {"455 565 1000", new List<string>(){ "455 565 1000", "455 5651000", "455565 1000", "4555651000" }, "Space - twice"},

            {"455-565000", new List<string>(){ "455-565000", "455565000" }, "Hyphen"},
            {"455-565-1000", new List<string>(){ "455-565-1000", "455-5651000", "455565-1000", "4555651000" }, "Hyphen - twice"},

            {"455 565-1000", new List<string>(){ "455 565-1000", "455 5651000", "455565-1000", "4555651000" }, "Space & Hyphen"},
            {"(455) 565-89-33", new List<string>(){ "(455) 565-89-33", "(455) 565-8933", "(455) 56589-33", "(455) 5658933",
                                                    "(455)565-89-33", "(455)565-8933", "(455)56589-33", "(455)5658933" }, "Space & Hyphen twice"},
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
