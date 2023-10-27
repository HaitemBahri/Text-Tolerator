using TextTolerator.Core.Rules.EnglishRules;

namespace TextTolerator.Core.Tests.RulesTests.EnglishRulesTests
{
    public class EnglishSZReplacerRuleTests
    {
        private EnglishSZReplacerRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"Localized", new List<string>(){ "Localized", "Localised" }, "(z) - Mid"},
            {"Localised", new List<string>(){ "Localised", "Localized" }, "(s) - Mid"},

            {"lOCALIZED", new List<string>(){ "lOCALIZED", "lOCALISED" }, "(Z) - Mid"},
            {"lOCALISED", new List<string>(){ "lOCALISED", "lOCALIZED" }, "(S) - Mid"},

            {"Localize", new List<string>(){ "Localize", "Localise" }, "(z) - End"},
            {"Localise", new List<string>(){ "Localise", "Localize" }, "(s) - End"},

            {"lOCALIZE", new List<string>(){ "lOCALIZE", "lOCALISE" }, "(Z) - End"},
            {"lOCALISE", new List<string>(){ "lOCALISE", "lOCALIZE" }, "(S) - End"},

            {"analysed", new List<string>(){ "analyzed", "analysed" }, "(z) - Mid"},
            {"analyze", new List<string>(){ "analyse", "analyze" }, "(s) - Mid"},

            {"ANALYSE", new List<string>(){ "ANALYZE", "ANALYSE" }, "(Z) - Mid"},
            {"ANALYZE", new List<string>(){ "ANALYSE", "ANALYZE" }, "(S) - Mid"},

            {"ZOO", new List<string>(){ "ZOO" }, "(Z) - Start - No Change"},
            {"Bazar", new List<string>(){ "Bazar" }, "(Z) - Mid - No Change"},
            {"version", new List<string>(){ "version" }, "(s) - Mid - No Change"},
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
