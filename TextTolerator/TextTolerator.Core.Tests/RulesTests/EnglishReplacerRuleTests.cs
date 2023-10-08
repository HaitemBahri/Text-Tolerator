using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.CleanerRules;
using TextTolerator.Core.Rules.ReplacerRules;

namespace TextTolerator.Core.Tests.RulesTests
{
    public class EnglishReplacerRuleTests
    {
        private EnglishReplacerRule _sut = new();

        public EnglishReplacerRuleTests()
        {

        }

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"Localized", new List<string>(){ "Localized", "Localised" }, "(z) - Mid"},
            {"Localised", new List<string>(){ "Localised", "Localized" }, "(s) - Mid"},

            {"lOCALIZED", new List<string>(){ "lOCALIZED", "lOCALISED" }, "(Z) - Mid"},
            {"lOCALISED", new List<string>(){ "lOCALISED", "lOCALIZED" }, "(S) - Mid"},
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
