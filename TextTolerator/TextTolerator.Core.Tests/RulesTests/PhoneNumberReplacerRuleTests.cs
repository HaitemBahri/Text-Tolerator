using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.CleanerRules;
using TextTolerator.Core.Rules.ReplacerRules;

namespace TextTolerator.Core.Tests.RulesTests
{
    public class PhoneNumberReplacerRuleTests
    {
        private PhoneNumberReplacerRule _sut = new();

        public PhoneNumberReplacerRuleTests()
        {

        }

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"0021891555", new List<string>(){ "0021891555", "+21891555" }, "(00) - Start"},
            {"+21891555", new List<string>(){ "+21891555", "0021891555" }, "(+) - Start"},

            {"10021891555", new List<string>(){ "10021891555" }, "(00) - Mid"},
            {"5+21891555", new List<string>(){ "5+21891555" }, "(+) - Mid"},
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
