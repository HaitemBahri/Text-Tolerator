using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.PhoneNumberRules;

namespace TextTolerator.Core.Tests.RulesTests.PhoneNumberRulesTests
{
    public class PhoneNumberBracketsPolisherRuleTests
    {
        private PhoneNumberBracketsPolisherRule _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"(455)565000", new List<string>(){ "(455)565000", "455565000" }, ""},

            {"(455) 565000", new List<string>(){ "(455) 565000", "455 565000" }, ""},

            {"(455) (565000)", new List<string>(){ "(455) (565000)", "455 565000" }, ""},
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
