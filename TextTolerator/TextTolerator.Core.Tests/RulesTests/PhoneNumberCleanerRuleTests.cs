using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules.CleanerRules;

namespace TextTolerator.Core.Tests.RulesTests
{
    public class PhoneNumberCleanerRuleTests
    {
        private PhoneNumberCleanerRule _sut = new();

        public PhoneNumberCleanerRuleTests()
        {

        }

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"(455)565000", new List<string>(){ "(455)565000", "455)565000", "(455565000", "455565000" }, "( () ) - Start, Mid"},
            {"455-565000", new List<string>(){ "455-565000", "455565000" }, "(-) - Mid"},
            {"455 565000", new List<string>(){ "455 565000", "455565000" }, "( Space ) - Mid"},

            {"(455) 565000", new List<string>(){ "(455) 565000", "(455)565000", "(455 565000", "455) 565000",
                                                 "(455565000", "455)565000", "455 565000", "455565000" }, "( () Space ) - Start, Mid"},
            
            {"(455)-565000", new List<string>(){ "(455)-565000", "(455)565000", "(455-565000", "455)-565000",
                                                 "(455565000", "455)565000", "455-565000", "455565000" }, "( () - ) - Start, Mid"},


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
