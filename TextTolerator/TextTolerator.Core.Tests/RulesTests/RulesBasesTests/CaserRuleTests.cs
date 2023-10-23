using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTolerator.Core.Rules;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Tests.RulesTests.RulesBasesTests
{
    public class CaserRuleTests
    {
        private CaserRuleBase _sut = new();

        public static TheoryData<string, List<string>, string> ShouldReturnCorrectResultTheoryData => new()
        {
            {"grammer", new List<string>(){ "Grammer", "GRAMMER", "grammer" }, "Lower case"},
            {"Grammer", new List<string>(){ "grammer", "GRAMMER", "Grammer" }, "Cap case"},
            {"GRAMMER", new List<string>(){ "grammer", "Grammer", "GRAMMER" }, "Upper case"},
            {"GRammER", new List<string>(){ "grammer", "Grammer", "GRAMMER", "GRammER" }, "Mixed case 1"},
            {"graMMER", new List<string>(){ "grammer", "Grammer", "GRAMMER", "graMMER" }, "Mixed case 2"},


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
